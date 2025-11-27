using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Application.ViewModels;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;
using Mapster;

namespace BibliotecaApp.Application.Services;

public class AutorService : IAutorService
{
    private readonly IAutorRepository _autorRepository;

    public AutorService(IAutorRepository autorRepository)
    {
        _autorRepository = autorRepository;
    }

    public async Task<IEnumerable<AutorViewModel>> GetAllAsync()
    {
        var autores = await _autorRepository.GetAllAsync();
        return autores.Adapt<IEnumerable<AutorViewModel>>();
    }

    public async Task<AutorViewModel?> GetByIdAsync(int id)
    {
        var autor = await _autorRepository.GetByIdAsync(id);
        return autor?.Adapt<AutorViewModel>();
    }

    public async Task<AutorViewModel?> GetByIdWithLivrosAsync(int id)
    {
        var autor = await _autorRepository.GetByIdWithLivrosAsync(id);
        if (autor == null) return null;

        var viewModel = autor.Adapt<AutorViewModel>();
        viewModel.QuantidadeLivros = autor.Livros?.Count ?? 0;
        return viewModel;
    }

    public async Task<IEnumerable<AutorViewModel>> SearchAsync(string searchTerm)
    {
        var autores = await _autorRepository.SearchAsync(searchTerm);
        return autores.Adapt<IEnumerable<AutorViewModel>>();
    }

    public async Task<bool> AddAsync(AutorViewModel viewModel)
    {
        try
        {
            var autor = viewModel.Adapt<Autor>();
            autor.DataCriacao = DateTime.Now;
            await _autorRepository.AddAsync(autor);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(AutorViewModel viewModel)
    {
        try
        {
            var autorExistente = await _autorRepository.GetByIdAsync(viewModel.Id);
            if (autorExistente == null) return false;

            viewModel.Adapt(autorExistente);
            await _autorRepository.UpdateAsync(autorExistente);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var existe = await _autorRepository.ExistsAsync(id);
            if (!existe) return false;

            await _autorRepository.DeleteAsync(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

