using Api.Models;
using FrontEnd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IlustradorController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<IlustradorController> _logger;

        public IlustradorController(BibliotecaContext db, ILogger<IlustradorController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetIlustradores()
        {
            _logger.LogInformation("Fetching Todas las Ilustradors");
            var IlustradorList = _db.Ilustrador.ToList();
            return Ok(IlustradorList);
        }

        [HttpGet("GetIlustradorById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Ilustrador> GetIlustradorById(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Id de Ilustrador no pasada");
                return BadRequest();
            }
            var Ilustrador = _db.Ilustrador.FirstOrDefault(x => x.Id == id);

            if (Ilustrador == null)
            {
                return NotFound();
            }
            return Ilustrador;
        }

        [HttpPost("AddIlustrador")]
        [Authorize]
        public ActionResult<Ilustrador> AddIlustrador([FromBody] Ilustrador ilustrador)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _db.Ilustrador.Add(ilustrador);
            _db.SaveChanges();
            return Ok(ilustrador);
        }

        [HttpPost("UpdateIlustrador")]
        [Authorize]
        public ActionResult<Ilustrador> UpdateIlustrador(Int32 Id, [FromBody] Ilustrador ilustrador)
        {
            if (ilustrador == null)
            {
                return BadRequest(ilustrador);
            }
            var ilus = _db.Ilustrador.FirstOrDefault(x => x.Id == Id);
            if (ilus == null)
            {
                return NotFound();
            }
            ilus.ApeyNom = ilustrador.ApeyNom;
            _db.SaveChanges();
            return Ok(ilus);
        }

        [HttpPut("DeleteIlustrador")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Ilustrador> DeleteIlustrador(Int32 Id)
        {
            var Ilustrador = _db.Ilustrador.FirstOrDefault(x => x.Id == Id);
            if (Ilustrador == null)
            {
                return NotFound();
            }
            _db.Remove(Ilustrador);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
