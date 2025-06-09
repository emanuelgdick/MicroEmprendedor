using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private ConsultorioContext _db;
        private readonly ILogger<TipoDocumentoController> _logger;

        public TipoDocumentoController(ConsultorioContext db, ILogger<TipoDocumentoController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetTipoDocumentos(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las TipoDocumentos");
            var TipoDocumentoList = _db.TipoDocumento.ToList();
            return Ok(TipoDocumentoList);

        }

        [HttpGet("GetTipoDocumentoById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<TipoDocumento> GetTipoDocumentoById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de TipoDocumento no pasada");
                return BadRequest();
            }
            var TipoDocumento = _db.TipoDocumento.FirstOrDefault(x => x.Id == id);

            if (TipoDocumento == null)
            {
                return NotFound();
            }
            return TipoDocumento;
        }


        [HttpPost("AddTipoDocumento")]
        [Authorize]
        public ActionResult<TipoDocumento> AddTipoDocumento([FromBody] TipoDocumento tipoDocumento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.TipoDocumento.Add(tipoDocumento);
            _db.SaveChanges();
            return Ok(tipoDocumento);

        }

        [HttpPost("UpdateTipoDocumento")]
        [Authorize]
        public ActionResult<TipoDocumento> UpdateTipoDocumento(Int32 Id, [FromBody] TipoDocumento tipoDocumento)
        {
            if (tipoDocumento == null)
            {
                return BadRequest(tipoDocumento);
            }

            var TipoDocumento = _db.TipoDocumento.FirstOrDefault(x => x.Id == Id);
            if (TipoDocumento == null)
            {
                return NotFound();
            }

            TipoDocumento.DescA = tipoDocumento.DescA;
            TipoDocumento.DescC = tipoDocumento.DescC;
            _db.SaveChanges();
            return Ok(TipoDocumento);

        }

        [HttpPut("DeleteTipoDocumento")]
        [Authorize(Roles = "Admin")]
        public ActionResult<TipoDocumento> DeleteTipoDocumento(Int32 Id)
        {
            var TipoDocumento = _db.TipoDocumento.FirstOrDefault(x => x.Id == Id);
            if (TipoDocumento == null)
            {
                return NotFound();
            }
            _db.Remove(TipoDocumento);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
