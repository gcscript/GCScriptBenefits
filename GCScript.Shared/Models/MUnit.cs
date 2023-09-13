namespace GCScript.Shared.Models;

public class MUnit
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Cnpj { get; set; }
    public string? Notes { get; set; }
    public Guid CompanyId { get; set; }
    public Guid OperatorId { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public Guid CreatedBy { get; set; }

    // NAVIGATION PROPERTIES
    public MCompany Company { get; set; }
    public MOperator Operator { get; set; }
    public MUser CreatedByUser { get; set; }
}
