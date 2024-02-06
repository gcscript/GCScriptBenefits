using Au.Types;
using ClosedXML.Excel;
using CpfCnpjLibrary;
using DevExpress.XtraEditors;
using GCScript.Core;
using GCScript.Shared;
using GCScript.Shared.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GCScript.Client.Windows
{
    public partial class frm_RiocardBalanceTools : DevExpress.XtraEditors.XtraForm
    {
        public string FilePath1 { get; set; }
        public string FilePath2 { get; set; }
        public int Mode { get; }

        public frm_RiocardBalanceTools(int mode = 0)
        {
            Mode = mode;
            InitializeComponent();
        }

        private void frm_RiocardBalanceTools_Load(object sender, EventArgs e)
        {
            switch (Mode)
            {
                case 0:
                    lbl_Title1.Text = $"[TXT] Dados <EMPRESA> [{DateTime.Now:yyyy-MM-dd}].txt";
                    lbl_Title2.Text = "[CSV] coletario_mex_##_retorno.csv";
                    chk_1.Visible = false;
                    break;
                case 1:
                    lbl_Title1.Text = $"[TXT] Dados <EMPRESA> [{DateTime.Now:yyyy-MM-dd}].txt";
                    lbl_Title2.Text = $"[XLSX] Dados <EMPRESA> [{DateTime.Now.AddMonths(-1):yyyy-MM-dd}].xlsx (ÚLTIMA COMPRA)";
                    chk_1.Text = "Somente quem teve desconto";
                    break;
                default:
                    break;
            }

            btn_SelectFile1.Select();
        }

        private void btn_SelectFile1_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (Mode == 0)
            {
                dlg.Title = "Selecione os Dados da Riocard";
                dlg.Filter = "Arquivo de Texto|*.txt";
            }
            else if (Mode == 1)
            {
                dlg.Title = "Selecione os Dados da Riocard";
                dlg.Filter = "Arquivo de Texto|*.txt";
            }
            dlg.Multiselect = false;
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            FilePath1 = dlg.FileName;
            txt_FilePath1.Text = Path.GetFileName(FilePath1);
            FilePath2 = "";
            txt_FilePath2.Text = "";
        }

        private void btn_SelectFile2_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            if (Mode == 0)
            {
                dlg.Title = "Selecione os Saldos da SAT";
                dlg.Filter = "Arquivo CSV|*.csv";
            }
            else if (Mode == 1)
            {
                dlg.Title = "Selecione a Planilha Dados da última compra";
                dlg.Filter = "Arquivo XLSX|*.xlsx";
            }
            dlg.Multiselect = false;
            dlg.CheckFileExists = true;
            dlg.CheckPathExists = true;

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            FilePath2 = dlg.FileName;
            txt_FilePath2.Text = Path.GetFileName(FilePath2);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (Mode == 0)
                {
                    SaveMode0();
                }
                else if (Mode == 1)
                {
                    SaveMode1();
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveMode0()
        {
            var mrbList = new List<MRiocardBalance>();
            var msbList = new List<MSatBalance>();

            var riocardFileRows = File.ReadAllLines(FilePath1);
            var satFileRows = File.ReadAllLines(FilePath2);

            if (riocardFileRows.Length < 2) { return; }

            foreach (var satFileRow in satFileRows)
            {
                var msb = new MSatBalance();
                string rowContent = satFileRow.Trim();
                if (string.IsNullOrWhiteSpace(rowContent) || rowContent.Contains("CPF") && rowContent.Contains("SALDO"))
                {
                    continue;
                }

                var rowContentSplitted = rowContent.Split(',');
                if (rowContentSplitted.Length != 6)
                {
                    continue;
                }
                string numeroDoCartao = rowContentSplitted[1].ProcessTextDefault();
                string saldo = rowContentSplitted[3].ProcessTextDefault().Replace(".", ",");
                string recargaPendente = rowContentSplitted[5].ProcessTextDefault().Replace(".", ",");

                if (string.IsNullOrWhiteSpace(numeroDoCartao) || string.IsNullOrWhiteSpace(saldo) || string.IsNullOrWhiteSpace(recargaPendente))
                {
                    continue;
                }

                msb.NumeroDoCartao = numeroDoCartao.TreatRiocardCard();
                msb.Saldo = decimal.TryParse(saldo, out decimal saldoDecimal) ? saldoDecimal : 0;
                msb.RecargaPendente = decimal.TryParse(recargaPendente, out decimal recargaPendenteDecimal) ? recargaPendenteDecimal : 0;

                msbList.Add(msb);

            }

            foreach (var riocardFileRow in riocardFileRows)
            {
                var mrb = new MRiocardBalance();
                string rowContent = riocardFileRow.Trim();
                if (string.IsNullOrWhiteSpace(rowContent) || rowContent.Contains("CNPJ") && rowContent.Contains("BUSCADOR"))
                {
                    continue;
                }

                var rowContentSplitted = rowContent.Split('\t');
                if (rowContentSplitted.Length != 12)
                {
                    continue;
                }

                string cnpj = rowContentSplitted[0].ProcessTextDefault();
                string empresa = rowContentSplitted[1].ProcessTextDefault();
                string buscador = rowContentSplitted[2].ProcessTextDefault();
                string numeroDoCartao = rowContentSplitted[3].ProcessTextDefault();
                string matricula = rowContentSplitted[4].ProcessTextDefault();
                string nome = rowContentSplitted[5].ProcessTextDefault();
                string cpf = rowContentSplitted[6].ProcessTextDefault();
                string status = rowContentSplitted[7].ProcessTextDefault();

                if (mrbList.Any(x => x.NumeroDoCartao == numeroDoCartao)) { continue; }

                mrb.Cnpj = cnpj;
                mrb.Empresa = empresa;
                mrb.Buscador = buscador;
                mrb.NumeroDoCartao = numeroDoCartao;
                mrb.Matricula = matricula;
                mrb.Nome = nome;
                mrb.Cpf = cpf;
                mrb.Status = status;
                mrb.Saldo = msbList.Where(x => x.NumeroDoCartao == numeroDoCartao).Select(x => x.Saldo).FirstOrDefault();
                mrb.RecargaPendente = msbList.Where(x => x.NumeroDoCartao == numeroDoCartao).Select(x => x.RecargaPendente).FirstOrDefault();
                mrb.AttSaldo = DateTime.Now;
                mrb.DataPagamentoRecargaPendente = DateTime.Now;

                mrbList.Add(mrb);
            }

            var sfd = new SaveFileDialog()
            {
                Title = "Salvar Arquivo de Saldos",
                Filter = "Arquivo de Texto|*.txt",
                FileName = $"___RIOCARD [{DateTime.Now:yyyy-MM-dd}].txt",
            };

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var sb = new StringBuilder();
            sb.Append("CNPJ\tEMPRESA\tBUSCADOR\tNR. DO CARTAO\tMAT\tNOME\tCPF\tSTATUS\tSALDO\tATT SALDO\tREC PEND\tDATA PGMT REC PEND");

            foreach (var mrbItem in mrbList)
            {
                sb.AppendLine();
                sb.Append($"{mrbItem.Cnpj}\t{mrbItem.Empresa}\t{mrbItem.Buscador}\t{mrbItem.NumeroDoCartao}\t{mrbItem.Matricula}\t{mrbItem.Nome}\t{mrbItem.Cpf}\t{mrbItem.Status}\t{mrbItem.Saldo.ToString("0.00")}\t{mrbItem.AttSaldo:dd/MM/yyyy}\t{mrbItem.RecargaPendente.ToString("0.00")}\t{mrbItem.DataPagamentoRecargaPendente:dd/MM/yyyy}");
            }

            File.WriteAllText(sfd.FileName, sb.ToString());
            XtraMessageBox.Show("Arquivo de Saldos Gerado com Sucesso!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveMode1()
        {
            var mrbList = new List<MRiocardBalance>();

            var riocardFileRows = File.ReadAllLines(FilePath1);
            if (riocardFileRows.Length < 2) { return; }

            var cpfList = SpreadSheet.GetCpf(FilePath2, chk_1.Checked);

            if (cpfList.Count == 0) { throw new Exception("Nenhum CPF encontrado na Planilha!"); }

            foreach (var riocardFileRow in riocardFileRows)
            {
                var mrb = new MRiocardBalance();
                string rowContent = riocardFileRow.Trim();
                if (string.IsNullOrWhiteSpace(rowContent) || rowContent.Contains("CNPJ") && rowContent.Contains("BUSCADOR"))
                {
                    continue;
                }

                var rowContentSplitted = rowContent.Split('\t');
                if (rowContentSplitted.Length != 12) { continue; }

                string numeroDoCartao = rowContentSplitted[3].ProcessTextDefault().TreatCPF(false);
                if (numeroDoCartao.StartsWith("0000") || numeroDoCartao.StartsWith("0001") || numeroDoCartao.Contains("ERROR")) { continue; }
                if (mrbList.Any(x => x.NumeroDoCartao == numeroDoCartao)) { continue; }

                string cpf = rowContentSplitted[6].ProcessTextDefault();
                if (!Cpf.Validar(cpf)) { continue; }
                cpf = Cpf.FormatarSemPontuacao(cpf);
                if (!cpfList.Contains(cpf)) { continue; }

                mrb.NumeroDoCartao = numeroDoCartao;
                mrb.Cpf = cpf;
                mrbList.Add(mrb);
            }

            var sfd = new SaveFileDialog()
            {
                Title = "Salvar Arquivo CPF-CARTAO SAT",
                Filter = "Arquivo de Texto|*.txt",
                FileName = $"SAT-EMPRESA.txt",
            };

            if (sfd.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var sb = new StringBuilder();
            sb.Append("CPF\tCARTAO\tEMPRESA");

            string nomeDaEmpresa = Path.GetFileNameWithoutExtension(sfd.FileName);

            foreach (var mrbItem in mrbList)
            {
                sb.AppendLine();
                sb.Append($"{mrbItem.Cpf}\t{mrbItem.NumeroDoCartao}\t{nomeDaEmpresa}");
            }

            File.WriteAllText(sfd.FileName, sb.ToString());
            XtraMessageBox.Show("Arquivo CPF-CARTAO Gerado com Sucesso!", "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txt_RiocardFilePath_EditValueChanged(object sender, EventArgs e)
        {
            CheckFileExist();
        }

        private void txt_SatFilePath_EditValueChanged(object sender, EventArgs e)
        {
            CheckFileExist();
        }

        private void CheckFileExist()
        {
            if (!File.Exists(FilePath1) || !File.Exists(FilePath2))
            {
                btn_Save.Enabled = false;
            }
            else
            {
                btn_Save.Enabled = true;
            }
        }
    }
}