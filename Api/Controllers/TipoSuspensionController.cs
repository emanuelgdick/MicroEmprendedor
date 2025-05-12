using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoSuspensionController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<TipoSuspensionController> _logger;

        public TipoSuspensionController(BibliotecaContext db, ILogger<TipoSuspensionController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetTipoSuspensiones(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las TipoSuspensions");
            var TipoSuspensionList = _db.TipoSuspension.ToList();
            return Ok(TipoSuspensionList);

        }

        [HttpGet("GetTipoSuspensionById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<TipoSuspension> GetTipoSuspensionById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de TipoSuspension no pasada");
                return BadRequest();
            }
            var TipoSuspension = _db.TipoSuspension.FirstOrDefault(x => x.Id == id);

            if (TipoSuspension == null)
            {
                return NotFound();
            }
            return TipoSuspension;
        }


        [HttpPost("AddTipoSuspension")]
        [Authorize]
        public ActionResult<TipoSuspension> AddTipoSuspension([FromBody] TipoSuspension tipoSuspension)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.TipoSuspension.Add(tipoSuspension);
            _db.SaveChanges();
            return Ok(tipoSuspension);

        }

        [HttpPost("UpdateTipoSuspension")]
        [Authorize]
        public ActionResult<TipoSuspension> UpdateTipoSuspension(Int32 Id, [FromBody] TipoSuspension tipoSuspension)
        {
            if (tipoSuspension == null)
            {
                return BadRequest(tipoSuspension);
            }

            var TipoSuspension = _db.TipoSuspension.FirstOrDefault(x => x.Id == Id);
            if (TipoSuspension == null)
            {
                return NotFound();
            }

            TipoSuspension.Descripcion = tipoSuspension.Descripcion;
            _db.SaveChanges();
            return Ok(TipoSuspension);

        }

        [HttpPut("DeleteTipoSuspension")]
        [Authorize(Roles = "Admin")]
        public ActionResult<TipoSuspension> DeleteTipoSuspension(Int32 Id)
        {
            var TipoSuspension = _db.TipoSuspension.FirstOrDefault(x => x.Id == Id);
            if (TipoSuspension == null)
            {
                return NotFound();
            }
            _db.Remove(TipoSuspension);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
