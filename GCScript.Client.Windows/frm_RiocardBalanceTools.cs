using DevExpress.XtraEditors;
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
        public string RiocardFilePath { get; set; }
        public string SatFilePath { get; set; }

        public frm_RiocardBalanceTools()
        {
            InitializeComponent();
        }

        private void frm_RiocardBalanceTools_Load(object sender, EventArgs e)
        {
            btn_SelectRiocardFile.Select();
        }

        private void btn_SelectRiocardFile_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Title = "Selecione os Dados da Riocard",
                Filter = "Arquivo de Texto|*.txt",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
            };

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            RiocardFilePath = dlg.FileName;
            txt_RiocardFilePath.Text = Path.GetFileName(RiocardFilePath);
        }

        private void btn_SelectSatFile_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog()
            {
                Title = "Selecione os Saldos da SAT",
                Filter = "Arquivo CSV|*.csv",
                Multiselect = false,
                CheckFileExists = true,
                CheckPathExists = true,
            };

            if (dlg.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            SatFilePath = dlg.FileName;
            txt_SatFilePath.Text = Path.GetFileName(SatFilePath);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                var mrbList = new List<MRiocardBalance>();
                var msbList = new List<MSatBalance>();

                var riocardFileRows = File.ReadAllLines(RiocardFilePath);
                var satFileRows = File.ReadAllLines(SatFilePath);

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

                var sfd = new XtraSaveFileDialog()
                {
                    Title = "Salvar Arquivo de Saldos",
                    Filter = "Arquivo de Texto|*.txt",
                    FileName = $"_RIOCARD [{DateTime.Now:yyyy-MM-dd}].txt",
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
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "GCScript Benefits", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            if (!File.Exists(RiocardFilePath) || !File.Exists(SatFilePath))
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