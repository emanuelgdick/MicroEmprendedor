using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColeccionController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<ColeccionController> _logger;

        public ColeccionController(BibliotecaContext db, ILogger<ColeccionController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetColeccion(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Coleccions");
            var ColeccionList = _db.Coleccion.ToList();
            return Ok(ColeccionList);
        }

        [HttpGet("GetColeccionById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Coleccion> GetColeccionById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Id de Coleccion no pasada");
                return BadRequest();
            }
            var Coleccion = _db.Coleccion.FirstOrDefault(x => x.Id == id);

            if (Coleccion == null)
            {
                return NotFound();
            }
            return Coleccion;
        }

        [HttpPost("AddColeccion")]
        [Authorize]
        public ActionResult<Coleccion> AddColeccion([FromBody] Coleccion coleccion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Coleccion.Add(coleccion);
            _db.SaveChanges();
            return Ok(coleccion);
        }

        [HttpPost("UpdateColeccion")]
        [Authorize]
        public ActionResult<Coleccion> UpdateColeccion(Int32 Id, [FromBody] Coleccion coleccion)
        {
            if (coleccion == null)
            {
                return BadRequest(coleccion);
            }

            var Coleccion = _db.Coleccion.FirstOrDefault(x => x.Id == Id);
            if (Coleccion == null)
            {
                return NotFound();
            }

            Coleccion.Descripcion = coleccion.Descripcion;
            _db.SaveChanges();
            return Ok(Coleccion);
        }

        [HttpPut("DeleteColeccion")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Coleccion> DeleteColeccion(Int32 Id)
        {
            var Coleccion = _db.Coleccion.FirstOrDefault(x => x.Id == Id);
            if (Coleccion == null)
            {
                return NotFound();
            }
            _db.Remove(Coleccion);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
