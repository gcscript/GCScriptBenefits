namespace GCScript.Shared.Models;

public class MOperator
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Uf { get; set; }
    public required string Url { get; set; }
    public bool GenerateOrder { get; set; }
    public bool GenerateRegister { get; set; }
    public string? Notes { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public Guid CreatedBy { get; set; }

    // NAVIGATION PROPERTIES
    public ICollection<MOperatorContact>? Contacts { get; set; }
    public ICollection<MUnit>? Units { get; set; }
    public MUser CreatedByUser { get; set; }

}
