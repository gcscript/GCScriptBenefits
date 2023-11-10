using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace GCScript.Shared;

public enum ETextCase { None, ToLower, ToUpper, ToTitleCase }
public enum ETextType { None, OnlyLetters, OnlyNumbers, OnlyLettersNumbers, OnlyLettersNumbersSpaces }
public enum ETextTrim { None, Trim, TrimStart, TrimEnd }
public enum ETextRemoveSpaces { None, Duplicate, All }

public static class GCScriptExtensions
{
    public static string ProcessText(this string text, bool removeAccents, ETextTrim textTrim, ETextCase textCase, ETextType textType, ETextRemoveSpaces removeSpaces)
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

    public static string ProcessTextDefault(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        return ProcessText(text,
                           true,
                           ETextTrim.Trim,
                           ETextCase.ToUpper,
                           ETextType.None,
                           ETextRemoveSpaces.Duplicate);
    }

    public static string TreatCPF(this string cpf, bool formatted = true)
    {
        string originalCpf = cpf.Trim();
        try
        {
            cpf = Regex.Replace(cpf.Trim(), "[^0-9]", "");
            if (string.IsNullOrEmpty(cpf)) return "";
            cpf = cpf.PadLeft(11, '0');
            return formatted ? Regex.Replace(cpf, "([0-9]{3})([0-9]{3})([0-9]{3})([0-9]{2})", "$1.$2.$3-$4") : cpf;
        }
        catch { return $"ERROR: {originalCpf}"; }
    }

    public static string TreatCNPJ(this string cnpj, bool formatted = true)
    {
        string originalCnpj = cnpj.Trim();
        try
        {
            cnpj = Regex.Replace(cnpj.Trim(), "[^0-9]", "");
            if (string.IsNullOrEmpty(cnpj)) return "";
            cnpj = cnpj.PadLeft(14, '0');
            return formatted ? Regex.Replace(cnpj, "([0-9]{2})([0-9]{3})([0-9]{3})([0-9]{4})([0-9]{2})", "$1.$2.$3/$4-$5") : cnpj;
        }
        catch { return $"ERROR: {originalCnpj}"; }
    }

    public static string TreatRiocardCard(this string card, bool formatted = true)
    {
        string originalCard = card.Trim();
        try
        {
            card = Regex.Replace(card.Trim(), "[^0-9]", "");
            if (string.IsNullOrEmpty(card)) return "";
            if (card.Length != 13) { throw new Exception(); }
            return formatted ? Regex.Replace(card, "([0-9]{2})([0-9]{2})([0-9]{8})([0-9]{1})", "$1.$2.$3-$4") : card;
        }
        catch { return $"ERROR: {originalCard}"; }
    }

    public static string RemoveAccents(this string text)
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

    public static string RemoveSpaces(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"\s", "");
        return text;
    }

    public static string RemoveDuplicateSpaces(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"\s+", " ");
        return text;
    }

    public static string OnlyLetters(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"[^a-zA-Z]", "");
        return text;
    }

    public static string OnlyNumbers(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"[^0-9]", "");
        return text;
    }

    public static string OnlyLettersNumbers(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"[^a-zA-Z0-9]", "");
        return text;
    }

    public static string OnlyLettersNumbersSpaces(this string text)
    {
        if (string.IsNullOrWhiteSpace(text)) { return ""; }
        text = Regex.Replace(text, @"[^a-zA-Z0-9\s]", "");
        return text;
    }
}
