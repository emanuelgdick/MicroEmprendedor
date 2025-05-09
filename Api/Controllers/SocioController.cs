using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocioController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<SocioController> _logger;

        public SocioController(BibliotecaContext db, ILogger<SocioController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetSocio(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Socio");
            var SocioList = _db.Socio.ToList();
            return Ok(SocioList);

        }

        [HttpGet("GetSocioById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Socio> GetSocioById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Socio no pasada");
                return BadRequest();
            }
            var Socio = _db.Socio.FirstOrDefault(x => x.Id == id);

            if (Socio == null)
            {
                return NotFound();
            }
            return Socio;
        }


        //[HttpGet("GetLastSocio")]
        //[Authorize]
        //[ResponseCache(CacheProfileName = "apicache")]
        //public ActionResult<Socio> GetLastSocio()
        //{
        //    var Socio = _db.Socio.LastOrDefault();

        //    if (Socio == null)
        //    {
        //        return NotFound();
        //    }
        //    return Socio;
        //}



        [HttpPost("AddSocio")]
        [Authorize]
        public ActionResult<Socio> AddSocio([FromBody] Socio Socio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Socio.Add(Socio);
            _db.SaveChanges();
            return Ok(Socio);

        }

        [HttpPost("UpdateSocio")]
        [Authorize]
        public ActionResult<Socio> UpdateSocio(Int32 Id, [FromBody] Socio socio)
        {
            if (socio == null)
            {
                return BadRequest(socio);
            }

            var Socio = _db.Socio.FirstOrDefault(x => x.Id == Id);
            if (Socio == null)
            {
                return NotFound();
            }

            Socio.ApeyNom = Socio.ApeyNom;
            _db.SaveChanges();
            return Ok(Socio);

        }

        [HttpPut("DeleteSocio")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Socio> DeleteSocio(Int32 Id)
        {
            var Socio = _db.Socio.FirstOrDefault(x => x.Id == Id);
            if (Socio == null)
            {
                return NotFound();
            }
            _db.Remove(Socio);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
