namespace GCScript.Shared.Models;

public class MUnitPasswordHistory
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UnitId { get; set; }
    public required string Password { get; set; }
    public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;
    public Guid CreatedBy { get; set; }

    // NAVIGATION PROPERTIES
    public MUnit Unit { get; set; }
    public MUser CreatedByUser { get; set; }
}
