using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BibliotecaApp.Web.Controllers;

public class LivrosController : Controller
{
    private readonly ILivroService _livroService;
    private readonly IAutorService _autorService;

    public LivrosController(ILivroService livroService, IAutorService autorService)
    {
        _livroService = livroService;
        _autorService = autorService;
    }

    // GET: Livros
    public async Task<IActionResult> Index()
    {
        var livros = await _livroService.GetAllAsync();
        return View(livros);
    }

    // GET: Livros/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var livro = await _livroService.GetByIdWithAutorAsync(id);
        if (livro == null)
        {
            return NotFound();
        }
        return View(livro);
    }

    // GET: Livros/Create
    public async Task<IActionResult> Create()
    {
        await CarregarAutores();
        return View();
    }

    // POST: Livros/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(LivroViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var resultado = await _livroService.AddAsync(viewModel);
            if (resultado)
            {
                TempData["Sucesso"] = "Livro criado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Erro ao criar livro.");
        }
        await CarregarAutores();
        return View(viewModel);
    }

    // GET: Livros/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var livro = await _livroService.GetByIdAsync(id);
        if (livro == null)
        {
            return NotFound();
        }
        await CarregarAutores();
        return View(livro);
    }

    // POST: Livros/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, LivroViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var resultado = await _livroService.UpdateAsync(viewModel);
            if (resultado)
            {
                TempData["Sucesso"] = "Livro atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Erro ao atualizar livro.");
        }
        await CarregarAutores();
        return View(viewModel);
    }

    // GET: Livros/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var livro = await _livroService.GetByIdWithAutorAsync(id);
        if (livro == null)
        {
            return NotFound();
        }
        return View(livro);
    }

    // POST: Livros/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var resultado = await _livroService.DeleteAsync(id);
        if (resultado)
        {
            TempData["Sucesso"] = "Livro excluído com sucesso!";
        }
        else
        {
            TempData["Erro"] = "Erro ao excluir livro.";
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Livros/Search?searchTerm=termo
    [HttpGet]
    public async Task<IActionResult> Search(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            var todosLivros = await _livroService.GetAllAsync();
            return Json(todosLivros);
        }

        var livros = await _livroService.SearchAsync(searchTerm);
        return Json(livros);
    }

    private async Task CarregarAutores()
    {
        var autores = await _autorService.GetAllAsync();
        ViewBag.Autores = new SelectList(autores, "Id", "Nome");
    }
}

