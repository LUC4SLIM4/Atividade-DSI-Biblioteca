using BibliotecaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaApp.Infrastructure.Data.Configurations;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> builder)
    {
        builder.ToTable("Livros");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Id)
            .ValueGeneratedOnAdd();

        builder.Property(l => l.Titulo)
            .IsRequired()
            .HasMaxLength(300);

        builder.Property(l => l.ISBN)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(l => l.AnoPublicacao)
            .IsRequired();

        builder.Property(l => l.Genero)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(l => l.NumeroPaginas)
            .IsRequired();

        builder.Property(l => l.Preco)
            .IsRequired()
            .HasPrecision(18, 2);

        builder.Property(l => l.DataCriacao)
            .IsRequired()
            .HasDefaultValueSql("GETDATE()");

        // Configuração explícita da chave estrangeira
        builder.Property(l => l.AutorId)
            .IsRequired();

        // Configuração do relacionamento
        builder.HasOne(l => l.Autor)
            .WithMany(a => a.Livros)
            .HasForeignKey(l => l.AutorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Índices para melhor performance
        builder.HasIndex(l => l.Titulo);
        builder.HasIndex(l => l.ISBN).IsUnique();
        builder.HasIndex(l => l.AutorId);
    }
}

