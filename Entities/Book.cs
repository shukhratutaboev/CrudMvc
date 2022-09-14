using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMvc.Entities;

public class Book
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Pages { get; set; }
    public ECategory Category { get; set; }
    public int AuthorId { get; set; }

    [ForeignKey(nameof(AuthorId))]
    public Author? Author { get; set; }
}