using DevExpress.XtraEditors;
using GCScript.DataBase.Controllers;
using GCScript.DataBase.Models;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCScript.Win;

public partial class frm_Unit : DevExpress.XtraEditors.XtraForm
{
    public frm_Unit()
    {
        InitializeComponent();
    }

    private async void frm_Unit_Load(object sender, EventArgs e)
    {
        OperatorController operatorController = new();
        var operators = await operatorController.GetAllAsync();
        operators = operators.OrderBy(x => x.UF).ThenBy(x => x.Name).ToList();
        foreach (var op in operators)
        {
            cmb_Operators.Properties.Items.Add($"{op.UF} - {op.Name}");
        }

        if (cmb_Operators.Properties.Items.Count > 0)
        {
            cmb_Operators.SelectedIndex = 0;
        }

        CompanyController companyController = new();
        var companies = await companyController.GetAllAsync();
        companies = companies.OrderBy(x => x.Name).ToList();
        foreach (var comp in companies)
        {
            cmb_Companies.Properties.Items.Add(comp.Name);
        }

        if (cmb_Companies.Properties.Items.Count > 0)
        {
            cmb_Companies.SelectedIndex = 0;
        }
    }

    private async void btn_Create_Click(object sender, EventArgs e)
    {
        //await Create();
        await ManyCreate();
    }

    private async Task Create()
    {
        var operatorUF = cmb_Operators.Text.Substring(0, 2);
        var operatorName = cmb_Operators.Text.Substring(5).Trim();
        var companyName = cmb_Companies.Text.Trim();
        var unitName = txt_Name.Text.Trim();
        var unitUsername = txt_Username.Text.Trim();
        var unitPassword = txt_Password.Text.Trim();
        var unitCNPJ = Regex.Replace(txt_CNPJ.Text.Trim(), "[^0-9]", "");
        var unitObservations = mmo_Observations.Text.Trim();

        if (string.IsNullOrEmpty(operatorUF) || string.IsNullOrEmpty(operatorName))
        {
            XtraMessageBox.Show("Selecione uma operadora!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cmb_Operators.Select();
            return;
        }

        if (string.IsNullOrEmpty(companyName))
        {
            XtraMessageBox.Show("Selecione uma empresa!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            cmb_Companies.Select();
            return;
        }

        if (string.IsNullOrEmpty(unitName) || unitName.Length < 2)
        {
            XtraMessageBox.Show("O nome da unidade deve ter no mínimo 2 caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_Name.Select();
            return;
        }

        if (string.IsNullOrEmpty(unitUsername) || unitUsername.Length < 3)
        {
            XtraMessageBox.Show("O nome de usuário deve ter no mínimo 3 caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_Username.Select();
            return;
        }

        if (string.IsNullOrEmpty(unitPassword) || unitPassword.Length < 3)
        {
            XtraMessageBox.Show("A senha deve ter no mínimo 3 caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_Password.Select();
            return;
        }

        if (string.IsNullOrEmpty(unitCNPJ) || unitCNPJ.Length < 14)
        {
            XtraMessageBox.Show("O CNPJ deve ter 14 caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txt_CNPJ.Select();
            return;
        }

        if (string.IsNullOrEmpty(unitObservations)) { unitObservations = null; }

        OperatorController operatorController = new();
        var op = await operatorController.GetAsync(operatorUF, operatorName);

        if (op is null)
        {
            XtraMessageBox.Show($"A operadora {operatorName} não foi encontrada!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        CompanyController companyController = new();
        var co = await companyController.GetAsync(companyName);

        if (co is null)
        {
            XtraMessageBox.Show($"A empresa {companyName} não foi encontrada!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        MUnit unit = new()
        {
            Name = unitName,
            Username = unitUsername,
            Password = unitPassword,
            CNPJ = unitCNPJ,
            Observations = unitObservations,
            OperatorId = op.Id,
            CompanyId = co.Id,
        };

        UnitController us = new();
        var result = await us.InsertOneAsync(unit);
        if (result)
        {
            XtraMessageBox.Show($"A unidade {unitName} foi criada com sucesso!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txt_Name.Text = string.Empty;

            if (chk_ClearFields.Checked)
            {
                txt_Username.Text = string.Empty;
                txt_Password.Text = string.Empty;
                txt_CNPJ.Text = string.Empty;
                mmo_Observations.Text = string.Empty;
            }

            txt_Name.Select();
        }
        else
        {
            XtraMessageBox.Show($"Erro ao criar a unidade {unitName}!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void txt_Name_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter)
        {
            await Create();
        }
        else if (e.KeyChar == 22)
        {
            var cb = Clipboard.GetText();
            var itens = cb.Split('\t');
            if (itens.Length == 4)
            {
                txt_Username.Text = itens[1].Trim();
                txt_Password.Text = itens[2].Trim();
                txt_CNPJ.Text = itens[3].Trim();
                await Task.Delay(200);
                txt_Name.Text = itens[0].Trim();
                btn_Create.Select();
            }
            else if (itens.Length == 5)
            {
                txt_Username.Text = itens[1].Trim();
                txt_Password.Text = itens[2].Trim();
                txt_CNPJ.Text = itens[3].Trim();
                mmo_Observations.Text = itens[4].Trim();
                await Task.Delay(200);
                txt_Name.Text = itens[0].Trim();
                btn_Create.Select();
            }

        }
    }

    private async Task ManyCreate()
    {
        var cb = Clipboard.GetText().Trim();
        var lines = cb.Split('\n');
        foreach (var line in lines)
        {
            var itens = line.Split('\t');

            if (itens.Length != 4)
            {
                XtraMessageBox.Show($"O seguinte item não pode ser inserido:\n{line}", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        foreach (var line in lines)
        {
            var itens = line.Split('\t');

            txt_Name.Text = itens[0].Trim();
            txt_Username.Text = itens[1].Trim();
            txt_Password.Text = itens[2].Trim();
            txt_CNPJ.Text = itens[3].Trim();
            //await Task.Delay(200);
            await Create();
        }

        XtraMessageBox.Show($"Foram criadas {lines.Length} unidades!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    private void txt_CNPJ_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 22 || e.KeyChar == (char)Keys.Enter)
        {
            mmo_Observations.Select();
        }
    }

    private void mmo_Observations_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 22)
        {
            btn_Create.Select();
        }

    }
}