using Microsoft.EntityFrameworkCore;
using ProveedorScreeningAPI.Models;

namespace ProveedorScreeningAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Proveedor> Proveedores { get; set; }  // Tabla de proveedores
        public DbSet<Usuario> Usuarios { get; set; } // Lista de usuarios
    }
}
