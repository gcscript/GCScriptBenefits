using DevExpress.XtraEditors;
using GCScript.Database.MongoDB;
using GCScript.Database.MongoDB.DataAccess;
using GCScript.Database.MongoDB.Models;
using GCScript.Shared;
using GCScript.Shared.Models;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCScript.Client.Windows;

public partial class frm_Main : DevExpress.XtraEditors.XtraForm
{

    private XtraForm openForm;
    private enum EForms { Data = 0, Management = 1 };

    public frm_Main()
    {
        InitializeComponent();
        MainInstances.SvgShortcut = svg_Shortcut;
        btn_Management.Enabled = false;
        btn_Management.Visible = false;
    }

    private async void btn_Management_Click(object sender, EventArgs e)
    {
        new frm_RiocardBalanceTools().ShowDialog();
        return;
        SettingsDB.MongoDbUsername = "";
        SettingsDB.MongoDbPassword = "";

        OperatorDataAccess access = new OperatorDataAccess();
        MOperator op = new()
        {
            Name = "TIL",
            Uf = "PR",
            Url = "https://max00574.itstransdata.com/TDMaxWebCommerce/",
            CreatedBy = SettingsDB.MongoDbUsername
        };

        var teste = await access.InsertOneAsync(op);
        if (teste)
        {
            XtraMessageBox.Show("Feito!");
            return;

        }



        //frm_Management frm = new();
        //frm.ShowDialog();
    }

