using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdiomaController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<IdiomaController> _logger;

        public IdiomaController(BibliotecaContext db, ILogger<IdiomaController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetIdiomas(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Idiomas");
            var IdiomaList = _db.Idioma.ToList();
            return Ok(IdiomaList);

        }

        [HttpGet("GetIdiomaById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Idioma> GetIdiomaById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Idioma no pasada");
                return BadRequest();
            }
            var Idioma = _db.Idioma.FirstOrDefault(x => x.Id == id);

            if (Idioma == null)
            {
                return NotFound();
            }
            return Idioma;
        }


        [HttpPost("AddIdioma")]
        [Authorize]
        public ActionResult<Idioma> AddIdioma([FromBody] Idioma idioma)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Idioma.Add(idioma);
            _db.SaveChanges();
            return Ok(idioma);

        }

        [HttpPost("UpdateIdioma")]
        [Authorize]
        public ActionResult<Idioma> UpdateIdioma(Int32 Id, [FromBody] Idioma idioma)
        {
            if (idioma == null)
            {
                return BadRequest(idioma);
            }

            var Idioma = _db.Idioma.FirstOrDefault(x => x.Id == Id);
            if (Idioma == null)
            {
                return NotFound();
            }

            Idioma.Descripcion = idioma.Descripcion;
            _db.SaveChanges();
            return Ok(Idioma);

        }

        [HttpPut("DeleteIdioma")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Idioma> DeleteIdioma(Int32 Id)
        {
            var Idioma = _db.Idioma.FirstOrDefault(x => x.Id == Id);
            if (Idioma == null)
            {
                return NotFound();
            }
            _db.Remove(Idioma);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
