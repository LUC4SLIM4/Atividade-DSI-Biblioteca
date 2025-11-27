using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;
using BibliotecaApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaApp.Infrastructure.Repositories;

public class LivroRepository : ILivroRepository
{
    private readonly BibliotecaDbContext _context;

    public LivroRepository(BibliotecaDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Livro>> GetAllAsync()
    {
        return await _context.Livros
            .Include(l => l.Autor)
            .OrderBy(l => l.Titulo)
            .ToListAsync();
    }

    public async Task<Livro?> GetByIdAsync(int id)
    {
        return await _context.Livros.FindAsync(id);
    }

    public async Task<Livro?> GetByIdWithAutorAsync(int id)
    {
        return await _context.Livros
            .Include(l => l.Autor)
            .FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<IEnumerable<Livro>> SearchAsync(string searchTerm)
    {
        return await _context.Livros
            .Include(l => l.Autor)
            .Where(l => l.Titulo.Contains(searchTerm) ||
                       l.ISBN.Contains(searchTerm) ||
                       l.Genero.Contains(searchTerm) ||
                       l.Autor.Nome.Contains(searchTerm))
            .OrderBy(l => l.Titulo)
            .ToListAsync();
    }

    public async Task<IEnumerable<Livro>> GetByAutorIdAsync(int autorId)
    {
        return await _context.Livros
            .Where(l => l.AutorId == autorId)
            .OrderBy(l => l.Titulo)
            .ToListAsync();
    }

    public async Task AddAsync(Livro livro)
    {
        await _context.Livros.AddAsync(livro);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Livro livro)
    {
        _context.Livros.Update(livro);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var livro = await GetByIdAsync(id);
        if (livro != null)
        {
            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.Livros.AnyAsync(l => l.Id == id);
    }
}

