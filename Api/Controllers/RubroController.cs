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
    public class RubroController : ControllerBase
    {
        private MicroEmprendedorContext _db;
        private readonly ILogger<RubroController> _logger;

     
        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetRubros(/*int pagesize, int pagenumber*/)
        {
        //    _logger.LogInformation("Fetching Todas las Rubros");

            List<Rubro> rptListaRubro = new List<Rubro>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerRubro", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaRubro.Add(new Rubro()
                        {
                            Id = Convert.ToInt32(dr["Id"].ToString()),
                            Descripcion = dr["Descripcion"].ToString()
                        });
                    }
                    dr.Close();
                    return Ok(rptListaRubro);
                }
                catch (Exception ex)
                {
                    rptListaRubro = null;
                    return null;
                }
            }
        }

        [HttpGet("GetRubroById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<Rubro> GetRubroById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de Rubro no pasada");
                return BadRequest();
            }
            var Rubro = _db.Rubro.FirstOrDefault(x => x.Id == id);

            if (Rubro == null)
            {
                return NotFound();
            }
            return Rubro;
        }


        [HttpPost("AddRubro")]
        [Authorize]
        public ActionResult<Rubro> AddRubro([FromBody] Rubro Rubro)
        {

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarRubro", oconexion);
                    cmd.Parameters.AddWithValue("Descripcion", Rubro.Descripcion);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    Rubro.Id = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                //    idautogenerado = 0;
                // Mensaje = ex.Message;
            }

            return Ok(Rubro);

        }

        [HttpPost("UpdateRubro")]
        [Authorize]
        public ActionResult<Rubro> UpdateRubro(Int32 Id, [FromBody] Rubro Rubro)
        {
            bool resultado = false;
            // Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarRubro", oconexion);
                    cmd.Parameters.AddWithValue("Id", Rubro.Id);
                    cmd.Parameters.AddWithValue("Descripcion", Rubro.Descripcion);
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
            return Ok(Rubro);

        }

        [HttpPut("DeleteRubro")]
        [Authorize(Roles = "Admin")]
        public ActionResult<Rubro> DeleteRubro(Int32 Id)
        {
            bool resultado = false;
            //Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarRubro", oconexion);
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
