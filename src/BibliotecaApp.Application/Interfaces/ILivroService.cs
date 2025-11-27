using BibliotecaApp.Application.ViewModels;

namespace BibliotecaApp.Application.Interfaces;

public interface ILivroService
{
    Task<IEnumerable<LivroViewModel>> GetAllAsync();
    Task<LivroViewModel?> GetByIdAsync(int id);
    Task<LivroViewModel?> GetByIdWithAutorAsync(int id);
    Task<IEnumerable<LivroViewModel>> SearchAsync(string searchTerm);
    Task<IEnumerable<LivroViewModel>> GetByAutorIdAsync(int autorId);
    Task<bool> AddAsync(LivroViewModel viewModel);
    Task<bool> UpdateAsync(LivroViewModel viewModel);
    Task<bool> DeleteAsync(int id);
}

