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
    public class TipoDocumentoController : ControllerBase
    {
        private MicroEmprendedorContext _db;
        private readonly ILogger<TipoDocumentoController> _logger;

        public TipoDocumentoController(MicroEmprendedorContext db, ILogger<TipoDocumentoController> logger)
        {
            _db = db;
            _logger = logger;
        }

        [HttpGet]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetTipoDocumentoes(/*int pagesize, int pagenumber*/)
        {
            _logger.LogInformation("Fetching Todas las TipoDocumentos");

            List<TipoDocumento> rptListaTipoDocumento = new List<TipoDocumento>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerTipoDocumento", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaTipoDocumento.Add(new TipoDocumento()
                        {
                            Id = Convert.ToInt32(dr["Id"].ToString()),
                            DescA = dr["DescA"].ToString(),
                            DescC = dr["DescC"].ToString()

                        });
                    }
                    dr.Close();
                    return Ok(rptListaTipoDocumento);
                }
                catch (Exception ex)
                {
                    rptListaTipoDocumento = null;
                    return null;
                }
            }
        }

        [HttpGet("GetTipoDocumentoById")]
        [Authorize]
        [ResponseCache(CacheProfileName = "apicache")]
        public ActionResult<TipoDocumento> GetTipoDocumentoById(int id)
        {

            if (id == 0)
            {
                _logger.LogError("Id de TipoDocumento no pasada");
                return BadRequest();
            }
            var TipoDocumento = _db.TipoDocumento.FirstOrDefault(x => x.Id == id);

            if (TipoDocumento == null)
            {
                return NotFound();
            }
            return TipoDocumento;
        }


        [HttpPost("AddTipoDocumento")]
        [Authorize]
        public ActionResult<TipoDocumento> AddTipoDocumento([FromBody] TipoDocumento TipoDocumento)
        {

            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarTipoDocumento", oconexion);
                    cmd.Parameters.AddWithValue("DescA", TipoDocumento.DescA);
                    cmd.Parameters.AddWithValue("DescC", TipoDocumento.DescC);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    TipoDocumento.Id = Convert.ToInt32(cmd.Parameters["Resultado"].Value);

                }
            }
            catch (Exception ex)
            {
                //    idautogenerado = 0;
                // Mensaje = ex.Message;
            }

            return Ok(TipoDocumento);

        }

        [HttpPost("UpdateTipoDocumento")]
        [Authorize]
        public ActionResult<TipoDocumento> UpdateTipoDocumento(Int32 Id, [FromBody] TipoDocumento TipoDocumento)
        {
            bool resultado = false;
            // Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EditarTipoDocumento", oconexion);
                    cmd.Parameters.AddWithValue("Id", TipoDocumento.Id);
                    cmd.Parameters.AddWithValue("DescA", TipoDocumento.DescA);
                    cmd.Parameters.AddWithValue("DescC", TipoDocumento.DescC);
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
            return Ok(TipoDocumento);

        }

        [HttpPut("DeleteTipoDocumento")]
        [Authorize(Roles = "Admin")]
        public ActionResult<TipoDocumento> DeleteTipoDocumento(Int32 Id)
        {
            bool resultado = false;
            //Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarTipoDocumento", oconexion);
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
