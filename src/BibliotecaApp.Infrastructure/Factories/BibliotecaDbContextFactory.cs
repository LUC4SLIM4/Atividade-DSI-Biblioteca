using BibliotecaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BibliotecaApp.Infrastructure.Factories;

/// <summary>
/// Factory para criação do DbContext em design-time (migrations)
/// </summary>
public class BibliotecaDbContextFactory : IDesignTimeDbContextFactory<BibliotecaDbContext>
{
    public BibliotecaDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<BibliotecaDbContext>();
        
        // Connection string padrão para migrations
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;Database=BibliotecaDb;Trusted_Connection=True;MultipleActiveResultSets=true");

        return new BibliotecaDbContext(optionsBuilder.Options);
    }
}

