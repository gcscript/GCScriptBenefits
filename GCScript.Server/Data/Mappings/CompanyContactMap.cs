using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript.Server.Data.Mappings;

public class CompanyContactMap : IEntityTypeConfiguration<MCompanyContact>
{
    public void Configure(EntityTypeBuilder<MCompanyContact> builder)
    {
        // Tabela
        builder.ToTable("CompanyContact");

        // Chave primária
        builder.HasKey(x => x.Id);

        // Colunas
        builder.Property(x => x.CompanyId)
            .IsRequired()
            .HasColumnName("CompanyId");

        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasMaxLength(64);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasMaxLength(320);

        builder.Property(x => x.Phone)
            .HasColumnName("Phone")
            .HasMaxLength(11);

        // Índices
        builder.HasIndex(x => x.Email, "IX_CompanyContact_Email")
            .IsUnique();
    }
}
