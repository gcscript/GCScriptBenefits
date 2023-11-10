using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using GCScript.Operator;
using GCScript.Shared;
using MongoDB.Bson;
using NHotkey;
using NHotkey.WindowsForms;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using GCScript.Database.MongoDB.Models;
using GCScript.Database.MongoDB.DataAccess;
using DevExpress.XtraGrid;
using System.Collections.Generic;
using GCScript.Database.MongoDB.ViewModels;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Au;
using System.Net.Http;
using GCScript.Shared.Models;
using GCScript.Database.MongoDB;

namespace GCScript.Client.Windows;

public partial class frm_Data : XtraForm
{
    public List<VMUnitMenu> DataSourceMenu { get; set; }

    public MOperator CurrentOperator { get; set; }
    public MCompany CurrentCompany { get; set; }
    public MUnit CurrentUnit { get; set; }
    public SplashScreenManager Ssm { get; }
    public bool Pasting { get; set; }

    public frm_Data(SplashScreenManager ssm)
    {
        InitializeComponent();
        #region DEFINIR ATALHOS
        try
        {
            HotkeyManager.Current.AddOrReplace("DefinirUsername", System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F5, SetShortcuts);
            HotkeyManager.Current.AddOrReplace("DefinirPassword", System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F6, SetShortcuts);
            HotkeyManager.Current.AddOrReplace("DefinirResumo", System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F7, SetShortcuts);
            HotkeyManager.Current.AddOrReplace("DefinirBoleto", System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F8, SetShortcuts);
            HotkeyManager.Current.AddOrReplace("DefinirResumoNovo", System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F9, SetShortcuts);
            HotkeyManager.Current.AddOrReplace("DefinirBoletoNovo", System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F10, SetShortcuts);
            HotkeyManager.Current.AddOrReplace("DefinirResumo2Via", System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F11, SetShortcuts);
            HotkeyManager.Current.AddOrReplace("DefinirBoleto2Via", System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F12, SetShortcuts);
            MainInstances.SvgShortcut.SvgImage = Properties.Resources.on;
        }
        catch (Exception)
        {
            try { HotkeyManager.Current.Remove("DefinirUsername"); } catch { }
            try { HotkeyManager.Current.Remove("DefinirPassword"); } catch { }
            try { HotkeyManager.Current.Remove("DefinirResumo"); } catch { }
            try { HotkeyManager.Current.Remove("DefinirBoleto"); } catch { }
            try { HotkeyManager.Current.Remove("DefinirResumoNovo"); } catch { }
            try { HotkeyManager.Current.Remove("DefinirBoletoNovo"); } catch { }
            try { HotkeyManager.Current.Remove("DefinirResumo2Via"); } catch { }
            try { HotkeyManager.Current.Remove("DefinirBoleto2Via"); } catch { }
            MainInstances.SvgShortcut.SvgImage = Properties.Resources.off;
        }
        #endregion
        Ssm = ssm;
    }

