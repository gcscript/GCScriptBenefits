using System.Text.RegularExpressions;

namespace GCScript.Shared;

public static class Tools
{
    public static string? TreatCPF(string cpf, bool formatted = true)
    {
        try
        {
            cpf = Regex.Replace(cpf.Trim(), "[^0-9]", "");
            if (string.IsNullOrEmpty(cpf)) return null;
            cpf = cpf.PadLeft(11, '0');
            return formatted ? Regex.Replace(cpf, "([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{2})", "$1.$2.$3-$4") : cpf;
        }
        catch { return null; }
    }

    public static string? TreatCNPJ(string cnpj, bool formatted = true)
    {
        try
        {
            cnpj = Regex.Replace(cnpj.Trim(), "[^0-9]", "");
            if (string.IsNullOrEmpty(cnpj)) return null;
            cnpj = cnpj.PadLeft(14, '0');
            return formatted ? Regex.Replace(cnpj, "([0-9]{2})([0-9]{3})([0-9]{3})([0-9]{4})([0-9]{2})", "$1.$2.$3/$4-$5") : cnpj;
        }
        catch { return null; }
    }

    public static bool RemoveOrderFiles()
    {
        try
        {
            var filenames = new string[] { "ped.txt", "ped.xml" };
            foreach (var filename in filenames)
            {
                var filePath = Path.Combine(Settings.DesktopPath, filename);
                try { if (File.Exists(filePath)) { File.Delete(filePath); } } catch { }
            }
            return true;
        }
        catch { return false; }
    }
}
