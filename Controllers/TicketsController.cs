using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SupportManagement.Data;

namespace SupportManagement.Controllers;

public class TicketsController : Controller
{
    private readonly AppDbContext _context;
    
    public TicketsController(AppDbContext context)
    {
        _context = context;
    }
    
    // GET
    public async Task<IActionResult> Index()
    {
        var tickets = await _context.Tickets.Include(t => t.Category).ToListAsync();
        
        return View(tickets);
    }
    
}