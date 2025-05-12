using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoSocioController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<EstadoSocioController> _logger;

        public EstadoSocioController(BibliotecaContext db, ILogger<EstadoSocioController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetEstadoSocios(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las EstadoSocios");
            var EstadoSocioList = _db.EstadoSocio.ToList();
            return Ok(EstadoSocioList);

        }

        [HttpGet("GetEstadoSocioById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<EstadoSocio> GetEstadoSocioById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de EstadoSocio no pasada");
                return BadRequest();
            }
            var EstadoSocio = _db.EstadoSocio.FirstOrDefault(x => x.Id == id);

            if (EstadoSocio == null)
            {
                return NotFound();
            }
            return EstadoSocio;
        }


        [HttpPost("AddEstadoSocio")]
        [Authorize]
        public ActionResult<EstadoSocio> AddEstadoSocio([FromBody] EstadoSocio estadoSocio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.EstadoSocio.Add(estadoSocio);
            _db.SaveChanges();
            return Ok(estadoSocio);

        }

        [HttpPost("UpdateEstadoSocio")]
        [Authorize]
        public ActionResult<EstadoSocio> UpdateEstadoSocio(Int32 Id, [FromBody] EstadoSocio estadoSocio)
        {
            if (estadoSocio == null)
            {
                return BadRequest(estadoSocio);
            }

            var EstadoSocio = _db.EstadoSocio.FirstOrDefault(x => x.Id == Id);
            if (EstadoSocio == null)
            {
                return NotFound();
            }

            EstadoSocio.Descripcion = estadoSocio.Descripcion;
            _db.SaveChanges();
            return Ok(EstadoSocio);

        }

        [HttpPut("DeleteEstadoSocio")]
        [Authorize(Roles = "Admin")]
        public ActionResult<EstadoSocio> DeleteEstadoSocio(Int32 Id)
        {
            var EstadoSocio = _db.EstadoSocio.FirstOrDefault(x => x.Id == Id);
            if (EstadoSocio == null)
            {
                return NotFound();
            }
            _db.Remove(EstadoSocio);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
