using CrudMvc.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudMvc.Data;

public class AppDbContext : DbContext
{
    public DbSet<Book>? Books { get; set;}
    public DbSet<Author>? Authors { get; set;}
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
}