using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductorController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<ProductorController> _logger;

        public ProductorController(BibliotecaContext db, ILogger<ProductorController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetProductores(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Productors");
            var ProductorList = _db.Productor.ToList();
            return Ok(ProductorList);

        }

        [HttpGet("GetProductorById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Productor> GetProductorById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Productor no pasada");
                return BadRequest();
            }
            var Productor = _db.Productor.FirstOrDefault(x => x.Id == id);

            if (Productor == null)
            {
                return NotFound();
            }
            return Productor;
        }


        [HttpPost("AddProductor")]
        [Authorize]
        public ActionResult<Productor> AddProductor([FromBody] Productor productor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.Productor.Add(productor);
            _db.SaveChanges();
            return Ok(productor);

        }

        [HttpPost("UpdateProductor")]
        [Authorize]
        public ActionResult<Productor> UpdateProductor(Int32 Id, [FromBody] Productor productor)
        {
            if (productor == null)
            {
                return BadRequest(productor);
            }

            var Productor = _db.Productor.FirstOrDefault(x => x.Id == Id);
            if (Productor == null)
            {
                return NotFound();
            }

            Productor.Descripcion = Productor.Descripcion;
            _db.SaveChanges();
            return Ok(Productor);

        }

        [HttpPut("DeleteProductor")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Productor> DeleteProductor(Int32 Id)
        {
            var Productor = _db.Productor.FirstOrDefault(x => x.Id == Id);
            if (Productor == null)
            {
                return NotFound();
            }
            _db.Remove(Productor);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
