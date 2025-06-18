using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;  // Importa las anotaciones para validaciones

namespace ProveedorScreeningAPI.Models
{
    public class Usuario : IdentityUser
    {
        public string? Role { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}