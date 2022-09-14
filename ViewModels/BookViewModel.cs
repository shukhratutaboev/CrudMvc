using CrudMvc.Entities;

namespace CrudMvc.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Pages { get; set; }
    public string? Category { get; set; }
    public string? Author { get; set; }
}