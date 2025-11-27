using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Application.ViewModels;
using BibliotecaApp.Domain.Entities;
using BibliotecaApp.Domain.Interfaces;
using Mapster;

namespace BibliotecaApp.Application.Services;

public class LivroService : ILivroService
{
    private readonly ILivroRepository _livroRepository;

    public LivroService(ILivroRepository livroRepository)
    {
        _livroRepository = livroRepository;
    }

    public async Task<IEnumerable<LivroViewModel>> GetAllAsync()
    {
        var livros = await _livroRepository.GetAllAsync();
        return livros.Select(l => new LivroViewModel
        {
            Id = l.Id,
            Titulo = l.Titulo,
            ISBN = l.ISBN,
            AnoPublicacao = l.AnoPublicacao,
            Genero = l.Genero,
            NumeroPaginas = l.NumeroPaginas,
            Preco = l.Preco,
            AutorId = l.AutorId,
            AutorNome = l.Autor?.Nome,
            DataCriacao = l.DataCriacao
        });
    }

    public async Task<LivroViewModel?> GetByIdAsync(int id)
    {
        var livro = await _livroRepository.GetByIdAsync(id);
        return livro?.Adapt<LivroViewModel>();
    }

    public async Task<LivroViewModel?> GetByIdWithAutorAsync(int id)
    {
        var livro = await _livroRepository.GetByIdWithAutorAsync(id);
        if (livro == null) return null;

        var viewModel = livro.Adapt<LivroViewModel>();
        viewModel.AutorNome = livro.Autor?.Nome;
        return viewModel;
    }

    public async Task<IEnumerable<LivroViewModel>> SearchAsync(string searchTerm)
    {
        var livros = await _livroRepository.SearchAsync(searchTerm);
        return livros.Select(l => new LivroViewModel
        {
            Id = l.Id,
            Titulo = l.Titulo,
            ISBN = l.ISBN,
            AnoPublicacao = l.AnoPublicacao,
            Genero = l.Genero,
            NumeroPaginas = l.NumeroPaginas,
            Preco = l.Preco,
            AutorId = l.AutorId,
            AutorNome = l.Autor?.Nome,
            DataCriacao = l.DataCriacao
        });
    }

    public async Task<IEnumerable<LivroViewModel>> GetByAutorIdAsync(int autorId)
    {
        var livros = await _livroRepository.GetByAutorIdAsync(autorId);
        return livros.Adapt<IEnumerable<LivroViewModel>>();
    }

    public async Task<bool> AddAsync(LivroViewModel viewModel)
    {
        try
        {
            var livro = viewModel.Adapt<Livro>();
            livro.DataCriacao = DateTime.Now;
            await _livroRepository.AddAsync(livro);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateAsync(LivroViewModel viewModel)
    {
        try
        {
            var livroExistente = await _livroRepository.GetByIdAsync(viewModel.Id);
            if (livroExistente == null) return false;

            viewModel.Adapt(livroExistente);
            await _livroRepository.UpdateAsync(livroExistente);
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
            var existe = await _livroRepository.ExistsAsync(id);
            if (!existe) return false;

            await _livroRepository.DeleteAsync(id);
            return true;
        }
        catch
        {
            return false;
        }
    }
}

