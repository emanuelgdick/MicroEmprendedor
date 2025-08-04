using Api.Models;
//using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Numerics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Hosting;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private MicroEmprendedorContext _db;
        private string _SecretKey;

        public UsuarioController(MicroEmprendedorContext db, IConfiguration configuration)
        {
            _db = db;
            _SecretKey = configuration.GetValue<string>("ApiSettings:Secret");
        }

        [HttpPost("UserLogin")]
        public async Task<LoginResponseDTO> Login( LoginRequestDTO logindetails)
        {
            //var user = _db.Usuario.FirstOrDefault(u => u.User.ToLower() == logindetails.User.ToLower()
            //&& u.Password.ToLower() == RecursosBiz.ConvertirSha256(logindetails.Password.ToLower()));
            Usuario user = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("sp_ObtenerUsuario", oConexion);
                cmd.Parameters.AddWithValue("User", logindetails.User);
                cmd.Parameters.AddWithValue("Password", RecursosBiz.ConvertirSha256(logindetails.Password.ToLower()));
                //cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                //cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                oConexion.Open();
                //SqlDataReader dr = cmd.ExecuteReader();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        user.ApeyNom = dr["ApeyNom"].ToString();
                        user.Id = Convert.ToInt32(dr["Id"].ToString());
                        user.User = dr["User"].ToString();
                        user.Password = dr["Password"].ToString();
                        user.IdLocalidad = Convert.ToInt32(dr["IdLocalidad"].ToString());
                        //  return rptListaFalta;
                    }
                    dr.Close();
                }
            }

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.UserData, user.User),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponse = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                Usuario = user,
            };

            return loginResponse;
        }


        [HttpPost("AddUser")]
        public async Task<LoginResponseDTO> AddUser([FromBody] LoginRequestDTO usuario)
        {
            //var user = _db.Usuario.FirstOrDefault(u => u.User.ToLower() == logindetails.User.ToLower()
            //&& u.Password.ToLower() == RecursosBiz.ConvertirSha256(logindetails.Password.ToLower()));
            Usuario user = new Usuario();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cn))
            {
                SqlCommand cmd = new SqlCommand("sp_RegistrarUsuario", oConexion);
                cmd.Parameters.AddWithValue("ApeyNom", usuario.ApeyNom);
                cmd.Parameters.AddWithValue("User", usuario.User);
                cmd.Parameters.AddWithValue("Password", RecursosBiz.ConvertirSha256(usuario.Password.ToLower()));
                cmd.Parameters.AddWithValue("Localidad", usuario.IdLocalidad);
                cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
                cmd.CommandType = CommandType.StoredProcedure;
                oConexion.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        user.ApeyNom = dr["ApeyNom"].ToString();
                        user.Id = Convert.ToInt32(dr["Id"].ToString());
                        user.User = dr["User"].ToString();
                        user.Password = dr["Password"].ToString();
                        user.IdLocalidad = Convert.ToInt32(dr["IdLocalidad"].ToString());
                    }
                    dr.Close();
                }
            }

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_SecretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.UserData, user.User),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            LoginResponseDTO loginResponse = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                Usuario = user,
            };

            return loginResponse;

        }

        //public bool CambiarClave(int idusuario, string nuevaclave, out string Mensaje)
        //{
        //    bool resultado = false;
        //    Mensaje = string.Empty;
        //    try
        //    {
        //        using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_CambiarClaveUsuario", oconexion);
        //            cmd.Parameters.AddWithValue("Id", idusuario);
        //            cmd.Parameters.AddWithValue("Clave", nuevaclave);

        //            cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            oconexion.Open();
        //            cmd.ExecuteNonQuery();
        //            resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
        //            Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = false;
        //        Mensaje = ex.Message;
        //    }
        //    return resultado;
        //}

        //public bool ReestablecerClave(long idusuario, string clave, out string Mensaje)
        //{
        //    bool resultado = false;
        //    Mensaje = string.Empty;
        //    try
        //    {
        //        using (SqlConnection oconexion = new SqlConnection(Conexion.cn))
        //        {
        //            SqlCommand cmd = new SqlCommand("sp_ReestablecerClaveUsuario", oconexion);
        //            cmd.Parameters.AddWithValue("Id", idusuario);
        //            cmd.Parameters.AddWithValue("Clave", clave);

        //            cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
        //            cmd.Parameters.Add("Mensaje", SqlDbType.VarChar, 500).Direction = ParameterDirection.Output;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            oconexion.Open();
        //            cmd.ExecuteNonQuery();
        //            resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
        //            Mensaje = cmd.Parameters["Mensaje"].Value.ToString();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = false;
        //        Mensaje = ex.Message;
        //    }
        //    return resultado;
        //}





        //        Mensaje = String.Empty;
        //            string nuevaclave = RecursosBiz.GenerarClave();
        //        bool resultado = objCapaDato.ReestablecerClave(idusuario, RecursosBiz.ConvertirSha256(nuevaclave), out Mensaje);

        //            if (resultado)
        //            {
        //                string asunto = "Crontraseña Reestablecida";
        //        string mensaje_correo = "<h3>Su Cuenta fue reestablecida correctamente </h3></br><p>Su contraseña para acceder ahora es: !clave!</p>";
        //        mensaje_correo = mensaje_correo.Replace("!clave!", nuevaclave);
        //                bool respuesta = RecursosBiz.EnviarCorreo(correo, asunto, mensaje_correo);

        //                if (respuesta)
        //                {
        //                    return true;

        //                }
        //                else
        //                {
        //                    Mensaje = "No se pudo enviar el correo";
        //                    return false;
        //                }
        //            }
        //            else
        //{
        //    Mensaje = "No se pudo reestablecer la contraseña";
        //    return true;
        //}
    }
}
