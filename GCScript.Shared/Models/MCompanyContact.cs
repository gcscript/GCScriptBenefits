namespace GCScript.Shared.Models;

public class MCompanyContact
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CompanyId { get; set; }
    public string? Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }

    // NAVIGATION PROPERTIES
    public MCompany Company { get; set; }
}
