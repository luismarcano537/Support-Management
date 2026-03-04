using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SupportManagement.Data;
using SupportManagement.Models;

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

    //GET: Para retornar a tela do formulário
    public IActionResult Create()
    {
        ViewBag.Categorias = new SelectList(_context.Categories, "Id", "Name");
        return View();
    }

    //POST: Cria o ticket e persiste os dados no banco de dados
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Ticket ticket)
    {
        if (ModelState.IsValid)
        {
            _context.Add(ticket);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        ViewBag.Categorias = new SelectList(_context.Categories, "Id", "Name", ticket.CategoryId);
        return View(ticket);
    }

    // GET: Busca os dados e preenche a tela
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();

        var ticket = await _context.Tickets.FindAsync(id);
        if (ticket == null) return NotFound();

        ViewBag.Categorias = new SelectList(_context.Categories, "Id", "Name", ticket.CategoryId);
        return View(ticket);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Ticket ticket)
    {
        if (id != ticket.Id) return NotFound();
        
        ModelState.Remove("CreationDate");
        ModelState.Remove("Category");

        if (ModelState.IsValid)
        {
            try
            {
                var ticketDb = await _context.Tickets.FindAsync(id);
                if (ticketDb == null) return NotFound();
                
                ticketDb.Name = ticket.Name;
                ticketDb.Requester = ticket.Requester;
                ticketDb.CategoryId = ticket.CategoryId;
                ticketDb.Situation = ticket.Situation;
                ticketDb.Description = ticket.Description;
                
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tickets.Any(e => e.Id == ticket.Id)) return NotFound();
                else throw;
            }

            return RedirectToAction(nameof(Index));
        }
        
        ViewBag.Categorias = new SelectList(_context.Categories, "Id", "Name", ticket.CategoryId);
        return View(ticket);
    }
}
