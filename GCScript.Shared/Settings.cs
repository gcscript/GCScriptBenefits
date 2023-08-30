using GCScript.Shared.Models.Management;

namespace GCScript.Shared;

public static class Settings
{
    public static readonly string AppPath = Path.GetDirectoryName(System.AppContext.BaseDirectory)!;
    public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    public static readonly string TxtOrderFilePath = Path.Combine(DesktopPath, "ped.txt");
    public static readonly string XmlOrderFilePath = Path.Combine(DesktopPath, "ped.xml");
    public static readonly string TxtRegisterFilePath = Path.Combine(DesktopPath, "cad.txt");
    public static readonly string DadosSheetPath = Path.Combine(AppPath, "Sheets", "Dados.xlsx");
    public static readonly string EscalaSheetPath = Path.Combine(AppPath, "Sheets", "Escala.xlsx");
    public static readonly string SaldoSheetPath = Path.Combine(AppPath, "Sheets", "Saldo.xlsx");
    public static MManagementWizard? ManagementWizardSettings;
}