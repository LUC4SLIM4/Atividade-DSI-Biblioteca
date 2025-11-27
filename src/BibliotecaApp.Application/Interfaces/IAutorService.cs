using BibliotecaApp.Application.ViewModels;

namespace BibliotecaApp.Application.Interfaces;

public interface IAutorService
{
    Task<IEnumerable<AutorViewModel>> GetAllAsync();
    Task<AutorViewModel?> GetByIdAsync(int id);
    Task<AutorViewModel?> GetByIdWithLivrosAsync(int id);
    Task<IEnumerable<AutorViewModel>> SearchAsync(string searchTerm);
    Task<bool> AddAsync(AutorViewModel viewModel);
    Task<bool> UpdateAsync(AutorViewModel viewModel);
    Task<bool> DeleteAsync(int id);
}

