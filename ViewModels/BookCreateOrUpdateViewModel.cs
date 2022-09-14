using CrudMvc.Entities;

namespace CrudMvc.ViewModels;

public class BookCreateOrUpdateViewModel
{
    public string? Name { get; set; }
    public int Pages { get; set; }
    public ECategory Category { get; set; }
    public int AuthorId { get; set; }
    public bool IsCreating { get; set; } = false;
}