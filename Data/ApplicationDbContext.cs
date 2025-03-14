using Microsoft.EntityFrameworkCore;
using Sandbox.Models;

namespace Sandbox.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Artist> Artists { get; set; }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );
        
        // Adicionar configs de BD
    }
}