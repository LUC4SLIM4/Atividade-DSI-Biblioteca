using BibliotecaApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Infrastructure.Data;

public class BibliotecaDbContext : DbContext
{
    public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; }
    public DbSet<Livro> Livros { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Aplica todas as configurações do assembly
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BibliotecaDbContext).Assembly);
    }
}

