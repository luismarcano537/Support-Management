using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using SupportManagement.Models.Enums;

namespace SupportManagement.Models;

public class Ticket
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O título é obrigatório.")]
    [MaxLength(100)]
    public string Name { get; set; }

    [Required(ErrorMessage = "A descrição é obrigatória.")]
    public string Description { get; set; }

    public DateTime CreationDate { get; set; } = DateTime.UtcNow;

    public Status Situation { get; set; } = Status.Active;

    [Required(ErrorMessage = "O solicitante é obrigatório.")]
    [MaxLength(100)]
    public string Requester { get; set; }
    
    [Required(ErrorMessage = "A categoria é obrigatória.")]
    public int CategoryId { get; set; }
    
    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}