    private async void frm_Data_Load(object sender, EventArgs e)
    {
        ColumnDefinitions();
        CreateDropDownMenus();
        //rbbc_Main.Minimized = true;
        rbbc_Details.Minimized = true;
        try
        {
            try { Ssm.ShowWaitForm(); Ssm.SetWaitFormDescription("Loading Companies..."); } catch { }
            CompanyDataAccess cda = new();
            var companies = await cda.GetAllAsync();
            companies = companies.OrderBy(x => x.Name).ToList();
            foreach (var comp in companies)
            {
                cmb_Search.Properties.Items.Add(comp.Name);
            }
            nvf_Main.Enabled = true;
            nvf_Main.Visible = true;
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        finally
        {
            try { Ssm.CloseWaitForm(); } catch { }
        }

        if (cmb_Search.Properties.Items.Count > 0)
        {
            cmb_Search.SelectedIndex = 0;
        }

        cmb_Search.Select();
    }

    private void CreateDropDownMenus()
    {
        try
        {
            ddbtn_CopyResume.DropDownControl = new DXPopupMenu
            {
                Items = { new DXMenuItem("Novo", (s, e) => {
                clipboard.text = $"{txt_Resume.Text} [NOVO-SEM CARTAO]";
            }), new DXMenuItem("2ª Via", (s, e) => {
                clipboard.text = $"{txt_Resume.Text} [2ª VIA]";
            }) }
            };

            ddbtn_CopyBankSlip.DropDownControl = new DXPopupMenu
            {
                Items = { new DXMenuItem("Novo", (s, e) => {
                clipboard.text = $"{txt_BankSlip.Text} [NOVO-SEM CARTAO]";
            }), new DXMenuItem("2ª Via", (s, e) => {
                clipboard.text = $"{txt_BankSlip.Text} [2ª VIA]";
            }) }
            };
        }
        catch { }
    }

    private async void SalvarPlanilha(string nome)
    {
        try
        {
            string sheet = nome == "dados" ? Settings.DadosSheetPath : Settings.SaldoSheetPath;

            if (!File.Exists(sheet))
            {
                throw new Exception("A Planilha não existe!\nPor favor, reinstale a Aplicação!");
            }

            string Data = DateTime.Now.AddMonths(1).ToString("MM-yyyy");
            if (DateTime.Now.Month == 12)
            {
                Data = DateTime.Now.AddYears(1).ToString("MM-yyyy");
            }

            System.Windows.Forms.SaveFileDialog sfdSalvar = new();
            sfdSalvar.Title = "Salvar como";
            sfdSalvar.Filter = "Planilha do Excel|*.xlsx";

            sfdSalvar.FileName = nome == "dados" ? $"Dados Nome_da_Empresa {Data}" : $"_RIOCARD [{DateTime.Now:yyyy-MM-dd}]";

            if (sfdSalvar.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string dirSalvar = sfdSalvar.FileName;
                File.Copy(sheet, dirSalvar, true);

                while (!File.Exists(dirSalvar))
                {
                    await Task.Delay(100);
                }

                Process.Start(new ProcessStartInfo(dirSalvar) { UseShellExecute = true });
            }
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    private void SetShortcuts(object sender, HotkeyEventArgs e)
    {
        try
        {
            if (!Pasting)
            {
                clipboard.clear();
                Pasting = true;
                switch (e.Name)
                {
                    case "DefinirUsername":
                        clipboard.tryPaste(txt_Username.Text);
                        break;
                    case "DefinirPassword":
                        clipboard.tryPaste(txt_Password.Text);
                        break;
                    case "DefinirResumo":
                        clipboard.tryPaste(txt_Resume.Text);
                        break;
                    case "DefinirBoleto":
                        clipboard.tryPaste(txt_BankSlip.Text);
                        break;

                    case "DefinirResumoNovo":
                        clipboard.tryPaste($"{txt_Resume.Text} [NOVO-SEM CARTAO]");
                        break;
                    case "DefinirBoletoNovo":
                        clipboard.tryPaste($"{txt_BankSlip.Text} [NOVO-SEM CARTAO]");
                        break;

                    case "DefinirResumo2Via":
                        clipboard.tryPaste($"{txt_Resume.Text} [2ª VIA]");
                        break;
                    case "DefinirBoleto2Via":
                        clipboard.tryPaste($"{txt_BankSlip.Text} [2ª VIA]");
                        break;
                    default:
                        break;
                }
                e.Handled = true;
                Task.Run(() => { Thread.Sleep(200); Pasting = false; });
            }
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message);
        }
    }

    //private async Task AllowNHotkey(int millisecondsDelay)
    //{
    //    await Task.Delay(millisecondsDelay);
    //    Pasting = false;
    //}

    private async void LoadDataMenuFromDataBase(string companyName)
    {
        try
        {
            try { Ssm.ShowWaitForm(); Ssm.SetWaitFormDescription("Loading Data..."); } catch { }
            UnitDataAccess uda = new();
            var DataSourceMenu = await uda.GetAllAsyncByCompanyName(companyName);

            DataSourceMenu = DataSourceMenu.OrderBy(x => x.Uf).ThenBy(x => x.Operator).ThenBy(x => x.Company).ThenBy(x => x.Unit).ToList();

            gv_Main.BeginDataUpdate();
            gc_Main.DataSource = DataSourceMenu;
            gv_Main.EndDataUpdate();
            gv_Main.BestFitColumns();

            if (gv_Main.RowCount > 0) { gv_Main.FocusedRowHandle = 0; }
            gv_Main.Focus();
        }
        catch (Exception ex)
        {
            gc_Main.DataSource = null;
            try { Ssm.CloseWaitForm(); } catch { }
            XtraMessageBox.Show(ex.Message, "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        finally
        {
            try { Ssm.CloseWaitForm(); } catch { }
        }
    }

    private void ColumnDefinitions()
    {
        gcol_UnitId.Visible = false;
        gcol_Uf.OptionsColumn.AllowEdit = false;
        gcol_Uf.OptionsColumn.ReadOnly = true;
        gcol_Company.OptionsColumn.AllowEdit = false;
        gcol_Company.OptionsColumn.ReadOnly = true;
        gcol_Operator.OptionsColumn.AllowEdit = false;
        gcol_Operator.OptionsColumn.ReadOnly = true;
        gcol_Unit.OptionsColumn.AllowEdit = false;
        gcol_Unit.OptionsColumn.ReadOnly = true;
    }

    private async void btn_LoadData_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
        var dmfgv = gv_Main.GetFocusedRow() as VMUnitMenu;
        await RefreshResume(ObjectId.Parse(dmfgv.UnitId));
        btn_GenerateOrder.Select();
    }

    private async void gv_Main_DoubleClick(object sender, EventArgs e)
    {
        DXMouseEventArgs ea = e as DXMouseEventArgs;
        GridView view = sender as GridView;
        GridHitInfo info = view.CalcHitInfo(ea.Location);
        if (info.InRow || info.InRowCell)
        {
            var dmfgv = gv_Main.GetFocusedRow() as VMUnitMenu;
            await RefreshResume(ObjectId.Parse(dmfgv.UnitId));
            btn_GenerateOrder.Select();
        }
    }

    private async void gv_Main_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == System.Windows.Forms.Keys.Enter)
        {
            var dmfgv = gv_Main.GetFocusedRow() as VMUnitMenu;
            await RefreshResume(ObjectId.Parse(dmfgv.UnitId));
            btn_GenerateOrder.Select();
        }
        else if (e.KeyCode == System.Windows.Forms.Keys.Escape)
        {
            cmb_Search.Select();
        }
    }

    private async Task RefreshResume(ObjectId unitId)
    {
        try
        {
            ClearComponents();
            //labelControl1.Select();
            try { Ssm.ShowWaitForm(); Ssm.SetWaitFormDescription("Loading Unit..."); } catch { }

            CurrentUnit = await new UnitDataAccess().GetAsync(unitId);
            CurrentCompany = await new CompanyDataAccess().GetAsync(CurrentUnit.Company);
            CurrentOperator = await new OperatorDataAccess().GetAsync(CurrentUnit.Uf, CurrentUnit.Operator);
            lbl_Operator.Text = $"{CurrentOperator.Uf} > {CurrentOperator.Name}";
            lbl_Company.Text = CurrentCompany.Name;
            lbl_Unit.Text = CurrentUnit.Name;
            lbl_CNPJ.Text = Tools.TreatCNPJ(CurrentUnit.Cnpj);
            txt_Username.Text = CurrentUnit.Username;
            txt_Password.Text = CurrentUnit.Password;
            txt_Url.Text = CurrentOperator.Url;
            lbl_ResponsibleGVT.Text = CurrentCompany.ResponsibleGVT;
            lbl_ResponsibleTI.Text = CurrentCompany.ResponsibleTI;
            lbl_Margin.Text = CurrentCompany.Margin.ToString();
            mmo_OperatorNotes.Text = CurrentOperator.Notes;
            mmo_CompanyNotes.Text = CurrentCompany.Notes;
            //mmo_UnitNotes.Text = CurrentUnit.Notes;
            btn_GenerateOrder.Enabled = CurrentOperator.GenerateOrder;
            nvp_Details.PageEnabled = true;
            nvf_Main.SelectedPage = nvp_Details;
        }
        catch (Exception ex)
        {
            try { Ssm.CloseWaitForm(); } catch { }
            XtraMessageBox.Show(ex.Message, "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        finally
        {
            try { Ssm.CloseWaitForm(); } catch { }
        }
    }

    private void ClearComponents()
    {
        nvp_Details.PageEnabled = false;
        lbl_Operator.Text = "";
        lbl_Company.Text = "";
        lbl_Unit.Text = "";
        lbl_CNPJ.Text = "";
        txt_Username.Text = "";
        txt_Password.Text = "";
        lbl_ResponsibleGVT.Text = "";
        lbl_ResponsibleTI.Text = "";
        txt_Url.Text = "";
        lbl_Margin.Text = "";
        btn_GenerateOrder.Enabled = false;
    }

    private void btn_Resume_CopyUsername_Click(object sender, EventArgs e)
    {
        try { clipboard.text = txt_Username.Text; } catch { }
    }

    private void btn_Resume_CopyPassword_Click(object sender, EventArgs e)
    {
        try { clipboard.text = txt_Password.Text; } catch { }
    }

    private async void btn_Resume_SavePassword_Click(object sender, EventArgs e)
    {
        try
        {
            if (CurrentUnit is not null)
            {
                string password = txt_Password.Text.Trim();
                UnitDataAccess uc = new();
                var result = await uc.UpdatePasswordAsync(new MUnit()
                {
                    Username = CurrentUnit.Username,
                    Password = password,
                    Company = CurrentUnit.Company,
                    Operator = CurrentUnit.Operator,
                    Uf = CurrentUnit.Uf,
                });

                if (result.Success)
                {
                    await DiscordWebhook.SendMessage(Settings.DiscordWebhookUrl, new MDiscordWebhook() { Username = $"GCScript Benefits", Content = $"**{SettingsDB.MongoDbUsername}** alterou a senha de **{CurrentUnit.Uf}** > **{CurrentUnit.Operator}** > **{CurrentUnit.Company}** > **{CurrentUnit.Name}** para ||{password}||" });
                    XtraMessageBox.Show($"{result.Count} senhas foram atualizadas!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    CurrentUnit.Password = password;
                    btn_SavePassword.Enabled = false;
                }
                else
                {
                    throw new Exception(result.Message);
                }
            }
            else
            {
                throw new Exception("Não foi possível atualizar a senha!");
            }
        }
        catch (Exception ex)
        {
            txt_Password.Select();
            XtraMessageBox.Show(ex.Message, "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    private void btn_Resume_GoToUrl_Click(object sender, EventArgs e)
    {
        Process.Start(new ProcessStartInfo(txt_Url.Text) { UseShellExecute = true });
    }

    private void btn_Resume_CopyUrl_Click(object sender, EventArgs e)
    {
        try { clipboard.text = txt_Url.Text; } catch { }
    }

    private void txt_Password_EditValueChanged(object sender, EventArgs e)
    {
        string password = txt_Password.Text.Trim();
        btn_SavePassword.Enabled = password.Length > 0 && password != CurrentUnit.Password;
    }

    private void btn_GenerateOrder_Click(object sender, EventArgs e)
    {
        try
        {
            Tools.RemoveOrderFiles();
            string id = CurrentOperator.Id.ToString();

            if (id == "6518bffd8427d5df54abffe3") // RJ - RIOCARD
            {
                if (XtraMessageBox.Show(
                    "Selecione e Copie as colunas na ORDEM abaixo:\nMat (PRIMEIRA COLUNA) | Compra Final (ÚLTIMA COLUNA)\nDeseja continuar",
                    "GCScript Benefits",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No) { return; }

                var go = new OperatorRJRiocard().GenerateOrder(CurrentUnit.Cnpj, Clipboard.GetText());
                File.WriteAllText(Settings.TxtOrderFilePath, go);
            }
            else if (id == "6518bffd8427d5df54abffe4") // RIOCARD - PRA VOCE
            {
                if (XtraMessageBox.Show(
                    "Selecione e Copie as colunas na ORDEM abaixo:\nMat (PRIMEIRA COLUNA) | Compra Final (ÚLTIMA COLUNA)\nDeseja continuar",
                    "GCScript Benefits",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No) { return; }

                var go = new OperatorRJRiocard().GenerateOrder(CurrentUnit.Cnpj, Clipboard.GetText());
                File.WriteAllText(Settings.TxtOrderFilePath, go);
            }
            else if (id == "6518bffd8427d5df54abffe5") // RJ - SETRANSOL
            {
                if (XtraMessageBox.Show(
                    "Selecione e Copie as colunas na ORDEM abaixo:\nCPF (PRIMEIRA COLUNA) | Compra Final (ÚLTIMA COLUNA)\nDeseja continuar",
                    "GCScript Benefits",
                    System.Windows.Forms.MessageBoxButtons.YesNo,
                    System.Windows.Forms.MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No) { return; }

                var go = new OperatorRJSetransol().GenerateOrder(Clipboard.GetText());
                File.WriteAllText(Settings.TxtOrderFilePath, go);
            }
            else
            {
                throw new Exception("Operadora não suportada!");
            }

            XtraMessageBox.Show("Pedido gerado com sucesso!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    private void lbl_Unit_TextChanged(object sender, EventArgs e)
    {
        if (CurrentOperator is null || CurrentCompany is null || CurrentUnit is null) { return; }

        var uf = CurrentOperator.Uf;
        var @operator = CurrentOperator.Name;
        var company = CurrentCompany.Name;
        var unit = CurrentUnit.Name;

        if (string.IsNullOrEmpty(uf)
         || string.IsNullOrWhiteSpace(uf)
         || string.IsNullOrEmpty(@operator)
         || string.IsNullOrWhiteSpace(@operator)
         || string.IsNullOrEmpty(company)
         || string.IsNullOrWhiteSpace(company)
         || string.IsNullOrEmpty(unit)
         || string.IsNullOrWhiteSpace(unit))
        {
            txt_Resume.Text = "";
            txt_BankSlip.Text = "";
        }
        else
        {
            var @base = $"{uf} - {@operator} - {company}";
            var resume = company == unit ? $"{@base} - Resumo" : $"{@base} - {unit} - Resumo";
            var bankSlip = company == unit ? $"{@base} - Boleto" : $"{@base} - {unit} - Boleto";

            txt_Resume.Text = resume;
            txt_BankSlip.Text = bankSlip;
        }
    }

    private void ddbtn_CopyResume_Click(object sender, EventArgs e)
    {
        try { clipboard.text = txt_Resume.Text; } catch { }
    }

    private void ddbtn_CopyBankSlip_Click(object sender, EventArgs e)
    {
        try { clipboard.text = txt_BankSlip.Text; } catch { }
    }

    private void lbl_Company_TextChanged(object sender, EventArgs e)
    {
        if (!string.IsNullOrWhiteSpace(CurrentCompany.ImageUrl)) { pic_CompanyLogo.LoadAsync(CurrentCompany.ImageUrl); }
        else { pic_CompanyLogo.LoadAsync("https://i.imgur.com/5Abs9eR.png"); }
    }

    private void lbl_Company_Click(object sender, EventArgs e)
    {
        try { clipboard.text = lbl_Company.Text; } catch { }
    }

    private void lbl_Operator_Click(object sender, EventArgs e)
    {
        try { clipboard.text = lbl_Operator.Text; } catch { }
    }

    private void lbl_Unit_Click(object sender, EventArgs e)
    {
        try { clipboard.text = lbl_Unit.Text; } catch { }
    }

    private void lbl_CNPJ_Click(object sender, EventArgs e)
    {
        try { clipboard.text = lbl_CNPJ.Text; } catch { }
    }


    private void lbl_ResponsibleGVT_Click(object sender, EventArgs e)
    {
        string greeting = DateTime.Now.Hour switch
        {
            >= 0 and < 12 => "Bom dia",
            >= 12 and < 18 => "Boa tarde",
            _ => "Boa noite",
        };
        try { clipboard.text = $"{greeting}, {lbl_ResponsibleGVT.Text}!\nSegue anexo o(s) arquivo(s) da {lbl_Company.Text}.\nObrigado!"; } catch { }
    }

    private void btn_Return_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        ClearComponents();
        nvf_Main.SelectedPage = nvp_Main;
        gv_Main.Focus();
    }

    private async void btn_Refresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        await RefreshResume(CurrentUnit.Id);
    }

    private void btn_Search_Click(object sender, EventArgs e)
    {
        if (cmb_Search.Text.Length > 0) { LoadDataMenuFromDataBase(cmb_Search.Text); }
    }

    private void cmb_Search_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13) { btn_Search_Click(sender, e); }
    }

    private void btn_Create_Unit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        new frm_Unit().ShowDialog();
    }

    private void btn_Sheets_Dados_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        SalvarPlanilha("dados");
    }

    private void btn_Sheets_Escala_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        Process.Start(new ProcessStartInfo(Settings.EscalaSheetPath) { UseShellExecute = true });
    }

    private void btn_Sheets_Saldo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        SalvarPlanilha("saldos");
    }

    private void btn_T1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {


    }

    private void mmo_OperatorNotes_EditValueChanged(object sender, EventArgs e)
    {
        string currentNotes = string.IsNullOrWhiteSpace(CurrentOperator.Notes) ? "" : CurrentOperator.Notes;
        string newNotes = string.IsNullOrWhiteSpace(mmo_OperatorNotes.Text.Trim()) ? "" : mmo_OperatorNotes.Text.Trim();
        btn_SaveOperatorNotes.Enabled = newNotes != currentNotes;
    }

    private void mmo_CompanyNotes_EditValueChanged(object sender, EventArgs e)
    {
        string currentNotes = string.IsNullOrWhiteSpace(CurrentCompany.Notes) ? "" : CurrentCompany.Notes;
        string newNotes = string.IsNullOrWhiteSpace(mmo_CompanyNotes.Text.Trim()) ? "" : mmo_CompanyNotes.Text.Trim();
        btn_SaveCompanyNotes.Enabled = newNotes != currentNotes;
    }

    private async void btn_SaveOperatorNotes_Click(object sender, EventArgs e)
    {
        try
        {
            string notes = mmo_OperatorNotes.Text.Trim();
            OperatorDataAccess odc = new();
            if (await odc.UpdateNotesAsync(new MOperator() { Id = CurrentOperator.Id, Notes = string.IsNullOrWhiteSpace(notes) ? null : notes }))
            {
                CurrentOperator.Notes = notes;
                btn_SaveOperatorNotes.Enabled = false;
                mmo_OperatorNotes.Focus();
                XtraMessageBox.Show("Anotação salvar com sucesso!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else { throw new Exception(); }
        }
        catch
        {
            XtraMessageBox.Show("Não foi possível salvar a anotação!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    private async void btn_SaveCompanyNotes_Click(object sender, EventArgs e)
    {
        try
        {
            var notes = mmo_CompanyNotes.Text.Trim();
            CompanyDataAccess cda = new();
            if (await cda.UpdateNotesAsync(new MCompany() { Id = CurrentCompany.Id, Notes = string.IsNullOrWhiteSpace(notes) ? null : notes }))
            {
                CurrentCompany.Notes = notes;
                btn_SaveCompanyNotes.Enabled = false;
                mmo_CompanyNotes.Focus();
                XtraMessageBox.Show("Anotação salvar com sucesso!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            else { throw new Exception(); }
        }
        catch
        {
            XtraMessageBox.Show("Não foi possível salvar a anotação!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    private void tablePanel4_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
    {

    }

    private void btn_RiocardBalanceTools_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        new frm_RiocardBalanceTools().ShowDialog();
    }


    //private async void btn_SaveUnitNotes_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string notes = mmo_UnitNotes.Text.Trim();
    //        UnitDataAccess uda = new();
    //        if (await uda.UpdateNotesAsync(new MUnit() { Id = CurrentUnit.Id, Notes = string.IsNullOrWhiteSpace(notes) ? null : notes }))
    //        {
    //            CurrentUnit.Notes = notes;
    //            btn_SaveUnitNotes.Enabled = false;
    //            mmo_UnitNotes.Focus();
    //            XtraMessageBox.Show("Anotação salvar com sucesso!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
    //        }
    //        else { throw new Exception(); }
    //    }
    //    catch
    //    {
    //        XtraMessageBox.Show("Não foi possível salvar a anotação!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
    //    }
    //}
}
