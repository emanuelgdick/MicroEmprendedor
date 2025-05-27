using Api.Models;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnexoController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<AnexoController> _logger;

        public AnexoController(BibliotecaContext db, ILogger<AnexoController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetAnexos(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Anexos");
            var AnexoList = _db.Anexo.ToList();
            return Ok(AnexoList);

        }

        [HttpGet("GetAnexoById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Anexo> GetAnexoById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Anexo no pasada");
                return BadRequest();
            }
            var Anexo = _db.Anexo.FirstOrDefault(x => x.Id == id);

            if (Anexo == null)
            {
                return NotFound();
            }
            return Anexo;
        }


        [HttpPost("AddAnexo")]
        [Authorize]
        public ActionResult<Anexo> AddAnexo([FromBody] Anexo anexo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Anexo.Add(anexo);
            _db.SaveChanges();
            return Ok(anexo);

        }

        [HttpPost("UpdateAnexo")]
        [Authorize]
        public ActionResult<Anexo> UpdateAnexo(Int32 Id, [FromBody] Anexo anexo)
        {
            if (anexo == null)
            {
                return BadRequest(anexo);
            }

            var Anexo = _db.Anexo.FirstOrDefault(x => x.Id == Id);
            if (Anexo == null)
            {
                return NotFound();
            }

            Anexo.Descripcion = anexo.Descripcion;
            _db.SaveChanges();
            return Ok(Anexo);

        }

        [HttpPut("DeleteAnexo")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Anexo> DeleteAnexo(Int32 Id)
        {
            var Anexo = _db.Anexo.FirstOrDefault(x => x.Id == Id);
            if (Anexo == null)
            {
                return NotFound();
            }
            _db.Remove(Anexo);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
