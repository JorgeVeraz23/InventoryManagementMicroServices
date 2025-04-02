using Microsoft.EntityFrameworkCore;
using Productos.API.Entity;

namespace Productos.API
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
     : base(options)
        {

        }

        public DbSet<Product> Productss { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<StoredFile> StoredFiles { get; set; }


    }
}
