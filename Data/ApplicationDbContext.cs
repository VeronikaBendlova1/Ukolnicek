using Microsoft.EntityFrameworkCore;
using Ukolnicek.Models;

namespace Ukolnicek.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

               public DbSet<Ukol> vsechnyukoly { get; set; }= default!;
    }
}
