using CrudMvc.Data;
using CrudMvc.Mappers;
using CrudMvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudMvc.Controllers;

public class BookController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<BookController> _logger;

    public BookController(ILogger<BookController> logger, AppDbContext context)
    {
        _context = context;
        _logger = logger;
    }

    public IActionResult List()
    {
        var books = _context.Books.Include(b => b.Author).Select(b => b.ToModel()).ToList();
        return View(books);
    }

    public IActionResult AddBook() => View("AddOrUpdate", new BookCreateOrUpdateViewModel(){ IsCreating = true });

    [HttpPost]
    public IActionResult AddBook(BookCreateOrUpdateViewModel model)
    {
        if(!ModelState.IsValid) return View();
        _context.Books!.Add(model.ToEntity());
        _context.SaveChanges();
        _logger.LogInformation($"{model.Name} is added to books.");
        return RedirectToAction(nameof(List));
    }

    public IActionResult Edit(int id)
    {
        var book = _context.Books.FirstOrDefault(a => a.Id == id);
        return View("AddOrUpdate", new BookCreateOrUpdateViewModel(){
            Name = book.Name,
            Pages = book.Pages,
            Category = book.Category,
            AuthorId = book.AuthorId
        });
    }

    [HttpPost]
    public IActionResult Edit(BookCreateOrUpdateViewModel model, int id)
    {
        if(!ModelState.IsValid) return View();
        var book = _context.Books.FirstOrDefault(a => a.Id == id);
        book.Name = model.Name;
        book.Pages = model.Pages;
        book.Category = model.Category;
        book.AuthorId = model.AuthorId;
        _context.Books.Update(book);
        _context.SaveChanges();
        _logger.LogInformation($"{model.Name} is updated.");
        return RedirectToAction(nameof(List));
    }

    public IActionResult Delete(int id)
    {
        var book = _context.Books.FirstOrDefault(a => a.Id == id);
        _context.Remove(book);
        _context.SaveChanges();
        return RedirectToAction(nameof(List));
    }
}