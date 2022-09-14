using System.ComponentModel.DataAnnotations;

namespace CrudMvc.ViewModels;

public class AuthorViewModel
{
    public int Id { get; set; }
    public string? FullName { get; set; }
    public int Books { get; set; }
}