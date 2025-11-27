using BibliotecaApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaApp.Web.Controllers;

public class HomeController : Controller
{
    private readonly IAutorService _autorService;
    private readonly ILivroService _livroService;

    public HomeController(IAutorService autorService, ILivroService livroService)
    {
        _autorService = autorService;
        _livroService = livroService;
    }

    public async Task<IActionResult> Index()
    {
        var autores = await _autorService.GetAllAsync();
        var livros = await _livroService.GetAllAsync();
        
        ViewBag.TotalAutores = autores.Count();
        ViewBag.TotalLivros = livros.Count();
        
        return View();
    }
}

