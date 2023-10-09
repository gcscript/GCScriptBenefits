using Consulta.CNPJ.Services;
using CpfCnpjLibrary;
using DevExpress.XtraEditors;
using GCScript.Database.MongoDB;
using GCScript.Database.MongoDB.DataAccess;
using GCScript.Database.MongoDB.Models;
using GCScript.Shared;
using GCScript.Shared.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GCScript.Client.Windows;

public partial class frm_Unit : DevExpress.XtraEditors.XtraForm
{
    public string LastCnpj = string.Empty;
    public frm_Unit()
    {
        InitializeComponent();
    }

    private async void frm_Unit_Load(object sender, EventArgs e)
    {
        try
        {
            ssm_Main.ShowWaitForm();
            ssm_Main.SetWaitFormDescription("Carregando...");
            OperatorDataAccess oda = new();
            var operators = await oda.GetAllAsync();
            operators = operators.OrderBy(x => x.Uf).ThenBy(x => x.Name).ToList();
            foreach (var op in operators)
            {
                cmb_Operators.Properties.Items.Add($"{op.Uf} - {op.Name}");
            }

            if (cmb_Operators.Properties.Items.Count > 0)
            {
                cmb_Operators.SelectedIndex = 0;
            }
            else
            {
                throw new Exception("Erro ao obter lista de operadoras!");
            }

            CompanyDataAccess cda = new();
            var companies = await cda.GetAllAsync();
            companies = companies.OrderBy(x => x.Name).ToList();
            foreach (var comp in companies)
            {
                cmb_Companies.Properties.Items.Add(comp.Name);
            }

            if (cmb_Companies.Properties.Items.Count > 0)
            {
                cmb_Companies.SelectedIndex = 0;
            }
            else
            {
                throw new Exception("Erro ao obter lista de empresas!");
            }

            try { ssm_Main.CloseWaitForm(); } catch { }

            cmb_Operators.Focus();
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show($"{ex.Message}", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            try { Close(); } catch { }
            return;
        }
        finally
        {
            try { ssm_Main.CloseWaitForm(); } catch { }
        }
    }

    private async void btn_Create_Click(object sender, EventArgs e)
    {
        try
        {
            UnitDataAccess unitDataAccess = new();
            MUnit unit = new()
            {
                Uf = cmb_Operators.Text[..2],
                Operator = cmb_Operators.Text[5..].Trim(),
                Company = cmb_Companies.Text.Trim(),
                Name = txt_Name.Text.Trim(),
                Username = txt_Username.Text.Trim(),
                Password = txt_Password.Text.Trim(),
                Cnpj = chk_DoNotInformCnpj.Checked ? "00000000000000" : txt_CNPJ.Text.Trim(),
                CreatedBy = SettingsDB.MongoDbUsername
            };

            if (string.IsNullOrWhiteSpace(unit.Name) || unit.Name.Length < 2)
            {
                XtraMessageBox.Show("O nome da unidade deve ter no mínimo 2 caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Name.Select();
                return;
            }

            if (string.IsNullOrWhiteSpace(unit.Username) || unit.Username.Length < 3)
            {
                XtraMessageBox.Show("O nome de usuário deve ter no mínimo 3 caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Username.Select();
                return;
            }

            if (string.IsNullOrWhiteSpace(unit.Password) || unit.Password.Length < 3)
            {
                XtraMessageBox.Show("A senha deve ter no mínimo 3 caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Password.Select();
                return;
            }

            if (!chk_DoNotInformCnpj.Checked)
            {
                if (!Cnpj.Validar(unit.Cnpj))
                {
                    XtraMessageBox.Show("Informe um CNPJ válido!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_CNPJ.Select();
                    return;
                }
            }

            if (chk_DoNotInformCnpj.Checked && cmb_Operators.Text.Contains("RJ - RIOCARD"))
            {
                if (XtraMessageBox.Show($"Você não poderar gerar pedidos se não fornecer um CNPJ.\nDeseja continuar?",
                                       "GCScript Benefits",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Warning,
                                       MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }
            }

            if (cmb_Operators.SelectedIndex == 0)
            {
                if (XtraMessageBox.Show($"Você tem certeza que deseja criar {unit.Name} na operadora {unit.Uf} - {unit.Operator}?",
                                       "GCScript Benefits",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    cmb_Operators.Select();
                    return;
                }
            }

            if (cmb_Companies.SelectedIndex == 0)
            {
                if (XtraMessageBox.Show($"Você tem certeza que deseja criar {unit.Name} na empresa {unit.Company}?",
                                       "GCScript Benefits",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question,
                                       MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    cmb_Companies.Select();
                    return;
                }
            }

            if (await new OperatorDataAccess().GetAsync(unit.Uf, unit.Operator) is null)
            {
                XtraMessageBox.Show($"A operadora {unit.Uf} - {unit.Operator} não existe.\nReinicie a aplicação e tente novamente!",
                                       "GCScript Benefits",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Error);
                return;
            }

            if (await new CompanyDataAccess().GetAsync(unit.Company) is null)
            {
                XtraMessageBox.Show($"A empresa {unit.Company} não existe.\nReinicie a aplicação e tente novamente!",
                                       "GCScript Benefits",
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Error);
                return;
            }

            ssm_Main.ShowWaitForm();
            ssm_Main.SetWaitFormDescription("Cadastrando...");
            var insert = await unitDataAccess.InsertOneAsync(unit);
            if (insert.Result)
            {
                try { ssm_Main.CloseWaitForm(); } catch { }
                await DiscordWebhook.SendMessage(Settings.DiscordWebhookUrl, new MDiscordWebhook() { Username = $"GCScript Benefits", Content = $"**{SettingsDB.MongoDbUsername}** cadastrou a unidade **{unit.Uf}** > **{unit.Operator}** > **{unit.Company}** > **{unit.Name}** [{unit.Id}]" });
                XtraMessageBox.Show($"A unidade {unit.Name} foi criada com sucesso!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try { ssm_Main.CloseWaitForm(); } catch { }
                if (insert.Message.Contains("user is not allowed", StringComparison.OrdinalIgnoreCase))
                {
                    XtraMessageBox.Show($"Você não tem permissão para cadastrar unidades!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    throw new Exception();
                }
            }
            try { ssm_Main.CloseWaitForm(); } catch { }

            if (chk_ClearFields.Checked)
            {
                txt_Name.Text = string.Empty;
                txt_Username.Text = string.Empty;
                txt_Password.Text = string.Empty;
                txt_CNPJ.Text = string.Empty;
            }

            txt_Name.Select();
        }
        catch
        {
            try { ssm_Main.CloseWaitForm(); } catch { }
            XtraMessageBox.Show($"Não foi possível criar a unidade!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            try { ssm_Main.CloseWaitForm(); } catch { }
        }
    }

    private void txt_Name_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsLetterOrDigit(e.KeyChar)
            && e.KeyChar != 8 // Backspace
            && e.KeyChar != 32 // Space
            && e.KeyChar != 40 // (
            && e.KeyChar != 41 // )
            && e.KeyChar != 45 // -
            && e.KeyChar != 46 // .
            && !char.IsControl(e.KeyChar))
        {
            e.Handled = true; // Cancela a entrada do caractere
        }
    }

    private void txt_Username_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 22 || e.KeyChar == (char)Keys.Enter)
        {
            txt_Password.Select();
        }
    }

    private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 22 || e.KeyChar == (char)Keys.Enter)
        {
            txt_CNPJ.Select();
        }

    }


    private void txt_Name_Validating(object sender, System.ComponentModel.CancelEventArgs e)
    {
        txt_Name.Text = Tools.ProcessTextDefault(Regex.Replace(Tools.ProcessTextDefault(txt_Name.Text), @"[^A-Z0-9\s\(\)-]", ""));
    }

    private void chk_DoNotInformCnpj_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_DoNotInformCnpj.Checked)
        {
            btn_SearchCnpj.Enabled = false;
            txt_CNPJ.Text = ""; txt_CNPJ.Enabled = false;
        }
        else
        {
            txt_CNPJ.Enabled = true;
            btn_SearchCnpj.Enabled = true;
        }
    }

    private void txt_CNPJ_Leave(object sender, EventArgs e)
    {
        if (Cnpj.Validar(txt_CNPJ.Text))
        {
            var cnpj = Cnpj.FormatarComPontuacao(txt_CNPJ.Text);
            txt_CNPJ.Text = cnpj;
        }
    }

    private void btn_SearchCnpj_Click(object sender, EventArgs e)
    {
        string cnpj = txt_CNPJ.Text;
        if (Cnpj.Validar(cnpj))
        {
            try
            {
                ssm_Main.ShowWaitForm();
                ssm_Main.SetWaitFormDescription("Consultando CNPJ...");
                var result = new CNPJService().ConsultarCPNJ(Cnpj.FormatarSemPontuacao(cnpj));
                try { ssm_Main.CloseWaitForm(); } catch { }

                if (result != null)
                {
                    txt_Name.Text = result.Nome.Trim();
                    txt_Name.Focus();
                }
            }
            finally
            {
                try { ssm_Main.CloseWaitForm(); } catch { }
            }
        }
    }
}