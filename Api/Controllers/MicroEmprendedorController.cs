using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MicroEmprendedorController : ControllerBase
    {
        private MicroEmprendedorContext _db;
        private readonly ILogger<MicroEmprendedorController> _logger;

        public MicroEmprendedorController(MicroEmprendedorContext db, ILogger<MicroEmprendedorController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetMicroEmprendedores(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Paciente");

            // Obtener datos de las tablas
            var micro = _db.MicroEmprendedor.ToList();
            var loc = _db.Localidad.ToList();
            var tipoDoc = _db.TipoDocumento.OrderByDescending(s => s.DescA).ToList();
           // var microEmprendedorRubro = _db.MicroEmprendedorRubro.ToList();
         

            // Realizar la unión utilizando Join
            var resultado = (from m in micro
                             join l in loc on m.IdLocalidad equals l.Id into localidadMicroEmprendedor
                             join td in tipoDoc on m.IdTipoDocumento equals td.Id into tipoDocMicroEmprendedor
                             //join me in microEmprendedorRubro on m.Id equals me.IdMicroEmprendedor into meRubro
                             from loca in localidadMicroEmprendedor.DefaultIfEmpty()
                             from tipo in tipoDocMicroEmprendedor.DefaultIfEmpty()
                                 // from mer in meRubro.DefaultIfEmpty()
                             orderby m.ApeyNom
                             select new 
                             {
                                 Id = m.Id,
                                 IdTipoDocumento = m.IdTipoDocumento,
                                 IdLocalidad = m.IdLocalidad,
                                 ApeyNom = m.ApeyNom,
                                 Dni = m.Dni,
                                 FechaNacimiento = m.FechaNacimiento,
                                 Calle = m.Calle,
                                 Nro = m.Nro,
                                 Depto = m.Depto,
                                 Piso = m.Piso,
                                 TelCelular = m.TelCelular,
                                 TelFijo = m.TelFijo,
                                 Correo = m.Correo,
                                 Instagram = m.Instagram,
                                 Facebook = m.Facebook,
                                 SitioWeb = m.SitioWeb,
                                 Sexo = m.Sexo,
                                 Localidad = new Localidad
                                 {
                                     Id = loca.Id,
                                     Descripcion = loca.Descripcion
                                 }
                                 ,
                                 TipoDocumento = new TipoDocumento
                                 {
                                     Id = tipo.Id,
                                     DescA = tipo.DescA,
                                     DescC = tipo.DescC
                                 },
                                 Observaciones =m.Observaciones,
                                // Rubros =meRubro
                                                            
                             });

   
            return Ok(resultado);

        }



        [HttpGet("GetMicroEmprendedoresFiltrados")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetMicroEmprendedoresFiltrados(int localidad, int rubro)
        {
            _logger.LogInformation("Fetching Todas las Pacientes Filtrados");
            // Obtener datos de las tablas
            var micro = _db.MicroEmprendedor.ToList();
            var loc = _db.Localidad.ToList();
            var tipoDoc = _db.TipoDocumento.OrderByDescending(s => s.DescA).ToList();
            var rub = _db.Rubro.ToList();

            var resultado = (from m in micro
                             join l in loc
                             on m.IdLocalidad equals l.Id into localidadMicroEmprendedor

                             join td in tipoDoc on m.IdTipoDocumento equals td.Id into tipoDocMicroEmprendedor
                             from loca in localidadMicroEmprendedor.DefaultIfEmpty()
                             from tipo in tipoDocMicroEmprendedor.DefaultIfEmpty()
                             where ((m.IdLocalidad == localidad) && (localidad != 0) || (localidad == 0))
                             ///////////////////va el filtro MicroemprendedorRubro

                             orderby m.ApeyNom
                             select new MicroEmprendedor
                             {
                                 Id = m.Id,
                                 IdTipoDocumento = m.IdTipoDocumento,
                                 IdLocalidad = m.IdLocalidad,
                                 ApeyNom = m.ApeyNom,
                                 Dni = m.Dni,
                                 FechaNacimiento = m.FechaNacimiento,
                                 Calle = m.Calle,
                                 Nro = m.Nro,
                                 Depto = m.Depto,
                                 Piso = m.Piso,
                                 TelCelular = m.TelCelular,
                                 TelFijo = m.TelFijo,
                                 Correo = m.Correo,
                                 Instagram = m.Instagram,
                                 Facebook=m.Facebook,
                                 SitioWeb=m.SitioWeb,
                                 Sexo = m.Sexo,
                                 Localidad = new Localidad
                                 {
                                     Id = loca.Id,
                                     Descripcion = loca.Descripcion
                                 }
                                 ,
                                 TipoDocumento = new TipoDocumento
                                 {
                                     Id = tipo.Id,
                                     DescA = tipo.DescA,
                                     DescC = tipo.DescC
                                 },
                                 Observaciones = m.Observaciones
                                 //                             Consulta = consultaPaciente,
                             });
            return Ok(resultado);

        }




        [HttpGet("GetMicroEmprendedorById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<MicroEmprendedor> GetMicroEmprendedorById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de MicroEmprendedor no pasada");
                return BadRequest();
            }
            var MicroEmprendedor = _db.MicroEmprendedor.FirstOrDefault(x => x.Id == id);

            if (MicroEmprendedor == null)
            {
                return NotFound();
            }
            return MicroEmprendedor;
        }


        [HttpPost("AddMicroEmprendedor")]
        [Authorize]
        public ActionResult<MicroEmprendedor> AddMicroEmprendedor([FromBody] MicroEmprendedor microEmprendedor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _db.MicroEmprendedor.Add(microEmprendedor);
            _db.SaveChanges();


            return Ok(microEmprendedor);

        }

        [HttpPost("UpdateMicroEmprendedor")]
        [Authorize]
        public ActionResult<MicroEmprendedor> UpdateMicroEmprendedor(Int32 Id, [FromBody] MicroEmprendedor microEmprendedor)
        {
            if (microEmprendedor == null)
            {
                return BadRequest(microEmprendedor);
            }

            var MicroEmprendedor = _db.MicroEmprendedor.FirstOrDefault(x => x.Id == Id);
            if (MicroEmprendedor == null)
            {
                return NotFound();
            }

            MicroEmprendedor.ApeyNom = microEmprendedor.ApeyNom;
            MicroEmprendedor.Dni = microEmprendedor.Dni;
            MicroEmprendedor.Calle = microEmprendedor.Calle;
            MicroEmprendedor.Nro = microEmprendedor.Nro;
            MicroEmprendedor.Piso = microEmprendedor.Piso;
            MicroEmprendedor.Depto = microEmprendedor.Depto;
            MicroEmprendedor.TelFijo = microEmprendedor.TelFijo;
            MicroEmprendedor.TelCelular = microEmprendedor.TelCelular;
            MicroEmprendedor.Correo = microEmprendedor.Correo;
            MicroEmprendedor.Instagram = microEmprendedor.Instagram;
            MicroEmprendedor.Facebook = microEmprendedor.Facebook;
            MicroEmprendedor.SitioWeb = microEmprendedor.SitioWeb;
            MicroEmprendedor.FechaNacimiento = microEmprendedor.FechaNacimiento;
            MicroEmprendedor.Sexo = microEmprendedor.Sexo;
            MicroEmprendedor.IdTipoDocumento = microEmprendedor.IdTipoDocumento;
            MicroEmprendedor.IdLocalidad = microEmprendedor.IdLocalidad;
            //MicroEmprendedor.Rubros = microEmprendedor.Rubros;
            MicroEmprendedor.Observaciones = microEmprendedor.Observaciones;

            _db.SaveChanges();
            return Ok(MicroEmprendedor);

        }

        [HttpPut("DeleteMicroEmprendedor")]
        [Authorize(Roles = "Admin")]
        public ActionResult<MicroEmprendedor> DeleteMicroEmprendedor(Int32 Id)
        {
            var MicroEmprendedor = _db.MicroEmprendedor.FirstOrDefault(x => x.Id == Id);
            if (MicroEmprendedor == null)
            {
                return NotFound();
            }
            _db.Remove(MicroEmprendedor);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
