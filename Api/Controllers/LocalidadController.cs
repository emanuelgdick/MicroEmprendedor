using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadController : ControllerBase
    {
        private MicroEmprendedorContext _db;
        private readonly ILogger<LocalidadController> _logger;

        public LocalidadController(MicroEmprendedorContext db, ILogger<LocalidadController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetLocalidades(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las Localidads");

            List<Localidad> rptListaLocalidad = new List<Localidad>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerLocalidad", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaLocalidad.Add(new Localidad()
                        {
                            Id = Convert.ToInt32(dr["Id"].ToString()),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                    dr.Close();
                    return Ok(rptListaLocalidad);
                }
                catch (Exception ex)
                {
                    rptListaLocalidad = null;
                    return null;
                }
            }
        }

        [HttpGet("GetLocalidadById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Localidad> GetLocalidadById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Localidad no pasada");
                return BadRequest();
            }
            var Localidad = _db.Localidad.FirstOrDefault(x => x.Id == id);

            if (Localidad == null)
            {
                return NotFound();
            }
            return Localidad;
        }


        [HttpPost("AddLocalidad")]
        [Authorize]
        public ActionResult<Localidad> AddLocalidad([FromBody] Localidad localidad)
        {
          
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarLocalidad", oconexion);
                    cmd.Parameters.AddWithValue("Descripcion", localidad.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    localidad.Id = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                }
            }
            catch (Exception ex)
            {
            //    idautogenerado = 0;
               // Mensaje = ex.Message;
            }
          
            return Ok(localidad);

        }

        [HttpPost("UpdateLocalidad")]
        [Authorize]
        public ActionResult<Localidad> UpdateLocalidad(Int32 Id, [FromBody] Localidad localidad)
        {
            bool resultado = false;
           // Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarLocalidad", oconexion);
                    cmd.Parameters.AddWithValue("Id", localidad.Id);
                    cmd.Parameters.AddWithValue("Descripcion", localidad.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                   // Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
             //   Mensaje = ex.Message;
            }
            return Ok(localidad);

        }

        [HttpPut("DeleteLocalidad")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Localidad> DeleteLocalidad(Int32 Id)
        {
            bool resultado = false;
            //Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarLocalidad", oconexion);
                    cmd.Parameters.AddWithValue("Id", Id);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                 //   Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                //Mensaje = ex.Message;
            }
            return NoContent();
        }
    }
}
