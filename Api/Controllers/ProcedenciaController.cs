using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedenciaController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<ProcedenciaController> _logger;

        public ProcedenciaController(BibliotecaContext db, ILogger<ProcedenciaController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetProcedencias(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Procedencias");
            var ProcedenciaList = _db.Procedencia.ToList();
            return Ok(ProcedenciaList);

        }

        [HttpGet("GetProcedenciaById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Procedencia> GetProcedenciaById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Procedencia no pasada");
                return BadRequest();
            }
            var Procedencia = _db.Procedencia.FirstOrDefault(x => x.Id == id);

            if (Procedencia == null)
            {
                return NotFound();
            }
            return Procedencia;
        }


        [HttpPost("AddProcedencia")]
        [Authorize]
        public ActionResult<Procedencia> AddProcedencia([FromBody] Procedencia procedencia)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Procedencia.Add(procedencia);
            _db.SaveChanges();
            return Ok(procedencia);

        }

        [HttpPost("UpdateProcedencia")]
        [Authorize]
        public ActionResult<Procedencia> UpdateProcedencia(Int32 Id, [FromBody] Procedencia procedencia)
        {
            if (procedencia == null)
            {
                return BadRequest(procedencia);
            }

            var Procedencia = _db.Procedencia.FirstOrDefault(x => x.Id == Id);
            if (Procedencia == null)
            {
                return NotFound();
            }

            Procedencia.Descripcion = procedencia.Descripcion;
            _db.SaveChanges();
            return Ok(Procedencia);

        }

        [HttpPut("DeleteProcedencia")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Procedencia> DeleteProcedencia(Int32 Id)
        {
            var Procedencia = _db.Procedencia.FirstOrDefault(x => x.Id == Id);
            if (Procedencia == null)
            {
                return NotFound();
            }
            _db.Remove(Procedencia);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
