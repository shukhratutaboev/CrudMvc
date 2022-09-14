using System.ComponentModel.DataAnnotations;

namespace CrudMvc.ViewModels;

public class AuthorCreateOrUpdateViewModel
{
    [Required]
    public string? FullName { get; set; }
    public bool IsCreating { get; set; } = false;
}