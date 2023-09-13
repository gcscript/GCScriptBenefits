namespace GCScript.Shared.Models;

public class MCompany
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public int Margin { get; set; }
    public string? ImageUrl { get; set; }
    public string? Notes { get; set; }
    public Guid ResponsibleGvt { get; set; }
    public Guid ResponsibleTi { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public Guid CreatedBy { get; set; }

    // NAVIGATION PROPERTIES
    public ICollection<MCompanyContact>? Contacts { get; set; }
    public ICollection<MUnit>? Units { get; set; }
    public MUser ResponsibleGvtUser { get; set; }
    public MUser ResponsibleTiUser { get; set; }
    public MUser CreatedByUser { get; set; }
}