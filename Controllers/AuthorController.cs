using Microsoft.AspNetCore.Mvc;
using CrudMvc.ViewModels;
using CrudMvc.Data;
using CrudMvc.Mappers;
using Microsoft.EntityFrameworkCore;

namespace CrudMvc.Controllers;

public class AuthorController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<AuthorController> _logger;

    public AuthorController(ILogger<AuthorController> logger, AppDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult AddAuthor() => View("AddOrUpdate", new AuthorCreateOrUpdateViewModel(){ IsCreating = true });

    [HttpPost]
    public IActionResult AddAuthor(AuthorCreateOrUpdateViewModel model)
    {
        if(!ModelState.IsValid) return View();
        _context.Authors!.Add(model.ToEntity());
        _context.SaveChanges();
        _logger.LogInformation($"{model.FullName} is added to authors.");
        return RedirectToAction(nameof(List));
    }

    public IActionResult List()
    {
        var authors = _context.Authors.Include(a => a.Books).Select(a => a.ToModel()).ToList();
        return View(authors);
    }

    public IActionResult Delete(int id)
    {
        var author = _context.Authors.FirstOrDefault(a => a.Id == id);
        _context.Remove(author);
        _context.SaveChanges();
        return RedirectToAction(nameof(List));
    }

    public IActionResult Edit(int id)
    {
        var author = _context.Authors.FirstOrDefault(a => a.Id == id);
        return View("AddOrUpdate", new AuthorCreateOrUpdateViewModel(){FullName = author.FullName});
    }

    [HttpPost]
    public IActionResult Edit(AuthorCreateOrUpdateViewModel model, int id)
    {
        if(!ModelState.IsValid) return View();
        var author = _context.Authors.FirstOrDefault(a => a.Id == id);
        author.FullName = model.FullName;
        _context.Authors.Update(author);
        _context.SaveChanges();
        _logger.LogInformation($"{model.FullName} is updated to authors.");
        return RedirectToAction(nameof(List));
    }
}
