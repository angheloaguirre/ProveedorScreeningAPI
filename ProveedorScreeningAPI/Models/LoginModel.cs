using System.ComponentModel.DataAnnotations;

namespace ProveedorScreeningAPI.Models
{
    public class LoginModel
    {
        // Nombre de usuario proporcionado para el login
        [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
        public required string Username { get; set; }

        // Contraseña proporcionada para el login
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        public required string Password { get; set; }
    }
}