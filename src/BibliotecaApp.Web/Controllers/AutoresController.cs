using BibliotecaApp.Application.Interfaces;
using BibliotecaApp.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.Web.Controllers;

public class AutoresController : Controller
{
    private readonly IAutorService _autorService;

    public AutoresController(IAutorService autorService)
    {
        _autorService = autorService;
    }

    // GET: Autores
    public async Task<IActionResult> Index()
    {
        var autores = await _autorService.GetAllAsync();
        return View(autores);
    }

    // GET: Autores/Details/5
    public async Task<IActionResult> Details(int id)
    {
        var autor = await _autorService.GetByIdWithLivrosAsync(id);
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
    }

    // GET: Autores/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Autores/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AutorViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var resultado = await _autorService.AddAsync(viewModel);
            if (resultado)
            {
                TempData["Sucesso"] = "Autor criado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Erro ao criar autor.");
        }
        return View(viewModel);
    }

    // GET: Autores/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var autor = await _autorService.GetByIdAsync(id);
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
    }

    // POST: Autores/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, AutorViewModel viewModel)
    {
        if (id != viewModel.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var resultado = await _autorService.UpdateAsync(viewModel);
            if (resultado)
            {
                TempData["Sucesso"] = "Autor atualizado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            ModelState.AddModelError("", "Erro ao atualizar autor.");
        }
        return View(viewModel);
    }

    // GET: Autores/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var autor = await _autorService.GetByIdWithLivrosAsync(id);
        if (autor == null)
        {
            return NotFound();
        }
        return View(autor);
    }

    // POST: Autores/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var resultado = await _autorService.DeleteAsync(id);
        if (resultado)
        {
            TempData["Sucesso"] = "Autor excluído com sucesso!";
        }
        else
        {
            TempData["Erro"] = "Erro ao excluir autor.";
        }
        return RedirectToAction(nameof(Index));
    }

    // GET: Autores/Search?searchTerm=termo
    [HttpGet]
    public async Task<IActionResult> Search(string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            var todosAutores = await _autorService.GetAllAsync();
            return Json(todosAutores);
        }

        var autores = await _autorService.SearchAsync(searchTerm);
        return Json(autores);
    }
}

