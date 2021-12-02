using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tarium_Web_API.Contexts.TariumMainDB;
using Tarium_Web_API.Contexts.TariumMainDB.Models;

namespace Tarium_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SucursalesController : ControllerBase
    {
        private readonly TariumMainDB_Context _context;

        public SucursalesController(TariumMainDB_Context context)
        {
            _context = context;
        }

        // GET: api/Sucursales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sucursal>>> GetSucursales()
        {
            return await _context.Sucursales.Include(sucursal => sucursal.Catalogos).ThenInclude(catalogos => catalogos.Producto).ToListAsync();
        }

        // GET: api/Sucursales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sucursal>> GetSucursal(int id)
        {
            var sucursal = await _context.Sucursales.Include(sucursal => sucursal.Catalogos).ThenInclude(catalogos => catalogos.Producto).SingleOrDefaultAsync(sucursal => sucursal.Id == id);

            if (sucursal == null)
            {
                return NotFound();
            }

            return sucursal;
        }

        // PUT: api/Sucursales/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSucursal(int id, Sucursal sucursal)
        {
            if (id != sucursal.Id)
            {
                return BadRequest();
            }

            _context.Entry(sucursal).State = EntityState.Modified;
            _context.Catalogos.RemoveRange(await _context.Catalogos.Where(catalogo => catalogo.Id_Sucursal == sucursal.Id).ToArrayAsync());

            try
            {
                await _context.SaveChangesAsync();

                _context.Catalogos.AddRange(sucursal.Catalogos);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SucursalExists(id))
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

        // POST: api/Sucursales
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Sucursal>> PostSucursal(Sucursal sucursal)
        {
            _context.Sucursales.Add(sucursal);
            await _context.SaveChangesAsync();

            foreach (Catalogo catalogo in sucursal.Catalogos)
            {
                catalogo.Id_Sucursal = sucursal.Id;
            }

            _context.Catalogos.AddRange(sucursal.Catalogos);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSucursal", new { id = sucursal.Id }, sucursal);
        }

        // DELETE: api/Sucursales/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSucursal(int id)
        {
            var sucursal = await _context.Sucursales.FindAsync(id);
            if (sucursal == null)
            {
                return NotFound();
            }

            _context.Sucursales.Remove(sucursal);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SucursalExists(int id)
        {
            return _context.Sucursales.Any(e => e.Id == id);
        }
    }
}
