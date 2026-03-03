using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace SupportManagement.Models;

public class Category
{
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da categoria é obrigatório.")]
    [MaxLength(50)]
    public string Name { get; set; }
}