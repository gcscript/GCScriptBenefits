using GCScript.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript.Server.Data.Mappings;

public class RoleMap : IEntityTypeConfiguration<MRole>
{
    public void Configure(EntityTypeBuilder<MRole> builder)
    {
        // Tabela
        builder.ToTable("Role");

        // Chave primária
        builder.HasKey(x => x.Id);

        // Colunas
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasMaxLength(16);

        // Índices
        builder.HasIndex(x => x.Name)
            .IsUnique();

        // Dados
        builder.HasData(
            new MRole { Id = Guid.Parse("a29a43fa-2c84-4fb1-942c-bfc1c0978e6d"), Name = "Admin" },
            new MRole { Id = Guid.Parse("ff7c4ecc-faf3-4620-afed-70dd34a2f9de"), Name = "User3" },
            new MRole { Id = Guid.Parse("08fca057-b479-49b5-b732-bc363eaa290a"), Name = "User2" },
            new MRole { Id = Guid.Parse("1f6180f7-4e7e-40f3-9b65-a5b6dfe8a293"), Name = "User1" }
        );
    }
}
