﻿using System.Data;
using System.Text;
using System.Text.RegularExpressions;

namespace GCScript.Operator;

public class OperatorRJRiocard
{
    public string GenerateOrder(string cnpj, string clipboardData)
    {
        if (string.IsNullOrEmpty(clipboardData) || string.IsNullOrWhiteSpace(clipboardData)) { throw new Exception("Clipboard data is empty"); }
        var matrix = OperatorTools.CreateMatrixFromClipboard(clipboardData);
        if (matrix is null) { throw new Exception("Matrix is null"); }

        cnpj = Regex.Replace(cnpj, "[^0-9]", "").PadLeft(14, '0');

        StringBuilder sb = new();
        int count = 1;
        decimal total = 0;

        #region FIRST LINE
        sb.AppendLine($"{count.ToString().PadLeft(5, '0')}01PEDIDO01.00{cnpj}");
        #endregion

        foreach (var row in matrix)
        {
            if (string.IsNullOrEmpty(row.First()?.Trim())
                || string.IsNullOrWhiteSpace(row.First()?.Trim())
                || string.IsNullOrEmpty(row.Last()?.Trim())
                || string.IsNullOrWhiteSpace(row.Last()?.Trim()))
            { continue; }

            var matricula = row.First().Trim();
            string valorTratado = row.Last().Replace("R$", "").Replace("$", "").Trim();
            decimal valor = valorTratado == "-" ? 0 : decimal.Parse(valorTratado);

            #region BODY
            if (valor == 0) { continue; }
            count++;
            sb.AppendLine($"{count.ToString().PadLeft(5, '0')}02{matricula.PadRight(15, ' ')}{valor.ToString("0.00").Replace(".", "").Replace(",", "").PadLeft(8, '0')}");
            total += valor;
            #endregion

        }
        #region PENULTIMATE LINE
        count++;
        sb.AppendLine(count.ToString().PadLeft(5, '0') + "03" + DateTime.Now.ToString("ddMMyyyy") + "A7777");
        #endregion

        #region LAST LINE
        count++;
        sb.AppendLine(count.ToString().PadLeft(5, '0') + "99" + total.ToString("0.00").Replace(".", "").Replace(",", "").PadLeft(10, '0'));
        #endregion
        return sb.ToString();
    }
}
