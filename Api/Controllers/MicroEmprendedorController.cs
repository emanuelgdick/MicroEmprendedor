using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Xml;
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
        //[Authorize]
        //[ResponseCache(CacheProfileName = "apicache")]
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
                   
                    using (XmlReader dr = cmd.ExecuteXmlReader())
                    {
                        while (dr.Read())
                        {
                            XDocument doc = XDocument.Load(dr);
                            if (doc.Element("Data") != null)
                            {
                                rptListaMicroEmprendedor = (from c in doc.Element("Data").Elements("MicroEmprendedor")
                                                            select new MicroEmprendedor()
                                                            {
                                                                Id = Convert.ToInt32(c.Element("Id").Value),
                                                                IdTipoDocumento = Convert.ToInt32(c.Element("IdTipoDocumento").Value),
                                                                IdLocalidad = Convert.ToInt32(c.Element("IdLocalidad").Value),
                                                                ApeyNom = c.Element("ApeyNom").Value,
                                                                Calle = c.Element("Calle").Value,
                                                                Nro = c.Element("Nro").Value,
                                                                Piso = c.Element("Piso").Value,
                                                                Depto = c.Element("Depto").Value,
                                                                TelFijo = c.Element("TelFijo").Value,
                                                                TelCelular = c.Element("TelCelular").Value,
                                                                Facebook = c.Element("Facebook").Value,
                                                                Instagram = c.Element("Instagram").Value,
                                                                SitioWeb = c.Element("SitioWeb").Value,
                                                                Correo = c.Element("Correo").Value,
                                                                // Sexo = c.Element("Sexo").Value.ToString(),
                                                                Dni = c.Element("Dni").Value,
                                                                Observaciones = c.Element("Observaciones").Value,
                                                                FechaNacimiento = Convert.ToDateTime(c.Element("FechaNacimiento").Value.ToString()),
                                                                Localidad = (from g in c.Elements("Localidad")
                                                                             select new Localidad()
                                                                             {
                                                                                 Id = Convert.ToInt32(g.Element("Id").Value),
                                                                                 Descripcion = g.Element("Descripcion").Value
                                                                             }).FirstOrDefault(),
                                                                TipoDocumento = (from h in c.Elements("TipoDocumento")
                                                                                 select new TipoDocumento()
                                                                                 {
                                                                                     Id = Convert.ToInt32(h.Element("Id").Value),
                                                                                     DescA = h.Element("DescA").Value,
                                                                                     DescC = h.Element("DescC").Value

                                                                                 }).FirstOrDefault(),

                                                                Rubros = (from d in c.Elements("Rubros")
                                                                          select new MicroEmprendedorRubro()
                                                                          {
                                                                              IdMicroEmprendedor = Convert.ToInt32(d.Element("IdMicroEmprendedor").Value),
                                                                              IdRubro = Convert.ToInt32(d.Element("IdRubro").Value),
                                                                              Rubro =
                                                                                        new Rubro()
                                                                                        {
                                                                                            Id =Convert.ToInt32(d.Element("IdRubro").Value),
                                                                                            Descripcion = d.Element("Descripcion").Value
                                                                                        },
                                                                          }).ToList(),
                                                                PalabrasClave = (from d in c.Elements("PalabrasClave")
                                                                                 select new PalabraClave()
                                                                                 {
                                                                                     IdMicroEmprendedor = Convert.ToInt32(d.Element("IdMicroEmprendedor").Value),
                                                                                     Palabra =d.Element("Palabra").Value
                                                                                 }).ToList()



                                                            }).ToList();
                            }
                            else
                            {
                                rptListaMicroEmprendedor = new List<MicroEmprendedor>();
                            }
                        }

                        dr.Close();
                        return Ok(rptListaMicroEmprendedor);
                    }
                }
                catch (Exception ex)
                {
                    rptListaMicroEmprendedor = null;
                    return null;
                }
            }
        }

        [HttpGet("GetMicroEmprendedoresFiltrados")]
        //[Authorize]
        //[ResponseCache(CacheProfileName = "apicache")]
        public IActionResult GetMicroEmprendedoresFiltrados(int localidad, int rubro,string? palabra)
        {
            _logger.LogInformation("Fetching Todas las MicroEmprendedores");

            List<MicroEmprendedor> rptListaMicroEmprendedor = new List<MicroEmprendedor>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerMicroEmprendedorFiltrados", oConexion);
                cmd.Parameters.Add("IdLocalidad", SqlDbType.Int).Value = localidad;
                cmd.Parameters.Add("IdRubro", SqlDbType.Int).Value = rubro;
                cmd.Parameters.Add("Palabra", SqlDbType.VarChar).Value = palabra;
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();

                    using (XmlReader dr = cmd.ExecuteXmlReader())
                    {
                        while (dr.Read())
                        {
                            XDocument doc = XDocument.Load(dr);
                            if (doc.Element("Data") != null)
                            {
                                rptListaMicroEmprendedor = (from c in doc.Element("Data").Elements("MicroEmprendedor")
                                                            select new MicroEmprendedor()
                                                            {
                                                                Id = Convert.ToInt32(c.Element("Id").Value),
                                                                IdTipoDocumento = Convert.ToInt32(c.Element("IdTipoDocumento").Value),
                                                                IdLocalidad = Convert.ToInt32(c.Element("IdLocalidad").Value),
                                                                ApeyNom = c.Element("ApeyNom").Value,
                                                                Calle = c.Element("Calle").Value,
                                                                Nro = c.Element("Nro").Value,
                                                                Piso = c.Element("Piso").Value,
                                                                Depto = c.Element("Depto").Value,
                                                                TelFijo = c.Element("TelFijo").Value,
                                                                TelCelular = c.Element("TelCelular").Value,
                                                                Facebook = c.Element("Facebook").Value,
                                                                Instagram = c.Element("Instagram").Value,
                                                                SitioWeb = c.Element("SitioWeb").Value,
                                                                Correo = c.Element("Correo").Value,
                                                                // Sexo = c.Element("Sexo").Value.ToString(),
                                                                Dni = c.Element("Dni").Value,
                                                                Observaciones = c.Element("Observaciones").Value,
                                                                FechaNacimiento = Convert.ToDateTime(c.Element("FechaNacimiento").Value.ToString()),
                                                                Localidad = (from g in c.Elements("Localidad")
                                                                             select new Localidad()
                                                                             {
                                                                                 Id = Convert.ToInt32(g.Element("Id").Value),
                                                                                 Descripcion = g.Element("Descripcion").Value
                                                                             }).FirstOrDefault(),
                                                                TipoDocumento = (from h in c.Elements("TipoDocumento")
                                                                                 select new TipoDocumento()
                                                                                 {
                                                                                     Id = Convert.ToInt32(h.Element("Id").Value),
                                                                                     DescA = h.Element("DescA").Value,
                                                                                     DescC = h.Element("DescC").Value

                                                                                 }).FirstOrDefault(),

                                                                Rubros = (from d in c.Elements("Rubros")
                                                                          select new MicroEmprendedorRubro()
                                                                          {
                                                                              IdMicroEmprendedor = Convert.ToInt32(d.Element("IdMicroEmprendedor").Value),
                                                                              IdRubro = Convert.ToInt32(d.Element("IdRubro").Value),
                                                                              Rubro =
                                                                                        new Rubro()
                                                                                        {
                                                                                            Id = Convert.ToInt32(d.Element("IdRubro").Value),
                                                                                            Descripcion = d.Element("Descripcion").Value
                                                                                        },
                                                                          }).ToList(),
                                                                PalabrasClave = (from d in c.Elements("PalabrasClave")
                                                                                 select new PalabraClave()
                                                                                 {
                                                                                     IdMicroEmprendedor = Convert.ToInt32(d.Element("IdMicroEmprendedor").Value),
                                                                                     Palabra = d.Element("Palabra").Value
                                                                                 }).ToList()
                                                            }).ToList();
                            }
                            else
                            {
                                rptListaMicroEmprendedor = new List<MicroEmprendedor>();
                            }
                        }

                        dr.Close();
                        return Ok(rptListaMicroEmprendedor);
                    }
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
                     new XElement("IdTipoDocumento", microEmprendedor.IdTipoDocumento),
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
                XElement palabraClave = new XElement("PalabraClave");
                if (microEmprendedor.PalabrasClave != null)
                {
                    foreach (PalabraClave item in microEmprendedor.PalabrasClave)
                    {
                        palabraClave.Add(new XElement("Item",

                                new XElement("IdMicroEmprendedor", item.IdMicroEmprendedor), 
                                new XElement("Palabra", item.Palabra)
                            ));
                    }
                }

                microRubro.Add(palabraClave);

                using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("sp_RegistrarMicroEmprendedor", oconexion);
                    cmd.Parameters.Add("MicroEmprendedor", SqlDbType.Xml).Value = microRubro.ToString();
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    oconexion.Open();
                    cmd.ExecuteNonQuery();
                    microEmprendedor.Id = Convert.ToInt32(cmd.Parameters["Resultado"].Value);
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
            new XElement("IdTipoDocumento", microEmprendedor.IdTipoDocumento),
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

            XElement palabraClave = new XElement("PalabraClave");
            if (microEmprendedor.PalabrasClave != null)
            {
                foreach (PalabraClave item in microEmprendedor.PalabrasClave)
                {
                    palabraClave.Add(new XElement("Item",

                            new XElement("IdMicroEmprendedor", item.IdMicroEmprendedor),
                            new XElement("Palabra", item.Palabra)
                        ));
                }
            }

            microRubro.Add(palabraClave);

            using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarMicroEmprendedor", oconexion);
                cmd.Parameters.Add("IdMicroEmprendedor", SqlDbType.Int).Value = Id;
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
        //[Authorize(Roles = "Admin")]
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
