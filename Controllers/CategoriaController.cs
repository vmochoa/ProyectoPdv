using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoPDV.Models;

namespace ReactVentas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DBREACT_VENTAContext _context;
        public CategoriaController(DBREACT_VENTAContext context)
        {
            _context = context;

        }
        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> Lista()
        {
            List<Categorium> lista = new List<Categorium>();
            try
            {
                lista = await _context.Categoria.OrderByDescending(c => c.IdCategoria).ToListAsync();
                return StatusCode(StatusCodes.Status200OK, lista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, lista);
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> Guardar([FromBody] Categorium request) {
            try
            {
                await _context.Categoria.AddAsync(request);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch(Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Editar([FromBody] Categorium request) {
            try
            {
                _context.Categoria.Update(request);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex) {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            try
            {
                Categorium categoria = _context.Categoria.Find(id);
                if (categoria == null)
                {
                    return NotFound("Categoría no encontrada");
                }

                _context.Categoria.Remove(categoria);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "Categoría eliminada exitosamente");
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                if (ex.InnerException is Microsoft.Data.SqlClient.SqlException sqlEx && sqlEx.Number == 547)
                {
                    // Código de error 547 es para conflictos de clave foránea
                    return StatusCode(StatusCodes.Status409Conflict, "No se puede eliminar la categoría ya que está siendo utilizada por uno o más productos");
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Ocurrió un error al eliminar la categoría");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
