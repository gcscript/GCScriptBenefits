using ClosedXML.Excel;
using CpfCnpjLibrary;
using GCScript.Database.MongoDB.DataAccess;
using GCScript.Shared;
using GCScript.Shared.Models;

namespace GCScript.Core
{
    public class SpreadSheet
    {
        public static List<MColumn> Read(string path)
        {
            var wb = new XLWorkbook(path);
            IXLWorksheet? ws = wb.Worksheet(1);

            //var aaa = ws.Column(6).ColumnLetter();
            //var B2 = ws.Cell(2, 2).FormulaA1;
            //var B3 = ws.Cell(3, 2).FormulaR1C1;

            if (ws == null) { throw new Exception("Planilha não encontrada."); }

            List<MColumn> columnList = new();

            if (!ws.RowsUsed().Any()) { throw new Exception("Não há dados na planilha."); }
            if (ws.RowsUsed().Count() < 2) { throw new Exception("Não há dados na planilha."); }

            var lastRowUsed = ws.LastRowUsed().RowNumber();

            // COLUNAS OBRIGATÓRIAS
            var cn = new MColumnNumber();
            cn.Cnpj = ws.FindColumn(ColumnName.Cnpj);
            if (cn.Cnpj == -1) { throw new Exception("Coluna 'CNPJ' não encontrada."); }
            cn.Empresa = ws.FindColumn(ColumnName.Empresa);
            if (cn.Empresa == -1) { throw new Exception("Coluna 'EMPRESA' não encontrada."); }
            cn.Uf = ws.FindColumn(ColumnName.Uf);
            if (cn.Uf == -1) { throw new Exception("Coluna 'UF' não encontrada."); }
            cn.Operadora = ws.FindColumn(ColumnName.Operadora);
            if (cn.Operadora == -1) { throw new Exception("Coluna 'OPERADORA' não encontrada."); }
            cn.Unidade = ws.FindColumn(ColumnName.Unidade);
            if (cn.Unidade == -1) { throw new Exception("Coluna 'UNIDADE' não encontrada."); }
            cn.Nome = ws.FindColumn(ColumnName.Nome);
            if (cn.Nome == -1) { throw new Exception("Coluna 'NOME' não encontrada."); }
            cn.Qvt = ws.FindColumn(ColumnName.Qvt);
            if (cn.Qvt == -1) { throw new Exception("Coluna 'QVT' não encontrada."); }
            cn.Vvt = ws.FindColumn(ColumnName.Vvt);
            if (cn.Vvt == -1) { throw new Exception("Coluna 'VVT' não encontrada."); }

            // COLUNAS OPCIONAIS
            cn.Departamento = ws.FindColumn(ColumnName.Departamento);
            cn.Matricula = ws.FindColumn(ColumnName.Matricula);
            cn.MatriculaSite = ws.FindColumn(ColumnName.MatriculaSite);
            cn.Cpf = ws.FindColumn(ColumnName.Cpf);
            cn.DataDeNascimento = ws.FindColumn(ColumnName.DataDeNascimento);
            cn.Dvt = ws.FindColumn(ColumnName.Dvt);
            cn.Obs = ws.FindColumn(ColumnName.Obs);
            cn.Temp1 = ws.FindColumn(ColumnName.Temp1);
            cn.Temp2 = ws.FindColumn(ColumnName.Temp2);
            cn.Temp3 = ws.FindColumn(ColumnName.Temp3);
            cn.Temp4 = ws.FindColumn(ColumnName.Temp4);
            cn.Temp5 = ws.FindColumn(ColumnName.Temp5);

            for (int i = 2; i < lastRowUsed; i++)
            {
                MColumn column = new();
                column.Cnpj = ws.Cell(i, cn.Cnpj).Value.ToString().ProcessTextDefault();
                column.Empresa = ws.Cell(i, cn.Empresa).Value.ToString().ProcessTextDefault();
                column.Uf = ws.Cell(i, cn.Uf).Value.ToString().ProcessTextDefault();
                column.Operadora = ws.Cell(i, cn.Operadora).Value.ToString().ProcessTextDefault();
                column.Unidade = ws.Cell(i, cn.Unidade).Value.ToString().ProcessTextDefault();
                column.Nome = ws.Cell(i, cn.Nome).Value.ToString().ProcessTextDefault();
                column.Qvt = int.TryParse(ws.Cell(i, cn.Qvt).Value.ToString(), out int qvt) ? qvt : -999999;
                column.Vvt = decimal.TryParse(ws.Cell(i, cn.Vvt).Value.ToString(), out decimal vvt) ? vvt : -999999.99m;
                column.Departamento = cn.Departamento == -1 ? "" : ws.Cell(i, cn.Departamento).Value.ToString().ProcessTextDefault();
                column.Matricula = cn.Matricula == -1 ? "" : ws.Cell(i, cn.Matricula).Value.ToString().ProcessTextDefault();
                column.MatriculaSite = cn.MatriculaSite == -1 ? "" : ws.Cell(i, cn.MatriculaSite).Value.ToString().ProcessTextDefault();
                column.Cpf = cn.Cpf == -1 ? "" : ws.Cell(i, cn.Cpf).Value.ToString().TreatCPF();
                column.Dvt = cn.Dvt == -1 ? 0 : decimal.TryParse(ws.Cell(i, cn.Dvt).Value.ToString(), out decimal dvt) ? dvt : 0;
                column.Obs = cn.Obs == -1 ? "" : ws.Cell(i, cn.Obs).Value.ToString().ProcessTextDefault();
                try { column.DataDeNascimento = cn.DataDeNascimento == -1 ? DateTime.MinValue : ws.Cell(i, cn.DataDeNascimento).GetDateTime(); }
                catch { column.DataDeNascimento = DateTime.MinValue; }
                columnList.Add(column);
            }

            return columnList;
        }

