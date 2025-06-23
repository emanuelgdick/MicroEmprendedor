using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private ConsultorioContext _db;
        private readonly ILogger<MedicoController> _logger;

        public MedicoController(ConsultorioContext db, ILogger<MedicoController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetMedicos(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Medicos");
            var MedicoList = _db.Medico.ToList();
            return Ok(MedicoList);

        }

        [HttpGet("GetMedicoById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Medico> GetMedicoById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Medico no pasada");
                return BadRequest();
            }
            var Medico = _db.Medico.FirstOrDefault(x => x.Id == id);

            if (Medico == null)
            {
                return NotFound();
            }
            return Medico;
        }


        [HttpGet("GetMedicosConAgenda")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Medico> GetMedicosConAgenda(int id)
        {
            
            var MedicoList = _db.Medico.Where(s=>s.TieneAgenda==true).ToList();
            return Ok(MedicoList);
        }





        [HttpPost("AddMedico")]
        [Authorize]
        public ActionResult<Medico> AddMedico([FromBody] Medico medico)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Medico.Add(medico);
            _db.SaveChanges();
            return Ok(medico);

        }

        [HttpPost("UpdateMedico")]
        [Authorize]
        public ActionResult<Medico> UpdateMedico(Int32 Id, [FromBody] Medico medico)
        {
            if (medico == null)
            {
                return BadRequest(medico);
            }

            var Medico = _db.Medico.FirstOrDefault(x => x.Id == Id);
            if (Medico == null)
            {
                return NotFound();
            }

            Medico.ApeyNom = medico.ApeyNom;
            Medico.TieneAgenda = medico.TieneAgenda;
            _db.SaveChanges();
            return Ok(Medico);

        }

        [HttpPut("DeleteMedico")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Medico> DeleteMedico(Int32 Id)
        {
            var Medico = _db.Medico.FirstOrDefault(x => x.Id == Id);
            if (Medico == null)
            {
                return NotFound();
            }
            _db.Remove(Medico);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
