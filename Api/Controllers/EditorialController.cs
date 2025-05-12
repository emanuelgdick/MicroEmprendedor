using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<EditorialController> _logger;

        public EditorialController(BibliotecaContext db, ILogger<EditorialController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetEditoriales(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Editorials");
            var EditorialList = _db.Editorial.ToList();
            return Ok(EditorialList);

        }

        [HttpGet("GetEditorialById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Editorial> GetEditorialById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Editorial no pasada");
                return BadRequest();
            }
            var Editorial = _db.Editorial.FirstOrDefault(x => x.Id == id);

            if (Editorial == null)
            {
                return NotFound();
            }
            return Editorial;
        }


        [HttpPost("AddEditorial")]
        [Authorize]
        public ActionResult<Editorial> AddEditorial([FromBody] Editorial editorial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Editorial.Add(editorial);
            _db.SaveChanges();
            return Ok(editorial);

        }

        [HttpPost("UpdateEditorial")]
        [Authorize]
        public ActionResult<Editorial> UpdateEditorial(Int32 Id, [FromBody] Editorial editorial)
        {
            if (editorial == null)
            {
                return BadRequest(editorial);
            }

            var Editorial = _db.Editorial.FirstOrDefault(x => x.Id == Id);
            if (Editorial == null)
            {
                return NotFound();
            }

            Editorial.Descripcion = editorial.Descripcion;
            _db.SaveChanges();
            return Ok(Editorial);

        }

        [HttpPut("DeleteEditorial")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Editorial> DeleteEditorial(Int32 Id)
        {
            var Editorial = _db.Editorial.FirstOrDefault(x => x.Id == Id);
            if (Editorial == null)
            {
                return NotFound();
            }
            _db.Remove(Editorial);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
