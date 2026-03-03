using Microsoft.EntityFrameworkCore;
using SupportManagement.Models;

namespace SupportManagement.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Ticket> Tickets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Software" },
            new Category { Id = 2, Name = "Hardware" },
            new Category { Id = 3, Name = "Redes" },
            new Category { Id = 4, Name = "Acessos" },
            new Category { Id = 5, Name = "Dúvidas" }
        );
    }
}