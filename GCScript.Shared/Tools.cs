using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace GCScript.Shared;

public enum ETextCase { None, ToLower, ToUpper, ToTitleCase }
public enum ETextType { None, OnlyLetters, OnlyNumbers, OnlyLettersNumbers, OnlyLettersNumbersSpaces }
public enum ETextTrim { None, Trim, TrimStart, TrimEnd }
public enum ETextRemoveSpaces { None, Duplicate, All }

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

    public static string ProcessText(string? text, bool removeAccents, ETextTrim textTrim, ETextCase textCase, ETextType textType, ETextRemoveSpaces removeSpaces)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }

        if (removeAccents) { text = RemoveAccents(text); }

        switch (textTrim)
        {
            case ETextTrim.Trim: { text = text.Trim(); break; }
            case ETextTrim.TrimStart: { text = text.TrimStart(); break; }
            case ETextTrim.TrimEnd: { text = text.TrimEnd(); break; }
        }

        switch (textCase)
        {
            case ETextCase.ToLower: { text = text.ToLower(); break; }
            case ETextCase.ToUpper: { text = text.ToUpper(); break; }
            case ETextCase.ToTitleCase: { text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(text.ToLower()); break; }
        }

        switch (removeSpaces)
        {
            case ETextRemoveSpaces.Duplicate: { text = RemoveDuplicateSpaces(text); break; }
            case ETextRemoveSpaces.All: { text = RemoveSpaces(text); break; }
        }

        switch (textType)
        {
            case ETextType.OnlyLetters: { text = OnlyLetters(text); break; }
            case ETextType.OnlyNumbers: { text = OnlyNumbers(text); break; }
            case ETextType.OnlyLettersNumbers: { text = OnlyLettersNumbers(text); break; }
            case ETextType.OnlyLettersNumbersSpaces: { text = OnlyLettersNumbersSpaces(text); break; }
        }

        return text;
    }

    public static string ProcessTextDefault(string? text)
    {
        if (text == null) return "";
        return ProcessText(text,
                           true,
                           ETextTrim.Trim,
                           ETextCase.ToUpper,
                           ETextType.None,
                           ETextRemoveSpaces.Duplicate);
    }

    public static string RemoveAccents(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        StringBuilder sbReturn = new StringBuilder();
        foreach (char letter in text.Normalize(NormalizationForm.FormD))
        {
            if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                sbReturn.Append(letter);
        }
        return sbReturn.ToString();
    }

    public static string RemoveSpaces(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"\s", "");
        return text;
    }

    public static string RemoveDuplicateSpaces(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"\s+", " ");
        return text;
    }

    public static string OnlyLetters(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"[^a-zA-Z]", "");
        return text;
    }

    public static string OnlyNumbers(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"[^0-9]", "");
        return text;
    }


    public static string OnlyLettersNumbers(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"[^a-zA-Z0-9]", "");
        return text;
    }

    public static string OnlyLettersNumbersSpaces(string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"[^a-zA-Z0-9\s]", "");
        return text;
    }

    public static string? IdentifyWorkSchedule(string? text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return null; }

        text = ProcessText(text, true, ETextTrim.Trim, ETextCase.ToUpper, ETextType.OnlyLettersNumbers, ETextRemoveSpaces.All);

        if (text.Contains("6X1")) { return "06X01"; }
        else if (text.Contains("6X01")) { return "06X01"; }
        else if (text.Contains("6X2")) { return "06X01"; }
        else if (text.Contains("60X01")) { return "06X01"; }
        else if (text.Contains("45H")) { return "06X01"; }
        else if (text.Contains("05X02")) { return "05X02"; }
        else if (text.Contains("5X2")) { return "05X02"; }
        else if (text.Contains("SX2")) { return "05X02"; }
        else if (text.Contains("5X1")) { return "05X02"; }
        else if (text.Contains("44H")) { return "05X02"; }
        else if (text.Contains("12X36")) { return "12X36"; }
        else if (text.Contains("13X36")) { return "12X36"; }
        else if (text.Contains("24X48")) { return "24X48"; }
        else if (text.Contains("04X03")) { return "04X03"; }
        else if (text.Contains("4X3")) { return "04X03"; }
        else if (text.Contains("03X04")) { return "03X04"; }
        else if (text.Contains("3X4")) { return "03X04"; }
        else if (text.Contains("02X05")) { return "02X05"; }
        else if (text.Contains("2X5")) { return "02X05"; }
        else if (text.Contains("01X06")) { return "01X06"; }
        else if (text.Contains("1X6")) { return "01X06"; }
        else if (text.Contains("FOLGAS2SABADOSEDOMINGOS")) { return "06X01"; }
        else if (text.Contains("FOLGASSABADOSEDOMINGOS")) { return "05X02"; }
        else if (text.Contains("FOLGASABADOEDOMINGO")) { return "05X02"; }
        else if (text.Contains("FOLGASABADODOMINGO")) { return "05X02"; }
        else if (text.Contains("SEGTERQUAQUISEXSAB")) { return "06X01"; }
        else if (text.Contains("SEGTERQUAQUISEX")) { return "05X02"; }
        else if (text.Contains("SABADOEDOMINGO")) { return "05X02"; }
        else if (text.Contains("FOLGASDOMINGO")) { return "06X01"; }
        else if (text.Contains("FOLGADOMINGO")) { return "06X01"; }
        else if (text.Contains("SEGQUASEX")) { return "12X36"; }
        else if (text.Contains("SEGASEX")) { return "05X02"; }
        else if (text.Contains("SEGASAB")) { return "06X01"; }
        else if (text.Contains("TERQUI")) { return "12X36"; }
        else if (text.Contains("TERQUI")) { return "12X36"; }
        else { return null;}
    }

    public static DateTime DateParser(string input)
    {
        if (input is null) { return DateTime.MinValue; }

        try
        {
            //var formats = DateTimeFormatInfo.InvariantInfo.GetAllDateTimePatterns();

            string[] formats = { "dd/MM/yyyy HH:mm:ss:fff",
                                 "dd/MM/yyyy HH:mm:ss",
                                 "dd/MM/yyyy HH:mm",
                                 "dd/MM/yyyy",
                                 "d/MM/yyyy HH:mm:ss:fff",
                                 "d/MM/yyyy HH:mm:ss",
                                 "d/MM/yyyy HH:mm",
                                 "d/MM/yyyy",
                                 "d/M/yyyy HH:mm:ss:fff",
                                 "d/M/yyyy HH:mm:ss",
                                 "d/M/yyyy HH:mm",
                                 "d/M/yyyy",
                                 "d/M/yy HH:mm:ss:fff",
                                 "d/M/yy HH:mm:ss",
                                 "d/M/yy HH:mm",
                                 "d/M/yy" };

            if (DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                return date;
            }
            else
            {
                return DateTime.MinValue;
            }
        }
        catch (Exception)
        {
            return DateTime.MinValue;
        }
    }
}
