using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSoporteController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<TipoSoporteController> _logger;

        public TipoSoporteController(BibliotecaContext db, ILogger<TipoSoporteController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetTipoSoportes(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las TipoSoportes");
            var TipoSoporteList = _db.TipoSoporte.ToList();
            return Ok(TipoSoporteList);

        }

        [HttpGet("GetTipoSoporteById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<TipoSoporte> GetTipoSoporteById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de TipoSoporte no pasada");
                return BadRequest();
            }
            var TipoSoporte = _db.TipoSoporte.FirstOrDefault(x => x.Id == id);

            if (TipoSoporte == null)
            {
                return NotFound();
            }
            return TipoSoporte;
        }


        [HttpPost("AddTipoSoporte")]
        [Authorize]
        public ActionResult<TipoSoporte> AddTipoSoporte([FromBody] TipoSoporte tipoSoporte)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.TipoSoporte.Add(tipoSoporte);
            _db.SaveChanges();
            return Ok(tipoSoporte);

        }

        [HttpPost("UpdateTipoSoporte")]
        [Authorize]
        public ActionResult<TipoSoporte> UpdateTipoSoporte(Int32 Id, [FromBody] TipoSoporte tipoSoporte)
        {
            if (tipoSoporte == null)
            {
                return BadRequest(tipoSoporte);
            }

            var TipoSoporte = _db.TipoSoporte.FirstOrDefault(x => x.Id == Id);
            if (TipoSoporte == null)
            {
                return NotFound();
            }

            TipoSoporte.Descripcion = TipoSoporte.Descripcion;
            _db.SaveChanges();
            return Ok(TipoSoporte);

        }

        [HttpPut("DeleteTipoSoporte")]
        [Authorize(Roles = "Admin")]
        public ActionResult<TipoSoporte> DeleteTipoSoporte(Int32 Id)
        {
            var TipoSoporte = _db.TipoSoporte.FirstOrDefault(x => x.Id == Id);
            if (TipoSoporte == null)
            {
                return NotFound();
            }
            _db.Remove(TipoSoporte);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
