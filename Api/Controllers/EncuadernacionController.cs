using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EncuadernacionController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<EncuadernacionController> _logger;

        public EncuadernacionController(BibliotecaContext db, ILogger<EncuadernacionController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetEncuadernacion(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Encuadernacions");
            var EncuadernacionList = _db.Encuadernacion.ToList();
            return Ok(EncuadernacionList);

        }

        [HttpGet("GetEncuadernacionById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Encuadernacion> GetEncuadernacionById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Encuadernacion no pasada");
                return BadRequest();
            }
            var Encuadernacion = _db.Encuadernacion.FirstOrDefault(x => x.Id == id);

            if (Encuadernacion == null)
            {
                return NotFound();
            }
            return Encuadernacion;
        }


        [HttpPost("AddEncuadernacion")]
        [Authorize]
        public ActionResult<Encuadernacion> AddEncuadernacion([FromBody] Encuadernacion encuadernacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Encuadernacion.Add(encuadernacion);
            _db.SaveChanges();
            return Ok(encuadernacion);

        }

        [HttpPost("UpdateEncuadernacion")]
        [Authorize]
        public ActionResult<Encuadernacion> UpdateEncuadernacion(Int32 Id, [FromBody] Encuadernacion encuadernacion)
        {
            if (encuadernacion == null)
            {
                return BadRequest(encuadernacion);
            }

            var Encuadernacion = _db.Encuadernacion.FirstOrDefault(x => x.Id == Id);
            if (Encuadernacion == null)
            {
                return NotFound();
            }

            Encuadernacion.Descripcion = encuadernacion.Descripcion;
            _db.SaveChanges();
            return Ok(Encuadernacion);

        }

        [HttpPut("DeleteEncuadernacion")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Encuadernacion> DeleteEncuadernacion(Int32 Id)
        {
            var Encuadernacion = _db.Encuadernacion.FirstOrDefault(x => x.Id == Id);
            if (Encuadernacion == null)
            {
                return NotFound();
            }
            _db.Remove(Encuadernacion);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
