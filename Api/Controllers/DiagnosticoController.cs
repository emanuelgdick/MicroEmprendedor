using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiagnosticoController : ControllerBase
    {
        private ConsultorioContext _db;
        private readonly ILogger<DiagnosticoController> _logger;

        public DiagnosticoController(ConsultorioContext db, ILogger<DiagnosticoController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetDiagnosticoes(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todos las Diagnosticos");
            var DiagnosticoList = _db.Diagnostico.ToList();
            return Ok(DiagnosticoList);

        }

        [HttpGet("GetDiagnosticoById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Diagnostico> GetDiagnosticoById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Diagnostico no pasada");
                return BadRequest();
            }
            var Diagnostico = _db.Diagnostico.FirstOrDefault(x => x.Id == id);

            if (Diagnostico == null)
            {
                return NotFound();
            }
            return Diagnostico;
        }


        [HttpPost("AddDiagnostico")]
        [Authorize]
        public ActionResult<Diagnostico> AddDiagnostico([FromBody] Diagnostico diagnostico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Diagnostico.Add(diagnostico);
            _db.SaveChanges();
            return Ok(diagnostico);

        }

        [HttpPost("UpdateDiagnostico")]
        [Authorize]
        public ActionResult<Diagnostico> UpdateDiagnostico(Int32 Id, [FromBody] Diagnostico diagnostico)
        {
            if (diagnostico == null)
            {
                return BadRequest(diagnostico);
            }

            var Diagnostico = _db.Diagnostico.FirstOrDefault(x => x.Id == Id);
            if (Diagnostico == null)
            {
                return NotFound();
            }

            Diagnostico.Descripcion = diagnostico.Descripcion;
            _db.SaveChanges();
            return Ok(Diagnostico);

        }

        [HttpPut("DeleteDiagnostico")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Diagnostico> DeleteDiagnostico(Int32 Id)
        {
            var Diagnostico = _db.Diagnostico.FirstOrDefault(x => x.Id == Id);
            if (Diagnostico == null)
            {
                return NotFound();
            }
            _db.Remove(Diagnostico);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
