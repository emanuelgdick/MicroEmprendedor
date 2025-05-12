using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSocioController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<TipoSocioController> _logger;

        public TipoSocioController(BibliotecaContext db, ILogger<TipoSocioController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetTipoSocios(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las TipoSocios");
            var TipoSocioList = _db.TipoSocio.ToList();
            return Ok(TipoSocioList);

        }

        [HttpGet("GetTipoSocioById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<TipoSocio> GetTipoSocioById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de TipoSocio no pasada");
                return BadRequest();
            }
            var TipoSocio = _db.TipoSocio.FirstOrDefault(x => x.Id == id);

            if (TipoSocio == null)
            {
                return NotFound();
            }
            return TipoSocio;
        }


        [HttpPost("AddTipoSocio")]
        [Authorize]
        public ActionResult<TipoSocio> AddTipoSocio([FromBody] TipoSocio tipoSocio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.TipoSocio.Add(tipoSocio);
            _db.SaveChanges();
            return Ok(tipoSocio);

        }

        [HttpPost("UpdateTipoSocio")]
        [Authorize]
        public ActionResult<TipoSocio> UpdateTipoSocio(Int32 Id, [FromBody] TipoSocio tipoSocio)
        {
            if (tipoSocio == null)
            {
                return BadRequest(tipoSocio);
            }

            var TipoSocio = _db.TipoSocio.FirstOrDefault(x => x.Id == Id);
            if (TipoSocio == null)
            {
                return NotFound();
            }

            TipoSocio.Descripcion = tipoSocio.Descripcion;
            
            _db.SaveChanges();
            return Ok(TipoSocio);

        }

        [HttpPut("DeleteTipoSocio")]
        [Authorize(Roles = "Admin")]
        public ActionResult<TipoSocio> DeleteTipoSocio(Int32 Id)
        {
            var TipoSocio = _db.TipoSocio.FirstOrDefault(x => x.Id == Id);
            if (TipoSocio == null)
            {
                return NotFound();
            }
            _db.Remove(TipoSocio);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
