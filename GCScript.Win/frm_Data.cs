using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraSplashScreen;
using GCScript.DataBase.Controllers;
using GCScript.DataBase.Models;
using GCScript.DataBase.ViewModels;
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
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace GCScript.Win;

public partial class frm_Data : XtraForm
{

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
        rbbc_Details.Minimized = true;
        try
        {
            try { Ssm.ShowWaitForm(); Ssm.SetWaitFormDescription("Loading Companies..."); } catch { }
            CompanyController companyController = new();
            var companies = await companyController.GetAllAsync();
            companies = companies.OrderBy(x => x.Name).ToList();
            foreach (var comp in companies)
            {
                cmb_Search.Properties.Items.Add(comp.Name);
            }
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
        ddbtn_Create.DropDownControl = new DXPopupMenu
        {
            Items = { new DXMenuItem("Unidade", (s, e) => {
                new frm_Unit().ShowDialog();
                //LoadDataMenuFromDataBase();
            }) }
        };

        ddbtn_CopyResume.DropDownControl = new DXPopupMenu
        {
            Items = { new DXMenuItem("Novo", (s, e) => {
                Clipboard.SetText($"{txt_Resume.Text} [NOVO-SEM CARTAO]");
            }), new DXMenuItem("2ª Via", (s, e) => {
                Clipboard.SetText($"{txt_Resume.Text} [2ª VIA]");
            }) }
        };

        ddbtn_CopyBankSlip.DropDownControl = new DXPopupMenu
        {
            Items = { new DXMenuItem("Novo", (s, e) => {
                Clipboard.SetText($"{txt_BankSlip.Text} [NOVO-SEM CARTAO]");
            }), new DXMenuItem("2ª Via", (s, e) => {
                Clipboard.SetText($"{txt_BankSlip.Text} [2ª VIA]");
            }) }
        };

        ddbtn_Sheets.DropDownControl = new DXPopupMenu
        {
            Items = { new DXMenuItem("Dados", (s, e) => {
                SalvarPlanilha("dados");
            }), new DXMenuItem("Escala", (s, e) => {
                Process.Start(new ProcessStartInfo(Settings.EscalaSheetPath) { UseShellExecute = true });
            }), new DXMenuItem("Saldo", (s, e) => {
                SalvarPlanilha("saldos");
            }) }
        };
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

            sfdSalvar.FileName = nome == "dados" ? $"Dados Nome_da_Empresa {Data}" : $"_RIOCARD [{DateTime.Now:dd-MM-yyyy}]";

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
                Pasting = true;
                Clipboard.Clear();
                switch (e.Name)
                {
                    case "DefinirUsername":
                        Clipboard.SetText(txt_Username.Text);
                        break;
                    case "DefinirPassword":
                        Clipboard.SetText(txt_Password.Text);
                        break;
                    case "DefinirResumo":
                        Clipboard.SetText(txt_Resume.Text);
                        break;
                    case "DefinirBoleto":
                        Clipboard.SetText(txt_BankSlip.Text);
                        break;

                    case "DefinirResumoNovo":
                        Clipboard.SetText($"{txt_Resume.Text} [NOVO-SEM CARTAO]");
                        break;
                    case "DefinirBoletoNovo":
                        Clipboard.SetText($"{txt_BankSlip.Text} [NOVO-SEM CARTAO]");
                        break;

                    case "DefinirResumo2Via":
                        Clipboard.SetText($"{txt_Resume.Text} [2ª VIA]");
                        break;
                    case "DefinirBoleto2Via":
                        Clipboard.SetText($"{txt_BankSlip.Text} [2ª VIA]");
                        break;
                    default:
                        break;
                }
                Thread.Sleep(200);
                System.Windows.Forms.SendKeys.Send("^(v)");
                e.Handled = true;
                _ = AllowNHotkey(200);
            }
        }
        catch (Exception)
        {
            Clipboard.Clear();
        }
    }

    private async Task AllowNHotkey(int millisecondsDelay)
    {
        await Task.Delay(millisecondsDelay);
        Pasting = false;
    }

    private async void LoadDataMenuFromDataBase(string companyName)
    {
        try
        {
            try { Ssm.ShowWaitForm(); Ssm.SetWaitFormDescription("Loading Data..."); } catch { }
            DataMenuController dms = new();
            var result = await dms.GetAllAsyncByCompanyName(companyName);

            result = result.OrderBy(x => x.UF).ThenBy(x => x.Operator).ThenBy(x => x.Company).ThenBy(x => x.Unit).ToList();

            gv_Main.BeginDataUpdate();
            gc_Main.DataSource = result;

            foreach (var item in result)
            {
                gv_Main.AddNewRow();
                gv_Main.SetRowCellValue(GridControl.NewItemRowHandle, gcol_UF.FieldName, item.UF);
                gv_Main.SetRowCellValue(GridControl.NewItemRowHandle, gcol_Operator.FieldName, item.Operator);
                gv_Main.SetRowCellValue(GridControl.NewItemRowHandle, gcol_Company.FieldName, item.Company);
                gv_Main.SetRowCellValue(GridControl.NewItemRowHandle, gcol_Unit.FieldName, item.Unit);
                gv_Main.SetRowCellValue(GridControl.NewItemRowHandle, gcol_UnitId.FieldName, item.UnitId);
            }

            gv_Main.EndDataUpdate();
            gv_Main.BestFitColumns();

            if (gv_Main.RowCount > 0) { gv_Main.FocusedRowHandle = 0; }
            gv_Main.Focus();
        }
        finally
        {
            try { Ssm.CloseWaitForm(); } catch { }
        }
    }

    private void ColumnDefinitions()
    {
        gcol_UnitId.Visible = false;
        gcol_UF.OptionsColumn.AllowEdit = false;
        gcol_UF.OptionsColumn.ReadOnly = true;
        gcol_Company.OptionsColumn.AllowEdit = false;
        gcol_Company.OptionsColumn.ReadOnly = true;
        gcol_Operator.OptionsColumn.AllowEdit = false;
        gcol_Operator.OptionsColumn.ReadOnly = true;
        gcol_Unit.OptionsColumn.AllowEdit = false;
        gcol_Unit.OptionsColumn.ReadOnly = true;
    }

    private async void btn_LoadData_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
    {
        var dmfgv = gv_Main.GetFocusedRow() as VMDataMenu;
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
            var dmfgv = gv_Main.GetFocusedRow() as VMDataMenu;
            await RefreshResume(ObjectId.Parse(dmfgv.UnitId));
            btn_GenerateOrder.Select();
        }
    }

    private async void gv_Main_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
    {
        if (e.KeyCode == System.Windows.Forms.Keys.Enter)
        {
            var dmfgv = gv_Main.GetFocusedRow() as VMDataMenu;
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
        Ssm.ShowWaitForm();
        Ssm.SetWaitFormDescription("Loading Unit...");
        try
        {
            ClearComponents();
            nvf_Main.SelectedPage = nvp_Details;

            await GetData(unitId);
            if (CurrentOperator is not null)
            {
                lbl_Operator.Text = $"{CurrentOperator.UF} > {CurrentOperator.Name}";
                lbl_Company.Text = CurrentCompany.Name;
                lbl_Unit.Text = CurrentUnit.Name;
                lbl_CNPJ.Text = Tools.TreatCNPJ(CurrentUnit.CNPJ);
                txt_Username.Text = CurrentUnit.Username;
                txt_Password.Text = CurrentUnit.Password;
                txt_Url.Text = CurrentOperator.Url;
                lbl_ResponsibleGVT.Text = CurrentCompany.ResponsibleGVT;
                lbl_ResponsibleTI.Text = CurrentCompany.ResponsibleTI;
                lbl_Margin.Text = CurrentCompany.Margin.ToString();
                btn_GenerateOrder.Enabled = CurrentOperator.GenerateOrder;
            }
            else
            {
                XtraMessageBox.Show("Não foi possível carregar os dados!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
        }
        finally
        {
            Ssm?.CloseWaitForm();
        }


    }

    private void ClearComponents()
    {
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

    private async Task GetData(ObjectId unitId)
    {
        try
        {
            UnitController uc = new();
            var result = await uc.GetDataAsync(unitId);

            if (result.mOperator is not null)
            {
                CurrentOperator = result.mOperator;
                CurrentUnit = result.mUnit;
                CurrentCompany = result.mCompany;
            }
            else
            {
                throw new Exception("Não foi possível carregar os dados!");
            }
        }
        catch
        {
            CurrentOperator = null;
            CurrentUnit = null;
            CurrentCompany = null;
        }
    }

    private void btn_Resume_CopyUsername_Click(object sender, EventArgs e)
    {
        try { Clipboard.SetText(txt_Username.Text); } catch { }
    }

    private void btn_Resume_CopyPassword_Click(object sender, EventArgs e)
    {
        try { Clipboard.SetText(txt_Password.Text); } catch { }
    }

    private async void btn_Resume_SavePassword_Click(object sender, EventArgs e)
    {
        try
        {
            if (CurrentUnit is not null)
            {
                UnitController uc = new();
                var result = await uc.UpdatePasswordAsync(new MUnit()
                {
                    Username = CurrentUnit.Username,
                    Password = txt_Password.Text,
                    CompanyId = CurrentUnit.CompanyId,
                    OperatorId = CurrentUnit.OperatorId,
                });

                if (result.Success)
                {
                    XtraMessageBox.Show($"{result.Count} senhas foram atualizadas!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                    CurrentUnit.Password = txt_Password.Text;
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
        try { Clipboard.SetText(txt_Url.Text); } catch { }
    }

    private void txt_Password_EditValueChanged(object sender, EventArgs e)
    {
        string password = txt_Password.Text.Trim();
        btn_SavePassword.Enabled = password.Length > 0 && password != CurrentUnit.Password;
    }

    private async void simpleButton4_Click(object sender, EventArgs e)
    {
    }

    private void btn_GenerateOrder_Click(object sender, EventArgs e)
    {
        try
        {
            if (CurrentOperator.Id.ToString() == "64ce595375654feaabb9f81d" || CurrentOperator.Id.ToString() == "64d8ff515f6a7bc64a513f55")
            {
                Tools.RemoveOrderFiles();

                if (XtraMessageBox.Show("Selecione e Copie as colunas na ORDEM abaixo:\nMat (PRIMEIRA COLUNA) | Compra Final (ÚLTIMA COLUNA)\nDeseja continuar", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) == System.Windows.Forms.DialogResult.No) { return; }

                OperatorRJRiocard opRJRiocard = new();
                var generateOrder = opRJRiocard.GenerateOrder(CurrentUnit.CNPJ, Clipboard.GetText());
                if (generateOrder.Success)
                {
                    File.WriteAllText(Settings.TxtOrderFilePath, generateOrder.Result);
                    XtraMessageBox.Show("Pedido gerado com sucesso!", "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                }
                else
                {
                    throw new Exception(generateOrder.Message);
                }
            }
            else
            {
                throw new Exception("Operadora não suportada!");
            }

        }
        catch (Exception ex)
        {
            XtraMessageBox.Show(ex.Message, "GCScript Benefits", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
    }

    private void lbl_Unit_TextChanged(object sender, EventArgs e)
    {
        if (CurrentOperator is null || CurrentCompany is null || CurrentUnit is null) { return; }

        var uf = CurrentOperator.UF;
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
        try { Clipboard.SetText(txt_Resume.Text); } catch { }
    }

    private void ddbtn_CopyBankSlip_Click(object sender, EventArgs e)
    {
        try { Clipboard.SetText(txt_BankSlip.Text); } catch { }
    }

    private void lbl_Company_TextChanged(object sender, EventArgs e)
    {
        svg_CompanyLogo.SvgImage = lbl_Company.Text switch
        {
            "L2R" => Properties.Resources.l2r,
            "CAPITAL" => Properties.Resources.capital,
            _ => Properties.Resources.gcscript,
        };
    }

    private void lbl_Company_Click(object sender, EventArgs e)
    {
        try { Clipboard.SetText(lbl_Company.Text); } catch { }
    }

    private void lbl_Operator_Click(object sender, EventArgs e)
    {
        try { Clipboard.SetText(lbl_Operator.Text); } catch { }
    }

    private void lbl_Unit_Click(object sender, EventArgs e)
    {
        try { Clipboard.SetText(lbl_Unit.Text); } catch { }
    }

    private void lbl_CNPJ_Click(object sender, EventArgs e)
    {
        try { Clipboard.SetText(lbl_CNPJ.Text); } catch { }
    }


    private void lbl_ResponsibleGVT_Click(object sender, EventArgs e)
    {
        string greeting = DateTime.Now.Hour switch
        {
            >= 0 and < 12 => "Bom dia",
            >= 12 and < 18 => "Boa tarde",
            _ => "Boa noite",
        };
        try { Clipboard.SetText($"{greeting}, {lbl_ResponsibleGVT.Text}!\nSegue anexo o(s) arquivo(s) da {lbl_Company.Text}.\nObrigado!"); } catch { }
    }

    private void btn_Return_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
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
}
