using Microsoft.AspNetCore.Mvc;
using ProveedorScreeningAPI.Models;
using Microsoft.EntityFrameworkCore;
using ProveedorScreeningAPI.Data;
using Microsoft.AspNetCore.Authorization;

namespace ProveedorScreeningAPI.Controllers
{
    [Authorize]
    // /api/proveedor
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProveedorController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Función para verificar si el proveedor existe en la base de datos
        private bool ProveedorExists(int id)
        {
            return _context.Proveedores.Any(e => e.Id == id);
        }

        // GET: api/proveedor
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedor>>> GetProveedores()
        {
            return await _context.Proveedores.ToListAsync();
        }

        // GET: api/proveedor/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedor>> GetProveedor(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
            {
                return NotFound();
            }

            return proveedor;
        }

        // POST: api/proveedor
        [HttpPost]
        public async Task<ActionResult<Proveedor>> PostProveedor(Proveedor proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProveedor", new { id = proveedor.Id }, proveedor);
        }

        // PUT: api/proveedor/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, Proveedor proveedor)
        {
            if (id != proveedor.Id)
            {
                return BadRequest(new { message = "El ID del proveedor no coincide con el ID de la URL" });
            }

            // Verificar si el proveedor existe
            if (!ProveedorExists(id))
            {
                return NotFound(new { message = "Proveedor no encontrado" });
            }

            // Establecer el estado del proveedor como modificado
            _context.Entry(proveedor).State = EntityState.Modified;

            try
            {
                // Guardamos los cambios en la base de datos
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, new { message = "Error al actualizar el proveedor" });
            }

            // Retornar el proveedor actualizado como respuesta
            return Ok(proveedor);
        }

        // DELETE: api/proveedor/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
