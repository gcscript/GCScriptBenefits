using GCScript.Shared.Models.Management;

namespace GCScript.Shared;

public static class Settings
{
    public static bool DarkMode = true;
    public static readonly string AppPath = Path.GetDirectoryName(System.AppContext.BaseDirectory)!;
    public static readonly string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
    public static readonly string AppDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "GCScript Benefits");
    public static readonly string TxtOrderFilePath = Path.Combine(DesktopPath, "ped.txt");
    public static readonly string XmlOrderFilePath = Path.Combine(DesktopPath, "ped.xml");
    public static readonly string TxtRegisterFilePath = Path.Combine(DesktopPath, "cad.txt");
    public static readonly string DadosSheetPath = Path.Combine(AppPath, "Sheets", "Dados.xlsx");
    public static readonly string EscalaSheetPath = Path.Combine(AppPath, "Sheets", "Escala.xlsx");
    public static readonly string SaldoSheetPath = Path.Combine(AppPath, "Sheets", "Saldo.xlsx");
    public static readonly string DiscordWebhookUrl = "https://discord.com/api/webhooks/1158518740107923608/AMLIZSib52ugQa_lJ3vhS_gaDWyxOnqxk5L-fsWlbhE0RywWYyznet1Ns7IABqd7ah_B";
    public static readonly string DiscordWebhookRegisterUrl = "https://discord.com/api/webhooks/1158566304345772143/qBgOQpTM9GX65OdWnmDHJ0cu1TWQSxpDlyhn4AATYQbnDJSA0u-RnoPA8-ftgPAEw8vV";
    public static readonly string DiscordWebhookAuthenticationUrl = "https://discord.com/api/webhooks/1159230231958270097/DvqCfQ-yprKji3U-72U5WKaowPki2H-zrG_Ew9zbwmD7GwXUGYNh7q4rspTR635QasW6";
    public static MManagementWizard? ManagementWizardSettings;
}