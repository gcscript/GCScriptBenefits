using GCScript.DataBase;
using GCScript.DataBase.Controllers;
using GCScript.DataBase.Models;
using GCScript.Shared;
using GCScript.Shared.Models.Management;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GCScript.Win;
public partial class frm_ManagementWizard : DevExpress.XtraEditors.XtraForm
{
    List<MOperator> Operators;
    List<MCompany> Companies;


    public frm_ManagementWizard()
    {
        InitializeComponent();
    }

    private void btn_ImportData_SelectFile_Click(object sender, EventArgs e)
    {
        OpenFileDialog fileDialog = new()
        {
            Filter = "Json files (*.json)|*.json",
            Title = "Select a Json File"
        };

        if (fileDialog.ShowDialog() == DialogResult.OK) { txt_ImportData_FilePath.Text = fileDialog.FileName; }
        fileDialog.Dispose();
    }

    private void txt_ImportData_FilePath_EditValueChanged(object sender, EventArgs e)
    {
        btn_ImportData_Next.Enabled = File.Exists(txt_ImportData_FilePath.Text);
    }

    private void btn_ImportData_Next_Click(object sender, EventArgs e)
    {
        tbc_Main.SelectedTabPage = tbp_ImportBalance;
    }

    private void btn_ImportBalance_Back_Click(object sender, EventArgs e)
    {
        tbc_Main.SelectedTabPage = tbp_ImportData;
    }

    private void btn_Home_Next_Click(object sender, EventArgs e)
    {
        tbc_Main.SelectedTabPage = tbp_ImportData;
    }

    private void btn_ImportData_Back_Click(object sender, EventArgs e)
    {
        tbc_Main.SelectedTabPage = tbp_Home;
    }

    private void cmb_Home_Company_SelectedIndexChanged(object sender, EventArgs e)
    {
        btn_Home_Next.Enabled = cmb_Home_Company.Text.Length > 2;
    }

    private async void frm_ManagementImportData_Load(object sender, EventArgs e)
    {
        try
        {
            ssm_Main.ShowWaitForm();
            ssm_Main.SetWaitFormDescription("Carregando Dados...");

            SettingsDB.MongoDbUsername = "";
            SettingsDB.MongoDbPassword = "";
            dte_Home_Start.DateTime = DateTime.Now;
            dte_Home_End.DateTime = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(1).AddDays(-1);

            OperatorController operatorController = new();
            Operators = await operatorController.GetAllAsync();
            Operators = Operators.OrderBy(x => x.UF).ThenBy(x => x.Name).ToList();

            CompanyController companyController = new();
            Companies = await companyController.GetAllAsync();
            Companies = Companies.OrderBy(x => x.Name).ToList();
            foreach (var comp in Companies)
            {
                cmb_Home_Company.Properties.Items.Add(comp.Name);
            }

            if (cmb_Home_Company.Properties.Items.Count > 0)
            {
                cmb_Home_Company.SelectedIndex = 0;
                btn_Home_Next.Enabled = true;
                cmb_Home_Company.Focus();
            }
            else
            {
                btn_Home_Next.Enabled = false;
            }
        }
        catch
        {
            try { ssm_Main.CloseWaitForm(); } catch { }
        }
        finally
        {
            try { ssm_Main.CloseWaitForm(); } catch { }
        }
    }

    private void dte_Home_Start_EditValueChanged(object sender, EventArgs e)
    {
        UpdateNumberOfDays();
    }

    private void dte_Home_End_EditValueChanged(object sender, EventArgs e)
    {
        UpdateNumberOfDays();
    }

    private void UpdateNumberOfDays()
    {
        double days = Math.Ceiling((dte_Home_End.DateTime - dte_Home_Start.DateTime).TotalDays);
        lbl_Home_NumberOfDays.Text = days == 0 ? "Dias: 0" : $"Dias: {days}";
    }

    private void chk_ImportData_CNPJForAll_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_ImportData_CNPJForAll.Checked)
        {
            txt_ImportData_CNPJForAll.Enabled = true;
            txt_ImportData_CNPJForAll.Focus();
        }
        else
        {
            txt_ImportData_CNPJForAll.Enabled = false;
            txt_ImportData_CNPJForAll.Text = "";
        }
    }

    private void chk_ImportData_OperatorForAll_CheckedChanged(object sender, EventArgs e)
    {
        cmb_ImportData_OperatorForAll.Properties.Items.Clear();
        if (chk_ImportData_OperatorForAll.Checked)
        {
            cmb_ImportData_OperatorForAll.Enabled = true;

            foreach (var op in Operators)
            {
                cmb_ImportData_OperatorForAll.Properties.Items.Add($"{op.UF} - {op.Name}");
            }

            if (cmb_ImportData_OperatorForAll.Properties.Items.Count > 0)
            {
                cmb_ImportData_OperatorForAll.SelectedItem = "RJ - RIOCARD";
                cmb_ImportData_OperatorForAll.Focus();
            }
        }
        else
        {
            cmb_ImportData_OperatorForAll.Enabled = false;
        }
    }

    private void btn_ImportBalance_Back_Click_1(object sender, EventArgs e)
    {
        tbc_Main.SelectedTabPage = tbp_ImportData;
    }

    private void btn_ImportBalance_ClearList_Click(object sender, EventArgs e)
    {
        lst_ImportBalance_Files.Items.Clear();
    }

    private void btn_ImportBalance_AddFile_Click(object sender, EventArgs e)
    {
        try
        {
            OpenFileDialog fileDialog = new()
            {
                Filter = "Json files (*.json)|*.json",
                Title = "Select a Json File",
                Multiselect = true
            };

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in fileDialog.FileNames)
                {
                    if (!lst_ImportBalance_Files.Items.Contains(file) && Path.GetExtension(file).ToLower() == ".json")
                    {
                        lst_ImportBalance_Files.Items.Add(file);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            lst_ImportBalance_Files.Items.Clear();
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btn_ImportBalance_Finish_Click(object sender, EventArgs e)
    {
        try
        {
            MManagementWizard model = new()
            {
                Company = cmb_Home_Company.Text,
                PurchaseFilePath = txt_ImportData_FilePath.Text,
                PurchaseStartPeriod = dte_Home_Start.DateTime,
                PurchaseEndPeriod = dte_Home_End.DateTime,
                BalanceFilesPath = lst_ImportBalance_Files.Items.Cast<string>().ToList(),
                CNPJForAll = chk_ImportData_CNPJForAll.Checked ? txt_ImportData_CNPJForAll.Text : "",
                OperatorForAll = chk_ImportData_OperatorForAll.Checked ? cmb_ImportData_OperatorForAll.Text : ""
            };

            Settings.ManagementWizardSettings = model;
            Close();
        }
        catch (Exception ex)
        {
            Settings.ManagementWizardSettings = null;
            DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}