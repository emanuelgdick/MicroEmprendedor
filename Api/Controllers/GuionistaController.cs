using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuionistaController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<GuionistaController> _logger;

        public GuionistaController(BibliotecaContext db, ILogger<GuionistaController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetGuionistas(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Guionistas");
            var GuionistaList = _db.Guionista.ToList();
            return Ok(GuionistaList);

        }

        [HttpGet("GetGuionistaById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Guionista> GetGuionistaById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Guionista no pasada");
                return BadRequest();
            }
            var Guionista = _db.Guionista.FirstOrDefault(x => x.Id == id);

            if (Guionista == null)
            {
                return NotFound();
            }
            return Guionista;
        }


        [HttpPost("AddGuionista")]
        [Authorize]
        public ActionResult<Guionista> AddGuionista([FromBody] Guionista guionista)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Guionista.Add(guionista);
            _db.SaveChanges();
            return Ok(guionista);

        }

        [HttpPost("UpdateGuionista")]
        [Authorize]
        public ActionResult<Guionista> UpdateGuionista(Int32 Id, [FromBody] Guionista guionista)
        {
            if (guionista == null)
            {
                return BadRequest(guionista);
            }

            var Guionista = _db.Guionista.FirstOrDefault(x => x.Id == Id);
            if (Guionista == null)
            {
                return NotFound();
            }

            Guionista.Descripcion = guionista.Descripcion;
            _db.SaveChanges();
            return Ok(Guionista);

        }

        [HttpPut("DeleteGuionista")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Guionista> DeleteGuionista(Int32 Id)
        {
            var Guionista = _db.Guionista.FirstOrDefault(x => x.Id == Id);
            if (Guionista == null)
            {
                return NotFound();
            }
            _db.Remove(Guionista);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
