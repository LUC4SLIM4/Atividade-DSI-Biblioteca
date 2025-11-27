using BibliotecaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaApp.Infrastructure.Data.Configurations;

public class AutorConfiguration : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> builder)
    {
        builder.ToTable("Autores");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Nome)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(a => a.Email)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(a => a.Nacionalidade)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.DataNascimento)
            .IsRequired();

        builder.Property(a => a.DataCriacao)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        // Configuração do relacionamento 1:N
        builder.HasMany(a => a.Livros)
            .WithOne(l => l.Autor)
            .HasForeignKey(l => l.AutorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Índices para melhor performance
        builder.HasIndex(a => a.Nome);
        builder.HasIndex(a => a.Email);
    }
}

