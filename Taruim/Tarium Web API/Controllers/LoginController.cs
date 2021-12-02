using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using Tarium_Web_API.Contexts.TariumMainDB;
using Tarium_Web_API.Contexts.TariumMainDB.Models;

namespace Tarium_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TariumMainDB_Context _context;

        public LoginController(TariumMainDB_Context context)
        {
            _context = context;
        }

        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioDTO>> PostToken(Usuario usuario)
        {
            Usuario foundUsuario = await _context.Usuarios.SingleOrDefaultAsync(_usuario => _usuario.Correo == usuario.Correo);

            if (foundUsuario != null && foundUsuario.Clave == usuario.Clave)
            {
                Token Tokens = new Token()
                {
                    Hash = Guid.NewGuid().ToString(),
                    Id_Usuario = foundUsuario.Id
                };

                await _context.Tokens.AddAsync(Tokens);

                return new UsuarioDTO()
                {
                    Hash = Tokens.Hash,
                    Nombre = foundUsuario.Nombre,
                    Rol = foundUsuario.Rol
                };
            }
            else
            {
                return NotFound();
            }
        }

        public class UsuarioDTO
        {
            public string Hash { get; set; }
            public string Nombre { get; set; }
            public int Rol { get; set; }
        }
    }
}
