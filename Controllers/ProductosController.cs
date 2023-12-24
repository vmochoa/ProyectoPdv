using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoPDV.Models;

namespace ProyectoPDV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly DBREACT_VENTAContext _context;

        public ProductosController(DBREACT_VENTAContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetProductos")]
        public IActionResult GetProductos()
        {
            List<ProductosFinale> productos = _context.ProductosFinales.ToList();
            return StatusCode(StatusCodes.Status200OK, productos);
        }

    }   
}
