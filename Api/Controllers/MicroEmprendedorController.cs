using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Xml.Linq;

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
            _logger.LogInformation("Fetching Todas las MicroEmprendedores");

            List<MicroEmprendedor> rptListaMicroEmprendedor = new List<MicroEmprendedor>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerMicroEmprendedor", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        rptListaMicroEmprendedor.Add(new MicroEmprendedor()
                        {
                            Id = Convert.ToInt32(dr["Id"].ToString()),
                            ApeyNom = dr["ApeyNom"].ToString(),
                            Dni = dr["Dni"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),//.ToString("dd/MM/yyyy"),
                           // Sexo = dr["Sexo"].ToString(),
                            Calle = dr["Calle"].ToString(),
                            Nro = dr["Nro"].ToString(),
                            Piso = dr["Piso"].ToString(),
                            Depto = dr["Depto"].ToString(),
                            TelFijo = dr["TelFijo"].ToString(),
                            TelCelular = dr["TelCelular"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            SitioWeb = dr["Sitioweb"].ToString(),
                            Instagram = dr["Instagram"].ToString(),
                            Facebook = dr["Facebook"].ToString(),
                            Observaciones = dr["Observaciones"].ToString(),
                           // Rubros = new RubroController().Listar(Convert.ToInt32(dr["Id"].ToString()))

                        });
                    }
                    dr.Close();
                    return Ok(rptListaMicroEmprendedor);
                }
                catch (Exception ex)
                {
                    rptListaMicroEmprendedor = null;
                    return null;
                }
            }
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
            int idautogenerado = 0;
            try
            {
                XElement microRubro = new XElement("MicroEmprendedor",
                     new XElement("IdtipoDocumento", microEmprendedor.IdTipoDocumento),
                     new XElement("IdLocalidad", microEmprendedor.IdLocalidad),
                     new XElement("ApeyNom", microEmprendedor.ApeyNom),
                     new XElement("Dni", microEmprendedor.Dni),
                     new XElement("FechaNacimiento", Convert.ToDateTime(microEmprendedor.FechaNacimiento)),
                     new XElement("Sexo", microEmprendedor.Sexo),
                     new XElement("Calle", microEmprendedor.Calle),
                     new XElement("Nro", microEmprendedor.Nro),
                     new XElement("Piso", microEmprendedor.Piso),
                     new XElement("Depto", microEmprendedor.Depto),
                     new XElement("TelFijo", microEmprendedor.TelFijo),
                     new XElement("TelCelular", microEmprendedor.TelCelular),
                     new XElement("Correo", microEmprendedor.Correo),
                     new XElement("SitioWeb", microEmprendedor.SitioWeb),
                     new XElement("Instagram", microEmprendedor.Instagram),
                     new XElement("FaceBook", microEmprendedor.Facebook),
                     new XElement("Observaciones", microEmprendedor.Observaciones)
                     );
                XElement microEmprendedorRubro = new XElement("MicroEmprendedorRubro");
                if (microEmprendedor.Rubros != null)
                {
                    foreach (MicroEmprendedorRubro item in microEmprendedor.Rubros)
                    {
                        microEmprendedorRubro.Add(new XElement("Item",

                                new XElement("IdMicroEmprendedor", item.IdMicroEmprendedor), // idUsuario
                                new XElement("IdRubro", item.IdRubro)
                            ));
                    }
                }
                microRubro.Add(microEmprendedorRubro);





                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarMicroEmprendedor", oconexion);
                    cmd.Parameters.Add("MicroEmprendedor", SqlDbType.Xml).Value = microRubro.ToString();
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                   // Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                idautogenerado = 0;
              //  Mensaje = ex.Message;
            }
            return Ok(microEmprendedor);

        }

        [HttpPost("UpdateMicroEmprendedor")]
        [Authorize]
        public ActionResult<MicroEmprendedor> UpdateMicroEmprendedor(Int32 Id, [FromBody] MicroEmprendedor microEmprendedor)
        {
            XElement microRubro = new XElement("MicroEmprendedor",
            new XElement("IdtipoDocumento", microEmprendedor.IdTipoDocumento),
            new XElement("IdLocalidad", microEmprendedor.IdLocalidad),
            new XElement("ApeyNom", microEmprendedor.ApeyNom),
            new XElement("Dni", microEmprendedor.Dni),
            new XElement("FechaNacimiento", Convert.ToDateTime(microEmprendedor.FechaNacimiento)),
            new XElement("Sexo", microEmprendedor.Sexo),
            new XElement("Calle", microEmprendedor.Calle),
            new XElement("Nro", microEmprendedor.Nro),
            new XElement("Piso", microEmprendedor.Piso),
            new XElement("Depto", microEmprendedor.Depto),
            new XElement("TelFijo", microEmprendedor.TelFijo),
            new XElement("TelCelular", microEmprendedor.TelCelular),
            new XElement("Correo", microEmprendedor.Correo),
            new XElement("SitioWeb", microEmprendedor.SitioWeb),
            new XElement("Instagram", microEmprendedor.Instagram),
            new XElement("FaceBook", microEmprendedor.Facebook),
            new XElement("Observaciones", microEmprendedor.Observaciones)
        );
            XElement microEmprendedorRubro = new XElement("MicroEmprendedorRubro");
            if (microEmprendedor.Rubros != null)
            {
                foreach (MicroEmprendedorRubro item in microEmprendedor.Rubros)
                {
                    microEmprendedorRubro.Add(new XElement("Item",

                            new XElement("IdMicroEmprendedor", item.IdMicroEmprendedor), // idUsuario
                            new XElement("IdRubro", item.IdRubro)
                        ));
                }
            }
            microRubro.Add(microEmprendedorRubro);

            using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarMicroEmprendedor", oconexion);
                cmd.Parameters.Add("MicroEmprendedor", SqlDbType.Xml).Value = microRubro.ToString();
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                oconexion.Open();
                cmd.ExecuteNonQuery();
                //idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
                // Mensaje = cmd.Parameters["Mensaje"].Value.ToString();
            }
            return Ok(microEmprendedor);
        }
            

        

        [HttpPut("DeleteMicroEmprendedor")]
        [Authorize(Roles = "Admin")]
        public ActionResult<MicroEmprendedor> DeleteMicroEmprendedor(Int32 Id)
        {
            bool resultado = false;
            //Mensaje = string.Empty;
            try
            {
                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_EliminarMicroEmprendedor", oconexion);
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
