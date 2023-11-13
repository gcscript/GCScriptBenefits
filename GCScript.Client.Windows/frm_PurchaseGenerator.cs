using DevExpress.XtraEditors;
using GCScript.Core;
using GCScript.Shared.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace GCScript.Client.Windows;

public partial class frm_PurchaseGenerator : DevExpress.XtraEditors.XtraForm
{
    public frm_PurchaseGenerator()
    {
        InitializeComponent();
    }

    private async void btn_Start_Click(object sender, EventArgs e)
    {
        await Task.Run(() =>
        {
            var data1 = SpreadSheet.Read(@"D:\Empresas\Mex Beneficios\Teste\Dados CAPITAL.xlsx");
            // Save Json File
            var json1 = JsonSerializer.Serialize(data1);
            File.WriteAllText(@"D:\Empresas\Mex Beneficios\Teste\Dados CAPITAL----------.json", json1);

            // Read Json File
            var json2 = File.ReadAllText(@"D:\Empresas\Mex Beneficios\Teste\Dados CAPITAL----------.json");
            var data2 = JsonSerializer.Deserialize<List<MColumn>>(json2);
            SpreadSheet.Treat(data2).Wait();
            SpreadSheet.Write(data2, @"D:\Empresas\Mex Beneficios\Teste\Dados CAPITAL----------.xlsx");
        });


        XtraMessageBox.Show("Feito!");
    }
}