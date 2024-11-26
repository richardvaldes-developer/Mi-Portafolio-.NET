using Microsoft.EntityFrameworkCore;
using ProyectoPortafolioRichard.Models;

namespace ProyectoPortafolioRichard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Project { get; set; }
        
        public DbSet<Experience> Experience { get; set; }
    }
}
