using LIvrariaAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LIvrariaAPI.Data
{
    public class LivrariaDBContext: DbContext
    {
        public LivrariaDBContext(DbContextOptions options) : base(options) { }

        public DbSet<Livro> Livros { get; set; }
    }
}
