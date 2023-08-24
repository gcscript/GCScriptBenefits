using System.Text;
using System.Text.RegularExpressions;

namespace GCScript.Operator;

public class OperatorRJSetransol
{
    public string GenerateOrder(string clipboardData)
    {
        if (string.IsNullOrEmpty(clipboardData) || string.IsNullOrWhiteSpace(clipboardData)) { throw new Exception("Clipboard data is empty"); }
        var matrix = OperatorTools.CreateMatrixFromClipboard(clipboardData);
        if (matrix is null) { throw new Exception("Matrix is null"); }

        StringBuilder sb = new();

        #region FIRST LINE
        sb.AppendLine("REC|1");
        #endregion

        foreach (var row in matrix)
        {
            if (string.IsNullOrEmpty(row.First()?.Trim())
                || string.IsNullOrWhiteSpace(row.First()?.Trim())
                || string.IsNullOrEmpty(row.Last()?.Trim())
                || string.IsNullOrWhiteSpace(row.Last()?.Trim()))
            { continue; }

            var cpf = Regex.Replace(row.First().Trim(), "[^0-9]", "").PadLeft(11, '0');
            string valorTratado = row.Last().Replace("R$", "").Replace("$", "").Trim();
            decimal valor = valorTratado == "-" ? 0 : decimal.Parse(valorTratado);
            if (valor == 0) { continue; }
            string valorFinal = valor.ToString("0.00").Replace(".", "").Replace(",", "");

            #region BODY
            sb.AppendLine($"{cpf}|1|{valorFinal}||");
            #endregion

        }
        return sb.ToString();
    }
}
