using CrudMvc.Entities;
using CrudMvc.ViewModels;

namespace CrudMvc.Mappers;

public static class Mapper
{
    public static Author ToEntity(this AuthorCreateOrUpdateViewModel model) => new()
    {
        FullName = model.FullName
    };

    public static Book ToEntity(this BookCreateOrUpdateViewModel model) => new()
    {
        Name = model.Name,
        Pages = model.Pages,
        Category = model.Category,
        AuthorId = model.AuthorId
    };

    public static AuthorViewModel ToModel(this Author entity) => new()
    {
        Id = entity.Id,
        FullName = entity.FullName,
        Books = entity.Books is null ? 0 : entity.Books.Count()
    };

    public static BookViewModel ToModel(this Book entity) => new()
    {
        Id = entity.Id,
        Pages = entity.Pages,
        Category = entity.Category.ToString(),
        Name = entity.Name,
        Author = entity.Author.FullName
    };
}