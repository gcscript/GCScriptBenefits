namespace GCScript.Shared.Models;

public class MRole
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }

    // NAVIGATION PROPERTIES
    public ICollection<MUser>? Users { get; set; }
}