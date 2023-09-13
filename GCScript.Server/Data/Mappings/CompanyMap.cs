using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript.Server.Data.Mappings;

public class CompanyMap : IEntityTypeConfiguration<MCompany>
{
    public void Configure(EntityTypeBuilder<MCompany> builder)
    {
        // Tabela
        builder.ToTable("Company");

        // Chave primária
        builder.HasKey(x => x.Id);

        // Colunas
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasMaxLength(64);

        builder.Property(x => x.Margin)
            .IsRequired()
            .HasColumnName("Margin")
            .HasDefaultValue(3);

        builder.Property(x => x.Notes)
            .HasColumnName("Notes")
            .HasMaxLength(1024);

        builder.Property(x => x.ResponsibleGvt)
            .IsRequired()
            .HasColumnName("ResponsibleGvt");

        builder.Property(x => x.ResponsibleTi)
            .IsRequired()
            .HasColumnName("ResponsibleTi");

        builder.Property(propertyExpression: x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasDefaultValue(DateTimeOffset.UtcNow);

        // Índices
        builder.HasIndex(x => x.Name, "IX_Company_Name")
            .IsUnique();

        // Relacionamentos
        // Uma Empresa (Company) possui 1 Responsável GVG (ResponsibleGvt) e 1 Responsável GVG (ResponsibleGvt) pode estar em várias Empresas (Company)
        builder.HasOne(x => x.ResponsibleGvtUser) // Uma empresa tem um responsável do GVT
               .WithMany(navigationExpression: x => x.ResponsiblesGvt) // Um responsável do GVT (está em/tem) muitas empresas
               .HasForeignKey(x => x.ResponsibleGvt) // Chave estrangeira
               .OnDelete(DeleteBehavior.Restrict); // O responsável do GVT não será excluído caso a empresa seja excluída

        // Uma Empresa (Company) possui 1 Responsável TI (ResponsibleGvt) e 1 Responsável TI (ResponsibleTi) pode estar em várias Empresas (Company)
        builder.HasOne(x => x.ResponsibleTiUser) // Uma empresa tem um responsável de TI
                .WithMany(x => x.ResponsiblesTi) // Um responsável de TI (está em/tem) muitas empresas
                .HasForeignKey(x => x.ResponsibleTi) // Chave estrangeira
                .OnDelete(DeleteBehavior.Restrict); // O responsável de TI não será excluído caso a empresa seja excluída

        // Uma Empresa (Company) pode ter MUITOS Contatos (Contacts) e 1 Contatos (Contacts) só pode estar em 1 Empresa (Company)
        builder.HasMany(x => x.Contacts) // Uma empresa tem muitos contatos
        .WithOne(x => x.Company) // Um contato só pode estar em uma empresa
        .HasForeignKey(x => x.CompanyId) // Chave estrangeira
        .OnDelete(DeleteBehavior.Cascade); // O contato será excluído caso a empresa seja excluída

        // Uma Empresa (Company) pode ter MUITOS Unidades (Unit) e 1 Unidade (Unit) só pode estar em 1 Empresa (Company)
        builder.HasMany(x => x.Units) // Uma empresa tem muitas unidades
        .WithOne(x => x.Company) // Uma unidade só pode estar em uma empresa
        .HasForeignKey(x => x.CompanyId) // Chave estrangeira
        .OnDelete(DeleteBehavior.Cascade); // A unidade será excluída caso a empresa seja excluída

        // Dados
        //builder.HasData(
        //    new MCompany { Id = Guid.Parse("9d108e75-82fb-4efe-a39f-1fb46c859fd9"), Name = "CAPITAL", Margin = 3, ResponsibleGvt = Guid.Parse("ea8eb9b3-3893-408d-a373-a4e93d4c5f64"), ResponsibleTi = Guid.Parse("ffb3a31b-7d21-4b2e-b263-47ac9d82fd71") },
        //    new MCompany { Id = Guid.Parse("a61c6d6b-1183-4641-a16f-2709bbf26f33"), Name = "RIOSHOP", Margin = 3, ResponsibleGvt = Guid.Parse("8c775173-cf42-4f37-86fc-362e87c2d3fe"), ResponsibleTi = Guid.Parse("17c32a6f-8ff5-4059-a638-1c579fb91ae3") }
        //);
    }
}