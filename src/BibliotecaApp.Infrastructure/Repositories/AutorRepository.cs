using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;
using BibliotecaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Infrastructure.Repositories;

public class AutorRepository : IAutorRepository
{
    private readonly BibliotecaDbContext _context;

    public AutorRepository(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Autor>> GetAllAsync()
    {
        return await _context.Autores
            .Include(a => a.Livros)
            .OrderBy(a => a.Nome)
            .ToListAsync();
    }

    public async Task<Autor?> GetByIdAsync(int id)
    {
        return await _context.Autores.FindAsync(id);
    }

    public async Task<Autor?> GetByIdWithLivrosAsync(int id)
    {
        return await _context.Autores
            .Include(a => a.Livros)
            .FirstOrDefaultAsync(a => a.Id == id);
    }

    public async Task<IEnumerable<Autor>> SearchAsync(string searchTerm)
    {
        return await _context.Autores
            .Include(a => a.Livros)
            .Where(a => a.Nome.Contains(searchTerm) || 
                       a.Email.Contains(searchTerm) ||
                       a.Nacionalidade.Contains(searchTerm))
            .OrderBy(a => a.Nome)
            .ToListAsync();
    }

    public async Task AddAsync(Autor autor)
    {
        await _context.Autores.AddAsync(autor);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Autor autor)
    {
        _context.Autores.Update(autor);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var autor = await GetByIdAsync(id);
        if (autor != null)
        {
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Autores.AnyAsync(a => a.Id == id);
    }
}

