using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPDV.Models;
using ProyectoPDV.Models.DTO;

namespace ReactVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly DBREACT_VENTAContext _context;
        public SessionController(DBREACT_VENTAContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] Dtosesion request)
        {
           
            if (string.IsNullOrEmpty(request.correo) || string.IsNullOrEmpty(request.clave))
            {
                return BadRequest("Correo y clave son requeridos.");
            }

            try
            {
                Usuario? usuario = _context.Usuarios.Include(u => u.IdRolNavigation)
                                                   .FirstOrDefault(u => u.Correo == request.correo);

             
                if (usuario == null)
                {
                    return NotFound("Usuario no encontrado.");
                }

                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error en el servidor.");
            }
        }
    }
}
