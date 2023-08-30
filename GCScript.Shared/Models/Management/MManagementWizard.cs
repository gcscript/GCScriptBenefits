namespace GCScript.Shared.Models.Management;

public class MManagementWizard
{
    public string? Company { get; set; }
    public DateTime PurchaseStartPeriod { get; set; }
    public DateTime PurchaseEndPeriod { get; set; }
    public string? PurchaseFilePath { get; set; }
    public string? CNPJForAll { get; set; }
    public string? OperatorForAll { get; set; }
    public List<string>? BalanceFilesPath { get; set; }

}