        public static async Task Treat(List<MColumn> data)
        {
            OrdenarDados(data);
            await TratarCnpj(data);

            foreach (var item in data)
            {
                item.Cnpj = Cnpj.Validar(item.Cnpj) ? Cnpj.FormatarComPontuacao(item.Cnpj) : $"ERROR: {item.Cnpj}";
                item.Cpf = Cpf.Validar(item.Cpf) ? Cpf.FormatarComPontuacao(item.Cpf) : $"ERROR: {item.Cpf}";
                item.Tvt = item.Qvt * item.Vvt - item.Dvt;
            }

            SomaseTotal(data);
        }

        private static async Task TratarCnpj(List<MColumn> data)
        {
            var uniqueList = data.GroupBy(x => new { x.Empresa, x.Uf, x.Operadora, x.Unidade }).Select(x => x.First()).ToList();

            UnitDataAccess uda = new();
            foreach (var uniqueItem in uniqueList)
            {
                string result = await uda.GetCnpjAsync(uniqueItem.Uf, uniqueItem.Operadora, uniqueItem.Empresa, uniqueItem.Unidade);
                if (!string.IsNullOrWhiteSpace(result))
                {
                    data.Where(x => x.Uf == uniqueItem.Uf && x.Operadora == uniqueItem.Operadora && x.Empresa == uniqueItem.Empresa && x.Unidade == uniqueItem.Unidade)
                        .ToList()
                        .ForEach(x => x.Cnpj = Cnpj.FormatarComPontuacao(result));
                }
                else
                {
                    data.Where(x => x.Uf == uniqueItem.Uf && x.Operadora == uniqueItem.Operadora && x.Empresa == uniqueItem.Empresa && x.Unidade == uniqueItem.Unidade)
                        .ToList()
                        .ForEach(x => x.Cnpj = "ERROR: CNPJ NAO ENCONTRADO");
                }
            }
        }

