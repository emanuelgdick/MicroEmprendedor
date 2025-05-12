using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditoraController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<EditoraController> _logger;

        public EditoraController(BibliotecaContext db, ILogger<EditoraController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetEditoras(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Editoras");
            var EditoraList = _db.Editora.ToList();
            return Ok(EditoraList);

        }

        [HttpGet("GetEditoraById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Editora> GetEditoraById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Editora no pasada");
                return BadRequest();
            }
            var Editora = _db.Editora.FirstOrDefault(x => x.Id == id);

            if (Editora == null)
            {
                return NotFound();
            }
            return Editora;
        }


        [HttpPost("AddEditora")]
        [Authorize]
        public ActionResult<Editora> AddEditora([FromBody] Editora editora)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Editora.Add(editora);
            _db.SaveChanges();
            return Ok(editora);

        }

        [HttpPost("UpdateEditora")]
        [Authorize]
        public ActionResult<Editora> UpdateEditora(Int32 Id, [FromBody] Editora editora)
        {
            if (editora == null)
            {
                return BadRequest(editora);
            }

            var Editora = _db.Editora.FirstOrDefault(x => x.Id == Id);
            if (Editora == null)
            {
                return NotFound();
            }

            Editora.Descripcion = editora.Descripcion;
            _db.SaveChanges();
            return Ok(Editora);

        }

        [HttpPut("DeleteEditora")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Editora> DeleteEditora(Int32 Id)
        {
            var Editora = _db.Editora.FirstOrDefault(x => x.Id == Id);
            if (Editora == null)
            {
                return NotFound();
            }
            _db.Remove(Editora);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
