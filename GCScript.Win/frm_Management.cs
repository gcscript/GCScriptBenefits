﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using GCScript.Shared.Models.Management;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GCScript.Win;

public partial class frm_Management : DevExpress.XtraEditors.XtraForm
{
    public List<MDataSourceData> DataSourceData { get; set; }
    public List<MDataSourceBalance> DataSourceBalance { get; set; }

    public frm_Management()
    {
        InitializeComponent();
    }

    private async void btn_ImportData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        frm_ManagementWizard frm = new();
        frm.ShowDialog();

        return;
        var text = await File.ReadAllTextAsync("C:\\Users\\GCScript\\Desktop\\_PurchaseFile_2023-08-24_22-20-07.json");
        var json = JsonSerializer.Deserialize<List<MImportData>>(text);

        DataSourceData = new();

        foreach (var item in json)
        {
            MDataSourceData data = new();
            data.ArquivoDeCompra = item.ArquivoDeCompra;
            data.CNPJ = item.CNPJ;
            data.UF = item.UF;
            data.Operadora = item.Operadora;
            data.Empresa = item.Empresa;
            data.Unidade = item.Unidade;
            data.Departamento = item.Departamento;
            data.Escala = item.Escala;
            data.ID = item.ID;
            data.Matricula = item.Matricula;
            data.MatriculaSite = item.MatriculaSite;
            data.Nome = item.Nome;
            data.CPF = item.CPF;
            data.RG = item.RG;
            data.DataDeNascimento = item.DataDeNascimento;
            data.DVT = item.DVT;
            data.QVT = item.QVT;
            data.VVT = item.VVT;
            data.OBS = item.OBS;
            DataSourceData.Add(data);
        }

        DataSourceData = DataSourceData.OrderBy(x => x.ArquivoDeCompra)
                                       .ThenBy(x => x.UF)
                                       .ThenBy(x => x.Operadora)
                                       .ThenBy(x => x.Empresa)
                                       .ThenBy(x => x.Unidade)
                                       .ThenBy(x => x.Departamento)
                                       .ThenBy(x => x.Nome)
                                       .ToList();
        //DataSourceData = DataSourceData.OrderBy(x => x.Nome).ToList();

