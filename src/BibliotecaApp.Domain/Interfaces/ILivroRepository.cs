using BibliotecaApp.Domain.Entities;

namespace BibliotecaApp.Domain.Interfaces;

public interface ILivroRepository
{
    Task<IEnumerable<Livro>> GetAllAsync();
    Task<Livro?> GetByIdAsync(int id);
    Task<Livro?> GetByIdWithAutorAsync(int id);
    Task<IEnumerable<Livro>> SearchAsync(string searchTerm);
    Task<IEnumerable<Livro>> GetByAutorIdAsync(int autorId);
    Task AddAsync(Livro livro);
    Task UpdateAsync(Livro livro);
    Task DeleteAsync(int id);
    Task<bool> ExistsAsync(int id);
}

