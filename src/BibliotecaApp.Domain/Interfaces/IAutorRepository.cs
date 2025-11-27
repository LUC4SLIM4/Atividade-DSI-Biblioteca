using BibliotecaApp.Domain.Entities;

namespace BibliotecaApp.Domain.Interfaces;

public interface IAutorRepository
{
    Task<IEnumerable<Autor>> GetAllAsync();
    Task<Autor?> GetByIdAsync(int id);
    Task<Autor?> GetByIdWithLivrosAsync(int id);
    Task<IEnumerable<Autor>> SearchAsync(string searchTerm);
    Task AddAsync(Autor autor);
    Task UpdateAsync(Autor autor);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}

