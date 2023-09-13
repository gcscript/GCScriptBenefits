using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript.Server.Data.Mappings;

public class OperatorContactMap : IEntityTypeConfiguration<MOperatorContact>
{
    public void Configure(EntityTypeBuilder<MOperatorContact> builder)
    {
        // Tabela
        builder.ToTable("OperatorContact");

        // Chave primária
        builder.HasKey(x => x.Id);

        // Colunas
        builder.Property(x => x.OperatorId)
            .IsRequired()
            .HasColumnName("OperatorId");

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
        builder.HasIndex(x => x.Email, "IX_OperatorContact_Email")
            .IsUnique();
    }
}
