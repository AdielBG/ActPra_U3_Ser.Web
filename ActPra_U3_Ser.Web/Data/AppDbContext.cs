using ApiBiblioteca_P3.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiBiblioteca_P3.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Libro> Libros { get; set; }
    }
}