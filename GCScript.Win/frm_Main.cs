using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using GCScript.DataBase;
using GCScript.DataBase.Controllers;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GCScript.Win;

public partial class frm_Main : DevExpress.XtraEditors.XtraForm
{
    private XtraForm openForm;
    private enum EForms { Data = 0, Management = 1 };

    public frm_Main()
    {
        InitializeComponent();
        MainInstances.SvgShortcut = svg_Shortcut;
    }

    private async void btn_LogIn_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txt_Username.Text)
                || string.IsNullOrWhiteSpace(txt_Username.Text))
            {
                XtraMessageBox.Show($"O Usuário não pode ser vazio!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Username.Select();
                return;
            }

            if (string.IsNullOrEmpty(txt_Password.Text)
                || string.IsNullOrWhiteSpace(txt_Password.Text))
            {
                XtraMessageBox.Show($"A Senha não pode ser vazia!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Password.Select();
                return;
            }

            if (txt_Username.Text.Length < 3)
            {
                XtraMessageBox.Show($"O Usuário precisa ter 3 ou mais caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Username.Select();
                return;
            }

            if (txt_Password.Text.Length < 3)
            {
                XtraMessageBox.Show($"A Senha precisa ter 3 ou mais caracteres!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Password.Select();
                return;
            }

            pnl_Login.Enabled = false;
            ssm_Main.ShowWaitForm();
            ssm_Main.SetWaitFormDescription("Autenticando...");
            SettingsDB.MongoDbUsername = txt_Username.Text;
            SettingsDB.MongoDbPassword = txt_Password.Text;
            AuthenticationController ac = new();
            var result = await ac.Login();
            if (!result.Success)
            {
                pnl_Login.Enabled = true;
                try { ssm_Main.CloseWaitForm(); } catch { }
                txt_Username.Text = "";
                txt_Password.Text = "";
                XtraMessageBox.Show($"{result.Message}", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_Username.Select();
                return;
            }
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
        HideLoginPanel();
        OpenSubForm(EForms.Data);
        lbl_LoggedInUser.Text = txt_Username.Text;

    }

    private void frm_Main_Load(object sender, EventArgs e)
    {
        ShowLoginPanel();
    }

    private void ShowLoginPanel()
    {
        pnl_Login.BringToFront();
        pnl_Login.Dock = DockStyle.Fill;
        pnl_Login.Visible = true;
        pnl_Login.Enabled = true;
        txt_Username.Select();
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

    private void btn_Management_Click(object sender, EventArgs e)
    {
        frm_Management frm = new();
        frm.ShowDialog();
    }
}