        gv_Main.BeginDataUpdate();
        gc_Main.DataSource = DataSourceData;
        gv_Main.EndDataUpdate();
    }

    private async void simpleButton1_Click(object sender, EventArgs e)
    {


    }

    private void simpleButton2_Click(object sender, EventArgs e)
    {


    }

    private void SomaseTotal()
    {
        Dictionary<string, decimal> totalByCore = new();

        for (int i = 0; i < gv_Main.RowCount; i++)
        {
            string arquivoDeCompra = gv_Main.GetRowCellDisplayText(i, gcol_ArquivoDeCompra);
            string cnpj = gv_Main.GetRowCellDisplayText(i, gcol_CNPJ);
            string cpf = gv_Main.GetRowCellDisplayText(i, gcol_CPF);
            string operadora = gv_Main.GetRowCellDisplayText(i, gcol_Operadora);
            decimal tvt = Convert.ToDecimal(gv_Main.GetRowCellValue(i, gcol_STVT));
            string core = $"{arquivoDeCompra}|{cnpj}|{cpf}|{operadora}";

            if (!totalByCore.ContainsKey(core))
            {
                totalByCore[core] = tvt;
            }
            else
            {
                totalByCore[core] += tvt;
            }

        }

        if (totalByCore.Count == 0) { return; }

        List<string> coreComTotal = new();

        for (int i = 0; i < gv_Main.RowCount; i++)
        {
            string arquivoDeCompra = gv_Main.GetRowCellDisplayText(i, gcol_ArquivoDeCompra);
            string cnpj = gv_Main.GetRowCellDisplayText(i, gcol_CNPJ);
            string cpf = gv_Main.GetRowCellDisplayText(i, gcol_CPF);
            string operadora = gv_Main.GetRowCellDisplayText(i, gcol_Operadora);
            decimal tvt = Convert.ToDecimal(gv_Main.GetRowCellValue(i, gcol_STVT));
            string core = $"{arquivoDeCompra}|{cnpj}|{cpf}|{operadora}";

            if (!coreComTotal.Contains(core))
            {
                gv_Main.SetRowCellValue(i, gcol_TVT, totalByCore[core]);
                coreComTotal.Add(core);
            }
            else
            {
                gv_Main.SetRowCellValue(i, gcol_TVT, 0);
            }

        }
    }

    private void simpleButton3_Click(object sender, EventArgs e)
    {

    }

    private async void btn_T1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void btn_T2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        // set value in Row 2, Column gcol_Nome = "Gustavo"
        //gv_Main.SetRowCellValue(2, gcol_Nome, "Gustavo");
        gv_Main.SetRowCellValue(2, gcol_TVT, 32);
    }

    private void btn_T3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        SomaseTotal();
        //for (int i = 0; i < gv_Main.RowCount; i++)
        //{
        //    string arquivoDeCompra = gv_Main.GetRowCellValue(i, gcol_ArquivoDeCompra).ToString();
        //    string cnpj = gv_Main.GetRowCellValue(i, gcol_CNPJ).ToString();
        //    string cpf = gv_Main.GetRowCellValue(i, gcol_CPF).ToString();
        //    string operadora = gv_Main.GetRowCellValue(i, gcol_Operadora).ToString();
        //    decimal tvt = Convert.ToDecimal(gv_Main.GetRowCellValue(i, gcol_TVT));
        //    string core = $"{arquivoDeCompra}|{cnpj}|{cpf}|{operadora}";
        //    var teste = gv_Main.GetRow(i) as MTest;
        //    XtraMessageBox.Show(core);

        //}
    }

    private void btn_T4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void btn_T5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        XtraMessageBox.Show($"{DataSourceData[5].TVT}");
    }

    private void btn_T6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {

    }

    private void gv_Main_MouseWheel(object sender, MouseEventArgs e)
    {
        var view = sender as GridView;
        view.CloseEditor();
    }

    private void btn_ImportBalance_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        var fileDialog = new OpenFileDialog
        {
            Filter = "Arquivo de Saldo (*.json)|*.json",
            Title = "Selecione o arquivo de saldo"
        };
        fileDialog.ShowDialog();

        if (string.IsNullOrEmpty(fileDialog.FileName))
        {
            return;
        }

        var text = File.ReadAllText(fileDialog.FileName);
        DataSourceBalance = JsonSerializer.Deserialize<List<MDataSourceBalance>>(text);

        DataSourceBalance = DataSourceBalance.OrderBy(x => x.UF)
                                             .ThenBy(x => x.Operadora)
                                             .ThenBy(x => x.Empresa)
                                             .ThenBy(x => x.Unidade)
                                             .ThenBy(x => x.Nome)
                                             .ToList();

        gv_Balance.BeginDataUpdate();
        gc_Balance.DataSource = DataSourceBalance;
        gv_Balance.EndDataUpdate();
        gv_Balance.BestFitColumns();

        tbc_Main.SelectedTabPage = tbp_Balance;
        XtraMessageBox.Show($"Arquivo de saldo importado com sucesso!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void btn_ImportBalanceSAT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
    {
        //import csv
        var fileDialog = new OpenFileDialog
        {
            Filter = "Arquivo de Saldo (*.csv)|*.csv",
            Title = "Selecione o arquivo de saldo"
        };

        fileDialog.ShowDialog();

        if (string.IsNullOrEmpty(fileDialog.FileName))
        {
            return;
        }

        var text = File.ReadAllText(fileDialog.FileName);


        List<MDataSourceBalanceSAT> dataList = new();

        var lines = text.Split( new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); // Divide o texto em linhas
        foreach (var line in lines)
        {
            var columns = line.Split(','); // Divide a linha em colunas
            string numeroDoCartao = Regex.Replace(columns[1], "[^0-9]", "");
            numeroDoCartao = numeroDoCartao.PadLeft(13, '0');
            numeroDoCartao = Regex.Replace(numeroDoCartao, @"(\d{2})(\d{2})(\d{8})(\d{1})", "$1.$2.$3-$4");
            decimal saldo = decimal.TryParse(columns[3].Replace(".",","), out saldo) ? saldo : 0;
            decimal recargaPendente = decimal.TryParse(columns[5].Replace(".",","), out recargaPendente) ? recargaPendente : 0;

            MDataSourceBalanceSAT data = new();
            data.NumeroDoCartao = numeroDoCartao;
            data.Saldo = saldo;
            data.RecargaPendente = recargaPendente;

            dataList.Add(data);
        }

        // Preencher Saldo e Recarga Pendente de acordo com o número do Cartao
        for (int i = 0; i < gv_Balance.RowCount; i++)
        {
            string nrCartao = gv_Balance.GetRowCellDisplayText(i, gcol_NumeroDoCartao);
            var data = dataList.FirstOrDefault(x => x.NumeroDoCartao == nrCartao);
            if (data != null)
            {
                gv_Balance.SetRowCellValue(i, gcol_Balance_Saldo, data.Saldo);
                gv_Balance.SetRowCellValue(i, gcol_Balance_RecargaPendente, data.RecargaPendente);
            }
            else{
                gv_Balance.SetRowCellValue(i, gcol_Balance_Saldo, 0);
                gv_Balance.SetRowCellValue(i, gcol_Balance_RecargaPendente, 0);
            }
        }

        XtraMessageBox.Show($"Arquivo de saldo importado com sucesso!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Information);

    }
}