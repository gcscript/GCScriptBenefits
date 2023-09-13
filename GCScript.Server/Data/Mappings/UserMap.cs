using GCScript.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GCScript.Server.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<MUser>
{
    public void Configure(EntityTypeBuilder<MUser> builder)
    {
        // Tabela
        builder.ToTable("User");

        // Chave primária
        builder.HasKey(x => x.Id);

        // Colunas
        builder.Property(x => x.Name)
            .IsRequired()
            .HasColumnName("Name")
            .HasMaxLength(16);

        builder.Property(x => x.Username)
            .IsRequired()
            .HasColumnName("Username")
            .HasMaxLength(16);

        builder.Property(x => x.Password)
            .IsRequired()
            .HasColumnName("Password")
            .HasMaxLength(12);

        builder.Property(x => x.Email)
            .HasColumnName("Email")
            .HasMaxLength(256);

        builder.Property(x => x.Phone)
            .HasColumnName("Phone")
            .HasMaxLength(11);

        builder.Property(propertyExpression: x => x.CreatedAt)
            .HasColumnName("CreatedAt")
            .HasDefaultValue(DateTimeOffset.UtcNow);

        builder.Property(x => x.RoleId)
            .IsRequired()
            .HasColumnName("RoleId");

        // Índices
        builder.HasIndex(x => x.Username, "IX_User_Username")
            .IsUnique();

        // Relacionamentos
        // 1 Usuário (User) possui 1 Cargo (Role) e 1 Cargo (Role) pode estar em vários Usuários (User)
        builder.HasOne(x => x.Role) // Um usuário tem um cargo
               .WithMany(x => x.Users) // Um cargo (está em/tem) muitos usuários
               .HasForeignKey(x => x.RoleId) // Chave estrangeira
               .OnDelete(DeleteBehavior.Restrict); // O cargo não será excluído caso o usuário seja excluído
        
        // 1 Usuário (User) criou MUITAS Empresas (Company) e 1 Empresa (Company) só pode ter 1 Usuário (User) como criador
        builder.HasMany(x => x.CreatorUserCompanies) // Um usuário criou muitas empresas
               .WithOne(x => x.CreatedByUser) // Uma empresa só pode ter um usuário como criador
               .HasForeignKey(x => x.CreatedBy) // Chave estrangeira
               .OnDelete(DeleteBehavior.Restrict); // O usuário não será excluído caso a empresa seja excluída

        // 1 Usuário (User) criou MUITAS Unidades (Unit) e 1 Unidade (Unit) só pode ter 1 Usuário (User) como criador
        builder.HasMany(x => x.CreatorUserUnits) // Um usuário criou muitas unidades
               .WithOne(x => x.CreatedByUser) // Uma unidade só pode ter um usuário como criador
               .HasForeignKey(x => x.CreatedBy) // Chave estrangeira
               .OnDelete(DeleteBehavior.Restrict); // O usuário não será excluído caso a unidade seja excluída

        // 1 Usuário (User) criou MUITAS Operadoras (Operator) e 1 Operadora (Operator) só pode ter 1 Usuário (User) como criador
        builder.HasMany(x => x.CreatorUserOperators) // Um usuário criou muitas operadoras
               .WithOne(x => x.CreatedByUser) // Uma operadora só pode ter um usuário como criador
               .HasForeignKey(x => x.CreatedBy) // Chave estrangeira
               .OnDelete(DeleteBehavior.Restrict); // O usuário não será excluído caso a operadora seja excluída

        // Dados
        builder.HasData(
            new MUser { Id = Guid.Parse("ffb3a31b-7d21-4b2e-b263-47ac9d82fd71"), Name = "Gustavo", Username = "gcs5stars", Password = "123456", Email = "gcs5stars@gmail.com", Phone = "21988888888", RoleId = Guid.Parse("a29a43fa-2c84-4fb1-942c-bfc1c0978e6d") },
            new MUser { Id = Guid.Parse("b18d5535-34e1-4b64-86b8-b6b3a897fe04"), Name = "Ellen", Username = "ellen", Password = "123456", Email = "ellen@gmail.com", Phone = "21988888888", RoleId = Guid.Parse("1f6180f7-4e7e-40f3-9b65-a5b6dfe8a293") },
            new MUser { Id = Guid.Parse("ea8eb9b3-3893-408d-a373-a4e93d4c5f64"), Name = "Rosi", Username = "rosi", Password = "123456", Email = "rosi@gmail.com", Phone = "21988888888", RoleId = Guid.Parse("1f6180f7-4e7e-40f3-9b65-a5b6dfe8a293") },
            new MUser { Id = Guid.Parse("8c775173-cf42-4f37-86fc-362e87c2d3fe"), Name = "Edna", Username = "edna", Password = "123456", Email = "edna@gmail.com", Phone = "21988888888", RoleId = Guid.Parse("1f6180f7-4e7e-40f3-9b65-a5b6dfe8a293") },
            new MUser { Id = Guid.Parse("3e0f9f0a-d3c2-4357-bed2-a680215061ec"), Name = "Tania", Username = "tania", Password = "123456", Email = "tania@gmail.com", Phone = "21988888888", RoleId = Guid.Parse("1f6180f7-4e7e-40f3-9b65-a5b6dfe8a293") },
            new MUser { Id = Guid.Parse("17c32a6f-8ff5-4059-a638-1c579fb91ae3"), Name = "Mauricio", Username = "mauricio", Password = "123456", Email = "mauricio@gmail.com", Phone = "21988888888", RoleId = Guid.Parse("1f6180f7-4e7e-40f3-9b65-a5b6dfe8a293") },
            new MUser { Id = Guid.Parse("e90ba364-18be-4f5d-bc7f-8f3a2a42dca7"), Name = "Julia", Username = "julia", Password = "123456", Email = "julia@gmail.com", Phone = "21988888888", RoleId = Guid.Parse("1f6180f7-4e7e-40f3-9b65-a5b6dfe8a293") }
        );
    }
}
