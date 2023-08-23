using System.Text;
using System.Text.RegularExpressions;

namespace GCScript.Operator;

internal class MOperatorRJRiocardGenerateOrder
{
    public string Matricula { get; set; }
    public decimal Valor { get; set; }
}

public class OperatorRJRiocard
{
    public (bool Success, string Message, string Result) GenerateOrder(string cnpj, string clipboardData)
    {
        try
        {
            #region TREAT DATA
            List<MOperatorRJRiocardGenerateOrder> orderList = new();
            clipboardData = clipboardData.Trim();
            if (string.IsNullOrEmpty(clipboardData) || string.IsNullOrWhiteSpace(clipboardData)) { return (false, "Clipboard data is empty", string.Empty); }
            if (string.IsNullOrEmpty(cnpj) || string.IsNullOrWhiteSpace(cnpj)) { return (false, "CNPJ is empty", string.Empty); }
            cnpj = Regex.Replace(cnpj, "[^0-9]", "").PadLeft(14, '0');

            string[] dataRows = clipboardData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var dataRow in dataRows)
            {
                var dataColumns = dataRow.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);

                if (string.IsNullOrEmpty(dataColumns.First()?.Trim())
                    || string.IsNullOrWhiteSpace(dataColumns.First()?.Trim())
                    || string.IsNullOrEmpty(dataColumns.Last()?.Trim())
                    || string.IsNullOrWhiteSpace(dataColumns.Last()?.Trim()))
                { continue; }

                var matricula = dataColumns.First().Trim();
                var valor = dataColumns.Last().Replace("R$", "").Trim();
                if (valor == "-") { valor = "0"; }

                var order = new MOperatorRJRiocardGenerateOrder()
                {
                    Matricula = matricula,
                    Valor = dataColumns.Last().Trim() == "-" ? 0 : decimal.Parse(dataColumns.Last().Trim())
                };
                orderList.Add(order);
            }
            #endregion

            #region GENERATE ORDER
            int count = 1;
            decimal total = 0;
            StringBuilder sb = new();

            #region FIRST LINE
            sb.AppendLine($"{count.ToString().PadLeft(5, '0')}01PEDIDO01.00{cnpj}");
            #endregion

            #region BODY
            foreach (var data in orderList)
            {
                if (data.Valor == 0) { continue; }
                count++;
                string matricula = data.Matricula.Trim().PadRight(15, ' ');
                string valor = data.Valor.ToString("0.00").Replace(".", "").Replace(",", "").PadLeft(8, '0');
                sb.AppendLine(count.ToString().PadLeft(5, '0') + "02" + matricula + valor);
                total += data.Valor;
            }
            #endregion

            #region PENULTIMATE LINE
            count++;
            sb.AppendLine(count.ToString().PadLeft(5, '0') + "03" + DateTime.Now.ToString("ddMMyyyy") + "A7777");
            #endregion

            #region LAST LINE
            count++;
            sb.AppendLine(count.ToString().PadLeft(5, '0') + "99" + total.ToString("0.00").Replace(".", "").Replace(",", "").PadLeft(10, '0'));
            #endregion

            return (true, string.Empty, sb.ToString());
            #endregion
        }
        catch (Exception ex)
        {
            return (false, ex.Message, string.Empty);
        }
    }

}
