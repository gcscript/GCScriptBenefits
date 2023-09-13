namespace GCScript.Shared.Models;

public class MUser
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string Password { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public Guid RoleId { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

    // NAVIGATION PROPERTIES
    public MRole Role { get; set; }
    public ICollection<MCompany>? ResponsiblesGvt { get; set; }
    public ICollection<MCompany>? ResponsiblesTi { get; set; }
    public ICollection<MCompany>? CreatorUserCompanies { get; set; }
    public ICollection<MUnit>? CreatorUserUnits { get; set; }
    public ICollection<MOperator>? CreatorUserOperators { get; set; }
    public ICollection<MUnitPasswordHistory>? CreatorUserUnitPasswordHistories { get; set; }
}
