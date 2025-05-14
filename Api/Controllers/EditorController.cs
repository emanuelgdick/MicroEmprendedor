using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<EditorController> _logger;

        public EditorController(BibliotecaContext db, ILogger<EditorController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetEditores(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Editores");
            var EditorList = _db.Editor.ToList();
            return Ok(EditorList);

        }

        [HttpGet("GetEditorById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Editor> GetEditorById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Editor no pasada");
                return BadRequest();
            }
            var Editor = _db.Editor.FirstOrDefault(x => x.Id == id);

            if (Editor == null)
            {
                return NotFound();
            }
            return Editor;
        }


        [HttpPost("AddEditor")]
        [Authorize]
        public ActionResult<Editor> AddEditor([FromBody] Editor editor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Editor.Add(editor);
            _db.SaveChanges();
            return Ok(editor);

        }

        [HttpPost("UpdateEditor")]
        [Authorize]
        public ActionResult<Editor> UpdateEditor(Int32 Id, [FromBody] Editor editor)
        {
            if (editor == null)
            {
                return BadRequest(editor);
            }

            var Editor = _db.Editor.FirstOrDefault(x => x.Id == Id);
            if (Editor == null)
            {
                return NotFound();
            }

            Editor.ApeyNom = Editor.ApeyNom;
            _db.SaveChanges();
            return Ok(Editor);

        }

        [HttpPut("DeleteEditor")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Editor> DeleteEditor(Int32 Id)
        {
            var Editor = _db.Editor.FirstOrDefault(x => x.Id == Id);
            if (Editor == null)
            {
                return NotFound();
            }
            _db.Remove(Editor);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
