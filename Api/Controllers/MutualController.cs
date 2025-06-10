using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MutualController : ControllerBase
    {
        private ConsultorioContext _db;
        private readonly ILogger<MutualController> _logger;

        public MutualController(ConsultorioContext db, ILogger<MutualController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetMutuales(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Mutuales");
            var MutualList = _db.Mutual.ToList();
            return Ok(MutualList);

        }

        [HttpGet("GetMutualById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Mutual> GetMutualById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Mutual no pasada");
                return BadRequest();
            }
            var Mutual = _db.Mutual.FirstOrDefault(x => x.Id == id);

            if (Mutual == null)
            {
                return NotFound();
            }
            return Mutual;
        }


        [HttpPost("AddMutual")]
        [Authorize]
        public ActionResult<Mutual> AddMutual([FromBody] Mutual mutual)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Mutual.Add(mutual);
            _db.SaveChanges();
            return Ok(mutual);

        }

        [HttpPost("UpdateMutual")]
        [Authorize]
        public ActionResult<Mutual> UpdateMutual(Int32 Id, [FromBody] Mutual mutual)
        {
            if (mutual == null)
            {
                return BadRequest(mutual);
            }

            var Mutual = _db.Mutual.FirstOrDefault(x => x.Id == Id);
            if (Mutual == null)
            {
                return NotFound();
            }

            Mutual.DescA = mutual.DescA;
            Mutual.DescC = mutual.DescC;
            Mutual.Codigo = mutual.Codigo;

            _db.SaveChanges();
            return Ok(Mutual);

        }

        [HttpPut("DeleteMutual")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Mutual> DeleteMutual(Int32 Id)
        {
            var Mutual = _db.Mutual.FirstOrDefault(x => x.Id == Id);
            if (Mutual == null)
            {
                return NotFound();
            }
            _db.Remove(Mutual);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
