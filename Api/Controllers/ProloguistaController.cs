using Api.Models;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProloguistaController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<ProloguistaController> _logger;

        public ProloguistaController(BibliotecaContext db, ILogger<ProloguistaController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetProloguistaes()
        {
            _logger.LogInformation("Fetching Todas las Prologuistas");
            var ProloguistaList = _db.Prologuista.ToList();
            return Ok(ProloguistaList);

        }

        [HttpGet("GetProloguistaById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Prologuista> GetProloguistaById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Id de Prologuista no pasada");
                return BadRequest();
            }
            var Prologuista = _db.Prologuista.FirstOrDefault(x => x.Id == id);

            if (Prologuista == null)
            {
                return NotFound();
            }
            return Prologuista;
        }

        [HttpPost("AddProloguista")]
        [Authorize]
        public ActionResult<Prologuista> AddProloguista([FromBody] Prologuista prologuista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Prologuista.Add(prologuista);
            _db.SaveChanges();
            return Ok(prologuista);
        }

        [HttpPost("UpdateProloguista")]
        [Authorize]
        public ActionResult<Prologuista> UpdateProloguista(Int32 Id, [FromBody] Prologuista prologuista)
        {
            if (prologuista == null)
            {
                return BadRequest(prologuista);
            }
            var Prologuista = _db.Prologuista.FirstOrDefault(x => x.Id == Id);
            if (Prologuista == null)
            {
                return NotFound();
            }
            Prologuista.ApeyNom = Prologuista.ApeyNom;
            _db.SaveChanges();
            return Ok(Prologuista);

        }

        [HttpPut("DeleteProloguista")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Prologuista> DeleteProloguista(Int32 Id)
        {
            var Prologuista = _db.Prologuista.FirstOrDefault(x => x.Id == Id);
            if (Prologuista == null)
            {
                return NotFound();
            }
            _db.Remove(Prologuista);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
