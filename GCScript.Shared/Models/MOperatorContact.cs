namespace GCScript.Shared.Models;

public class MOperatorContact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OperatorId { get; set; }
    public string? Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }

    // NAVIGATION PROPERTIES
    public MOperator Operator { get; set; }
}
