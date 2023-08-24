namespace GCScript.Operator;

internal static class OperatorTools
{
    public static List<string[]>? CreateMatrixFromClipboard(string clipboardContent)
    {
        try
        {
            if (string.IsNullOrEmpty(clipboardContent) || string.IsNullOrWhiteSpace(clipboardContent)) { return null; }
            var lines = clipboardContent.Split('\n');
            var matrix = new List<string[]>();
            foreach (var line in lines)
            {
                var row = line.Split('\t');
                // use trim in all cells
                for (var i = 0; i < row.Length; i++) { row[i] = row[i].Trim(); }
                matrix.Add(row);
            }
            return matrix;
        }
        catch { return null; }
    }
}
