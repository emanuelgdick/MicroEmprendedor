using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoMaterialController : ControllerBase
    {
        private BibliotecaContext _db;
        private readonly ILogger<TipoMaterialController> _logger;

        public TipoMaterialController(BibliotecaContext db, ILogger<TipoMaterialController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetTipoMateriales(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las TipoMaterials");
            var TipoMaterialList = _db.TipoMaterial.ToList();
            return Ok(TipoMaterialList);

        }

        [HttpGet("GetTipoMaterialById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<TipoMaterial> GetTipoMaterialById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de TipoMaterial no pasada");
                return BadRequest();
            }
            var TipoMaterial = _db.TipoMaterial.FirstOrDefault(x => x.Id == id);

            if (TipoMaterial == null)
            {
                return NotFound();
            }
            return TipoMaterial;
        }


        [HttpPost("AddTipoMaterial")]
        [Authorize]
        public ActionResult<TipoMaterial> AddTipoMaterial([FromBody] TipoMaterial tipoMaterial)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.TipoMaterial.Add(tipoMaterial);
            _db.SaveChanges();
            return Ok(tipoMaterial);

        }

        [HttpPost("UpdateTipoMaterial")]
        [Authorize]
        public ActionResult<TipoMaterial> UpdateTipoMaterial(Int32 Id, [FromBody] TipoMaterial tipoMaterial)
        {
            if (tipoMaterial == null)
            {
                return BadRequest(tipoMaterial);
            }

            var TipoMaterial = _db.TipoMaterial.FirstOrDefault(x => x.Id == Id);
            if (TipoMaterial == null)
            {
                return NotFound();
            }

            TipoMaterial.Descripcion = tipoMaterial.Descripcion;
            _db.SaveChanges();
            return Ok(TipoMaterial);

        }

        [HttpPut("DeleteTipoMaterial")]
        [Authorize(Roles = "Admin")]
        public ActionResult<TipoMaterial> DeleteTipoMaterial(Int32 Id)
        {
            var TipoMaterial = _db.TipoMaterial.FirstOrDefault(x => x.Id == Id);
            if (TipoMaterial == null)
            {
                return NotFound();
            }
            _db.Remove(TipoMaterial);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
