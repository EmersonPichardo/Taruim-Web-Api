using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tarium_Web_API.Contexts.TariumMainDB;
using Tarium_Web_API.Contexts.TariumMainDB.Models;

namespace Tarium_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntradasController : ControllerBase
    {
        private readonly TariumMainDB_Context _context;

        public EntradasController(TariumMainDB_Context context)
        {
            _context = context;
        }

        // GET: api/Transacciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaccion>>> GetTransacciones()
        {
            return await _context.Transacciones.Include(transaccion => transaccion.Sucursal).Include(transaccion => transaccion.Producto).Where(transaccion => transaccion.Tipo == "Entrada").ToListAsync();
        }

        // GET: api/Transacciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Transaccion>> GetTransaccion(int id)
        {
            var transaccion = await _context.Transacciones.Include(transaccion => transaccion.Sucursal).Include(transaccion => transaccion.Producto).SingleOrDefaultAsync(transaccion => transaccion.Id == id && transaccion.Tipo == "Entrada");

            if (transaccion == null)
            {
                return NotFound();
            }

            return transaccion;
        }

        // PUT: api/Transacciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransaccion(int id, Transaccion transaccion)
        {
            if (id != transaccion.Id)
            {
                return BadRequest();
            }

            var savedTransaccion = await _context.Transacciones.AsNoTracking().SingleOrDefaultAsync(transaccion => transaccion.Id == id);
            var catalogo = await _context.Catalogos.SingleOrDefaultAsync(catalogo => catalogo.Id_Sucursal == transaccion.Id_Sucursal && catalogo.Id_Producto == transaccion.Id_Producto);
            
            catalogo.Cantidad += transaccion.Cantidad - savedTransaccion.Cantidad;

            _context.Entry(catalogo).State = EntityState.Modified;
            _context.Entry(transaccion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransaccionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Transacciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Transaccion>> PostTransaccion(Transaccion transaccion)
        {
            var catalogo = await _context.Catalogos.SingleOrDefaultAsync(catalogo => catalogo.Id_Sucursal == transaccion.Id_Sucursal && catalogo.Id_Producto == transaccion.Id_Producto);
            catalogo.Cantidad += transaccion.Cantidad;

            _context.Entry(catalogo).State = EntityState.Modified;
            _context.Transacciones.Add(transaccion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransaccion", new { id = transaccion.Id }, transaccion);
        }

        // DELETE: api/Transacciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaccion(int id)
        {
            var transaccion = await _context.Transacciones.FindAsync(id);
            if (transaccion == null)
            {
                return NotFound();
            }

            var catalogo = await _context.Catalogos.SingleOrDefaultAsync(catalogo => catalogo.Id_Sucursal == transaccion.Id_Sucursal && catalogo.Id_Producto == transaccion.Id_Producto);
            catalogo.Cantidad -= transaccion.Cantidad;

            _context.Entry(catalogo).State = EntityState.Modified;
            _context.Transacciones.Remove(transaccion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransaccionExists(int id)
        {
            return _context.Transacciones.Any(e => e.Id == id);
        }
    }
}
