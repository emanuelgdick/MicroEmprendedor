using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterpreteController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<InterpreteController> _logger;

        public InterpreteController(BibliotecaContext db, ILogger<InterpreteController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetInterpretes(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Interpretes");
            var InterpreteList = _db.Interprete.ToList();
            return Ok(InterpreteList);

        }

        [HttpGet("GetInterpreteById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Interprete> GetInterpreteById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Interprete no pasada");
                return BadRequest();
            }
            var Interprete = _db.Interprete.FirstOrDefault(x => x.Id == id);

            if (Interprete == null)
            {
                return NotFound();
            }
            return Interprete;
        }


        [HttpPost("AddInterprete")]
        [Authorize]
        public ActionResult<Interprete> AddInterprete([FromBody] Interprete interprete)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Interprete.Add(interprete);
            _db.SaveChanges();
            return Ok(interprete);

        }

        [HttpPost("UpdateInterprete")]
        [Authorize]
        public ActionResult<Interprete> UpdateInterprete(Int32 Id, [FromBody] Interprete interprete)
        {
            if (interprete == null)
            {
                return BadRequest(interprete);
            }

            var Interprete = _db.Interprete.FirstOrDefault(x => x.Id == Id);
            if (Interprete == null)
            {
                return NotFound();
            }

            Interprete.ApeyNom = Interprete.ApeyNom;
            _db.SaveChanges();
            return Ok(Interprete);

        }

        [HttpPut("DeleteInterprete")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Interprete> DeleteInterprete(Int32 Id)
        {
            var Interprete = _db.Interprete.FirstOrDefault(x => x.Id == Id);
            if (Interprete == null)
            {
                return NotFound();
            }
            _db.Remove(Interprete);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
