using Microsoft.EntityFrameworkCore;
using Transacciones.API.Entity;

namespace Transacciones.API
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
            
        }

        public DbSet<Transaction> Transaction { get; set; }

    }
}
