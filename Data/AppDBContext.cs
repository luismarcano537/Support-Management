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
}