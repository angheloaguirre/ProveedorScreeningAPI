using Microsoft.AspNetCore.Identity;
using ProveedorScreeningAPI.Models;

namespace ProveedorScreeningAPI.Data
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedAsync(ApplicationDbContext context, UserManager<Usuario> userManager)
        {
            // Si no existen usuarios en la tabla, agregamos uno nuevo
            if (!context.Usuarios.Any())
            {
                var user = new Usuario
                {
                    UserName = "admin",  // Nombre de usuario
                    Role = "Admin", // Rol
                    CreatedAt = DateTime.Now // Fecha de creación
                };

                // Hasheamos la contraseña antes de agregarla
                var passwordHasher = new PasswordHasher<Usuario>();
                user.PasswordHash = passwordHasher.HashPassword(user, "adminpassword");

                // Usamos UserManager para crear el usuario en la base de datos
                await userManager.CreateAsync(user);
            }
        }
    }
}
