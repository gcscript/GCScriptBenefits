using ClosedXML.Excel;
using GCScript.Shared;

namespace GCScript.Core;

public static class ClosedXmlExtensions
{
    /// <summary>
    /// Retorna o número da coluna.
    /// </summary>
    /// <param name="ws">Worksheet</param>
    /// <param name="title">Título da coluna</param>
    /// <param name="row">Linha onde está o título</param>
    public static int FindColumn(this IXLWorksheet ws, string title, int row = 1)
    {
        title = title.ProcessTextDefault();
        if (row < 1) { row = 1; }
        var lastColumnUsed = ws.LastColumnUsed().ColumnNumber();
        for (int i = 1; i < lastColumnUsed; i++)
        {
            var cellValue = ws.Cell(row, i).Value.ToString().ProcessTextDefault();
            if (cellValue == title) { return i; }
        }
        return -1;
    }

    public static void TwoDecimalPlaces(this IXLNumberFormat nf)
    {
        nf.Format = "_-* #,##0.00_-;\\-* #,##0.00_-;_-* \"-\"??_-;_-@_-";
    }

    public static void ZeroDecimalPlaces(this IXLNumberFormat nf)
    {
        nf.Format = "_-* #,##0_-;\\-* #,##0_-;_-* \"-\"_-;_-@_-";
    }

    public static void Text(this IXLNumberFormat nf)
    {
        nf.Format = "@";
    }

    public static void Date(this IXLNumberFormat nf)
    {
        nf.Format = "dd/mm/yyyy";
    }

    public static void DateTime(this IXLNumberFormat nf)
    {
        nf.Format = "dd/mm/yyyy hh:mm";
    }
}
