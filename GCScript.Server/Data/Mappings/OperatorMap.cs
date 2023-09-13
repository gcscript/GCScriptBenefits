using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript.Server.Data.Mappings;

public class OperatorMap : IEntityTypeConfiguration<MOperator>
{
    public void Configure(EntityTypeBuilder<MOperator> builder)
    {
        // Tabela
        builder.ToTable("Operator");

        // Chave primária
        builder.HasKey(x => x.Id);

        // Colunas
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasMaxLength(64);

        builder.Property(x => x.Uf)
            .IsRequired()
            .HasColumnName(name: "Uf")
            .HasMaxLength(2);

        builder.Property(x => x.Url)
            .IsRequired()
            .HasColumnName(name: "Url")
            .HasMaxLength(512);

        builder.Property(x => x.GenerateOrder)
            .IsRequired()
            .HasColumnName(name: "GenerateOrder")
            .HasDefaultValue(false);

        builder.Property(propertyExpression: x => x.GenerateRegister)
            .IsRequired()
            .HasColumnName(name: "GenerateRegister")
            .HasDefaultValue(false);

        builder.Property(x => x.Notes)
            .HasColumnName("Notes")
            .HasMaxLength(1024);

        builder.Property(propertyExpression: x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasDefaultValue(DateTimeOffset.UtcNow);

        builder.Property(propertyExpression: x => x.CreatedBy)
            .IsRequired()
            .HasColumnName("CreatedBy");

        // Índices
        builder.HasIndex(x => x.Name, "IX_Operator_Name")
            .IsUnique();

        // Relacionamentos
        // Uma Operadora (Operator) pode ter MUITOS Contatos (Contacts) e 1 Contatos (Contacts) só pode estar em 1 Operadora (Operator)
        builder.HasMany(x => x.Contacts) // Uma Operadora tem muitos contatos
        .WithOne(x => x.Operator) // Um contato só pode estar em uma Operadora
        .HasForeignKey(x => x.OperatorId) // Chave estrangeira
        .OnDelete(DeleteBehavior.Cascade); // O contato será excluído caso a Operadora seja excluída

        // Uma Operadora (Operator) pode ter MUITOS Unidades (Unit) e 1 Unidade (Unit) só pode estar em 1 Operadora (Operator)
        builder.HasMany(x => x.Units) // Uma Operadora tem muitas unidades
        .WithOne(x => x.Operator) // Uma unidade só pode estar em uma Operadora
        .HasForeignKey(x => x.OperatorId) // Chave estrangeira
        .OnDelete(DeleteBehavior.Cascade); // A unidade será excluída caso a Operadora seja excluída

        // Dados
    }
}