        public static void Write(List<MColumn> data, string path)
        {
            var wb = new XLWorkbook();
            IXLWorksheet ws = wb.Worksheets.Add("Dados");
            DefinirTitulos(ws);

            #region DADOS
            for (int i = 0; i < data.Count; i++)
            {
                int row = i + 2;
                ws.Cell(row, ColumnPosition.Cnpj).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Empresa).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Uf).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Operadora).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Unidade).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Departamento).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Matricula).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.MatriculaSite).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Nome).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Cpf).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.DataDeNascimento).Style.NumberFormat.Date();
                ws.Cell(row, ColumnPosition.Dvt).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Qvt).Style.NumberFormat.ZeroDecimalPlaces();
                ws.Cell(row, ColumnPosition.Vvt).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Tvt).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Total).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.RecargaPendente).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Saldo).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.SaldoTotal).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.ValorDias).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Desconto).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Compra).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Parcela1).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Parcela2).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Parcela3).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Parcela4).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.Parcela5).Style.NumberFormat.TwoDecimalPlaces();
                ws.Cell(row, ColumnPosition.NumeroDoCartao).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Obs).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Temp1).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Temp2).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Temp3).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Temp4).Style.NumberFormat.Text();
                ws.Cell(row, ColumnPosition.Temp5).Style.NumberFormat.Text();

                ws.Cell(row, ColumnPosition.Cnpj).Value = data[i].Cnpj;
                ws.Cell(row, ColumnPosition.Empresa).Value = data[i].Empresa;
                ws.Cell(row, ColumnPosition.Uf).Value = data[i].Uf;
                ws.Cell(row, ColumnPosition.Operadora).Value = data[i].Operadora;
                ws.Cell(row, ColumnPosition.Unidade).Value = data[i].Unidade;
                ws.Cell(row, ColumnPosition.Departamento).Value = data[i].Departamento;
                ws.Cell(row, ColumnPosition.Matricula).Value = data[i].Matricula;
                ws.Cell(row, ColumnPosition.MatriculaSite).Value = data[i].MatriculaSite;
                ws.Cell(row, ColumnPosition.Nome).Value = data[i].Nome;
                ws.Cell(row, ColumnPosition.Cpf).Value = data[i].Cpf;
                ws.Cell(row, ColumnPosition.DataDeNascimento).Value = data[i].DataDeNascimento.ToShortDateString();
                ws.Cell(row, ColumnPosition.Dvt).Value = data[i].Dvt;
                ws.Cell(row, ColumnPosition.Qvt).Value = data[i].Qvt;
                ws.Cell(row, ColumnPosition.Vvt).Value = data[i].Vvt;
                ws.Cell(row, ColumnPosition.Tvt).Value = data[i].Tvt;
                ws.Cell(row, ColumnPosition.Total).Value = data[i].Total;
                ws.Cell(row, ColumnPosition.RecargaPendente).Value = data[i].RecargaPendente;
                ws.Cell(row, ColumnPosition.Saldo).Value = data[i].Saldo;
                ws.Cell(row, ColumnPosition.SaldoTotal).Value = data[i].SaldoTotal;
                ws.Cell(row, ColumnPosition.ValorDias).Value = data[i].ValorDias;
                ws.Cell(row, ColumnPosition.Desconto).Value = data[i].Desconto;
                ws.Cell(row, ColumnPosition.Compra).Value = data[i].Compra;
                ws.Cell(row, ColumnPosition.Parcela1).Value = data[i].Parcela1;
                ws.Cell(row, ColumnPosition.Parcela2).Value = data[i].Parcela2;
                ws.Cell(row, ColumnPosition.Parcela3).Value = data[i].Parcela3;
                ws.Cell(row, ColumnPosition.Parcela4).Value = data[i].Parcela4;
                ws.Cell(row, ColumnPosition.Parcela5).Value = data[i].Parcela5;
                ws.Cell(row, ColumnPosition.NumeroDoCartao).Value = data[i].NumeroDoCartao;
                ws.Cell(row, ColumnPosition.Obs).Value = data[i].Obs;
                ws.Cell(row, ColumnPosition.Temp1).Value = data[i].Temp1;
                ws.Cell(row, ColumnPosition.Temp2).Value = data[i].Temp2;
                ws.Cell(row, ColumnPosition.Temp3).Value = data[i].Temp3;
                ws.Cell(row, ColumnPosition.Temp4).Value = data[i].Temp4;
                ws.Cell(row, ColumnPosition.Temp5).Value = data[i].Temp5;
            }
            #endregion

            wb.SaveAs(path);
        }

        private static void OrdenarDados(List<MColumn> data)
        {
            data.OrderBy(x => x.Empresa)
                .ThenBy(x => x.Uf)
                .ThenBy(x => x.Operadora)
                .ThenBy(x => x.Unidade)
                .ThenBy(x => x.Departamento)
                .ThenBy(x => x.Nome)
                .ToList();
        }

        private static void DefinirTitulos(IXLWorksheet ws)
        {
            ws.Cell(1, ColumnPosition.Cnpj).Value = ColumnName.Cnpj;
            ws.Cell(1, ColumnPosition.Empresa).Value = ColumnName.Empresa;
            ws.Cell(1, ColumnPosition.Uf).Value = ColumnName.Uf;
            ws.Cell(1, ColumnPosition.Operadora).Value = ColumnName.Operadora;
            ws.Cell(1, ColumnPosition.Unidade).Value = ColumnName.Unidade;
            ws.Cell(1, ColumnPosition.Departamento).Value = ColumnName.Departamento;
            ws.Cell(1, ColumnPosition.Matricula).Value = ColumnName.Matricula;
            ws.Cell(1, ColumnPosition.MatriculaSite).Value = ColumnName.MatriculaSite;
            ws.Cell(1, ColumnPosition.Nome).Value = ColumnName.Nome;
            ws.Cell(1, ColumnPosition.Cpf).Value = ColumnName.Cpf;
            ws.Cell(1, ColumnPosition.DataDeNascimento).Value = ColumnName.DataDeNascimento;
            ws.Cell(1, ColumnPosition.RG).Value = ColumnName.RG;
            ws.Cell(1, ColumnPosition.Dvt).Value = ColumnName.Dvt;
            ws.Cell(1, ColumnPosition.Qvt).Value = ColumnName.Qvt;
            ws.Cell(1, ColumnPosition.Vvt).Value = ColumnName.Vvt;
            ws.Cell(1, ColumnPosition.Tvt).Value = ColumnName.Tvt;
            ws.Cell(1, ColumnPosition.Total).Value = ColumnName.Total;
            ws.Cell(1, ColumnPosition.RecargaPendente).Value = ColumnName.RecargaPendente;
            ws.Cell(1, ColumnPosition.Saldo).Value = ColumnName.Saldo;
            ws.Cell(1, ColumnPosition.SaldoTotal).Value = ColumnName.SaldoTotal;
            ws.Cell(1, ColumnPosition.ValorDias).Value = ColumnName.ValorDias;
            ws.Cell(1, ColumnPosition.Desconto).Value = ColumnName.Desconto;
            ws.Cell(1, ColumnPosition.Compra).Value = ColumnName.Compra;
            ws.Cell(1, ColumnPosition.Parcela1).Value = ColumnName.Parcela1;
            ws.Cell(1, ColumnPosition.Parcela2).Value = ColumnName.Parcela2;
            ws.Cell(1, ColumnPosition.Parcela3).Value = ColumnName.Parcela3;
            ws.Cell(1, ColumnPosition.Parcela4).Value = ColumnName.Parcela4;
            ws.Cell(1, ColumnPosition.Parcela5).Value = ColumnName.Parcela5;
            ws.Cell(1, ColumnPosition.NumeroDoCartao).Value = ColumnName.NumeroDoCartao;
            ws.Cell(1, ColumnPosition.Obs).Value = ColumnName.Obs;
            ws.Cell(1, ColumnPosition.Temp1).Value = ColumnName.Temp1;
            ws.Cell(1, ColumnPosition.Temp2).Value = ColumnName.Temp2;
            ws.Cell(1, ColumnPosition.Temp3).Value = ColumnName.Temp3;
            ws.Cell(1, ColumnPosition.Temp4).Value = ColumnName.Temp4;
            ws.Cell(1, ColumnPosition.Temp5).Value = ColumnName.Temp5;
        }

        private static void SomaseTotal(List<MColumn> data)
        {
            Dictionary<string, decimal> totalByCore = new();

            for (int i = 0; i < data.Count; i++)
            {
                string cnpj = data[i].Cnpj;
                string cpf = data[i].Cpf;
                string operadora = data[i].Operadora;
                decimal tvt = data[i].Tvt;
                string core = $"{cnpj}|{cpf}|{operadora}";

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

            for (int i = 0; i < data.Count; i++)
            {

                string cnpj = data[i].Cnpj;
                string cpf = data[i].Cpf;
                string operadora = data[i].Operadora;
                decimal tvt = data[i].Tvt;
                string core = $"{cnpj}|{cpf}|{operadora}";

                if (!coreComTotal.Contains(core))
                {
                    data[i].Total = totalByCore[core];
                    coreComTotal.Add(core);
                }
                else
                {
                    data[i].Total = 0;
                }

            }
        }
    }
}
