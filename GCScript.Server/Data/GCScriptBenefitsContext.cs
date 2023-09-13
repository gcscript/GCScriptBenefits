using GCScript.Server.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace GCScript.Server.Data;

public class GCScriptBenefitsContext : DbContext
{
    public GCScriptBenefitsContext(DbContextOptions<GCScriptBenefitsContext> options) : base(options) { }

    public DbSet<MUser> Users { get; set; }
    public DbSet<MRole> Roles { get; set; }
    public DbSet<MCompany> Companies { get; set; }
    public DbSet<MCompanyContact> CompanyContacts { get; set; }
    public DbSet<MOperator> Operators { get; set; }
    public DbSet<MOperatorContact> OperatorContacts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new RoleMap());
        modelBuilder.ApplyConfiguration(new CompanyMap());
        modelBuilder.ApplyConfiguration(new CompanyContactMap());
        modelBuilder.ApplyConfiguration(new OperatorMap());
        modelBuilder.ApplyConfiguration(new OperatorContactMap());
    }
}