    private async void btn_LogIn_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(txt_Username.Text))
            {
                XtraMessageBox.Show($"O Usuário não pode ser vazio!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Username.Select();
                return;
            }

            if (string.IsNullOrWhiteSpace(txt_Password.Text))
            {
                XtraMessageBox.Show($"A Senha não pode ser vazia!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Password.Select();
                return;
            }

            if (txt_Username.Text.Length < 4)
            {
                XtraMessageBox.Show($"O Usuário precisa ter 4 ou mais caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Username.Select();
                return;
            }

            if (txt_Password.Text.Length < 4)
            {
                XtraMessageBox.Show($"A Senha precisa ter 4 ou mais caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txt_Password.Select();
                return;
            }

            pnl_Login.Enabled = false;
            ssm_Main.ShowWaitForm();
            ssm_Main.SetWaitFormDescription("Autenticando...");
            SettingsDB.MongoDbUsername = txt_Username.Text;
            SettingsDB.MongoDbPassword = txt_Password.Text;
            UserDataAccess ac = new();
            var result = await ac.Login();
            if (result.User == null)
            {
                pnl_Login.Enabled = true;
                try { ssm_Main.CloseWaitForm(); } catch { }
                txt_Username.Text = "";
                txt_Password.Text = "";
                XtraMessageBox.Show($"{result.Message}", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Username.Select();
                return;
            }

            await DiscordWebhook.SendMessage(Settings.DiscordWebhookAuthenticationUrl, new MDiscordWebhook() { Username = $"GCScript Benefits", Content = $"**{SettingsDB.MongoDbUsername}** acabou de entrar" });
            SaveUsername(SettingsDB.MongoDbUsername);
            lbl_LoggedInUser.Text = result.User.Name;
        }
        catch (Exception ex)
        {
            pnl_Login.Enabled = true;
            XtraMessageBox.Show($"{ex.Message}", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        finally
        {
            try { ssm_Main.CloseWaitForm(); } catch { }
        }

        Task.Delay(1000).Wait();
        OpenSubForm(EForms.Data);
        HideLoginPanel();
    }

    private void frm_Main_Load(object sender, EventArgs e)
    {
        ShowLoginPanel();
        var username = LoadUsername();
        if (!string.IsNullOrWhiteSpace(username))
        {
            txt_Username.Text = username;
            txt_Password.Select();
        }
        else
        {
            txt_Username.Select();

        }
    }

    private void ShowLoginPanel()
    {
        pnl_Login.BringToFront();
        pnl_Login.Dock = DockStyle.Fill;
        pnl_Login.Visible = true;
        pnl_Login.Enabled = true;
    }

    private void HideLoginPanel()
    {
        pnl_Login.Visible = false;
        pnl_Login.Enabled = false;
        pnl_Login.SendToBack();
        pnl_Login.Dock = DockStyle.None;
    }

    private void OpenSubForm(EForms form)
    {
        if (openForm is not null)
        {
            openForm.Close();
        }

        switch (form)
        {
            case EForms.Data:
                openForm = new frm_Data(ssm_Main);
                break;
            case EForms.Management:
                openForm = new frm_Management();
                break;
            default:
                MessageBox.Show("Erro");
                return;
        }

        pnl_Container.Enabled = true;
        pnl_Container.Visible = true;
        openForm!.TopLevel = false;
        openForm.FormBorderStyle = FormBorderStyle.None;
        openForm.AutoSize = true;
        openForm.Dock = DockStyle.Fill;
        pnl_Container.Controls.Add(openForm);
        pnl_Container.Tag = openForm;
        openForm.BringToFront();
        //ssm_Main.CloseWaitForm();
        openForm.Show();
    }

    private void acce_Home_Click(object sender, EventArgs e)
    {
    }

    private void acce_Data_Click(object sender, EventArgs e)
    {
        OpenSubForm(EForms.Data);
    }

    private void acce_Management_Click(object sender, EventArgs e)
    {
        OpenSubForm(EForms.Management);
    }

    private void txt_Username_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter) { btn_LogIn_Click(sender, e); }
    }

    private void txt_Password_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Enter) { btn_LogIn_Click(sender, e); }
    }

    private void SaveUsername(string Username)
    {
        try
        {
            if (!Directory.Exists(Settings.AppDataPath))
            {
                Directory.CreateDirectory(Settings.AppDataPath);
            }
            var filePath = Path.Combine(Settings.AppDataPath, "username.txt");
            File.WriteAllText(filePath, Username);
        }
        catch { }
    }

    private string LoadUsername()
    {
        try
        {
            var filePath = Path.Combine(Settings.AppDataPath, "username.txt");
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath).Trim();
            }
        }
        catch { }
        return "";
    }

    private void btn_RegisterCancel_Click(object sender, EventArgs e)
    {
        nvf_Login.SelectedPage = nvp_Login;
        txt_RegisterUsername.Text = "";
        txt_RegisterPassword.Text = "";
        txt_RegisterConfirmPassword.Text = "";

        if (!string.IsNullOrWhiteSpace(txt_Username.Text))
        {
            txt_Password.Select();
        }
        else
        {
            txt_Username.Select();
        }
    }

    private void lbl_Register_Click(object sender, EventArgs e)
    {
        nvf_Login.SelectedPage = nvp_Register;
        txt_RegisterUsername.Focus();
    }

    private async void btn_Register_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txt_RegisterUsername.Text))
        {
            XtraMessageBox.Show($"O Usuário não pode ser vazio!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txt_RegisterUsername.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txt_RegisterPassword.Text))
        {
            XtraMessageBox.Show($"A Senha não pode ser vazia!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txt_RegisterPassword.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(txt_RegisterConfirmPassword.Text))
        {
            XtraMessageBox.Show($"Por favor, confirme sua senha!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txt_RegisterConfirmPassword.Focus();
            return;
        }

        if (txt_RegisterUsername.Text.Length < 4)
        {
            XtraMessageBox.Show($"O Usuário precisa ter 4 ou mais caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txt_RegisterUsername.Focus();
            return;
        }

        if (txt_RegisterPassword.Text.Length < 4)
        {
            XtraMessageBox.Show($"A Senha precisa ter 4 ou mais caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txt_RegisterPassword.Focus();
            return;
        }

        if (txt_RegisterPassword.Text != txt_RegisterConfirmPassword.Text)
        {
            XtraMessageBox.Show($"A Senha e a Confirmação da Senha precisam ser iguais!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txt_RegisterPassword.Text = "";
            txt_RegisterConfirmPassword.Text = "";
            txt_RegisterPassword.Focus();
            return;
        }

        tbp_Register.Enabled = false;
        if (await DiscordWebhook.SendMessage(Settings.DiscordWebhookRegisterUrl, new MDiscordWebhook() { Username = $"GCScript Benefits", Content = $"**CADASTRO**\nUsername: ||{txt_RegisterUsername.Text}||\nPassword: ||{txt_RegisterPassword.Text}||" }))
        {
            XtraMessageBox.Show($"Solicitação enviada com sucesso!\nAguarda a autorização do administrador.", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Information);
            tbp_Register.Enabled = true;
            btn_RegisterCancel_Click(sender, e);
        }
        else
        {
            tbp_Register.Enabled = true;
            XtraMessageBox.Show($"Não foi possível registrar o usuário!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}