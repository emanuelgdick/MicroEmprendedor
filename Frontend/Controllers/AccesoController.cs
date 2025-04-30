using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidades;
using CapaNegocios;
using System.Web.Security;
using System.Xml.Linq;
using DocumentFormat.OpenXml.Office2010.Excel;

namespace CapaPresentacionAdministrador.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registrar()
        {
            return View();
        }
        public ActionResult CambiarClave()
        {
            return View();
        }
        public ActionResult Reestablecer()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Index(string correo,string clave)
        {
            Usuario oUsuario=new Usuario();
            oUsuario = new UsuarioBiz().Listar().Where(u => u.Correo == correo && u.Clave == RecursosBiz.ConvertirSha256(clave)).FirstOrDefault();
             
            if (oUsuario == null)
            {
                ViewBag.Error = "Correo o contraseña incorrecta";
                return View();
            }
            else
            {
                if (oUsuario.Reestablecer)
                {
                    TempData["IdUsuario"] = oUsuario.Id;
                    return RedirectToAction("CambiarClave");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(oUsuario.Correo, false);
                   // oUsuario.oModulo = new UsuarioBiz().GetModulosDeUsuario(oUsuario.Id);
                    Session["Usuario"] = oUsuario;
                    ViewBag.Id = oUsuario.Id;
                    ViewBag.NombreUsuario = oUsuario.ApeyNom;
                    ViewBag.Rol = oUsuario.oRol.Descripcion;
                    ViewBag.Error = null;
                  
                    if (oUsuario.oRol.Descripcion=="Contribuyentes")
                        return RedirectToAction("Index", "MesaEntradas",new {idUser = oUsuario.Id});
                    else
                         return RedirectToAction("Index", "Home", new { idUser = oUsuario.Id });
                    
                }
            }
        }
        [HttpPost]
        public ActionResult CambiarClave(string idusuario,string claveactual,string nuevaclave,string confirmarclave)
        {
            Usuario oUsuario = new Usuario();
            oUsuario = new UsuarioBiz().Listar().Where(u => u.Id == int.Parse(idusuario)).FirstOrDefault();
            if (oUsuario.Clave != RecursosBiz.ConvertirSha256(claveactual))
            {
                TempData["IdUsuario"] = idusuario;
                ViewData["vclave"] = "";
                ViewBag.Error = "La contraseña actual no es correcta";
                return View();
            }
            else if (nuevaclave != confirmarclave) {
                TempData["IdUsuario"] = idusuario;
                ViewData["vclave"] = claveactual;
                ViewBag.Error = "Las contraseñas no coinciden";
                return View();
            }
            ViewData["vclave"] = "";

            nuevaclave = RecursosBiz.ConvertirSha256(nuevaclave);
            string mensaje = string.Empty;
            bool respuesta = new UsuarioBiz().CambiarClave(int.Parse(idusuario), nuevaclave, out mensaje);
            if (respuesta) {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["IdUsuario"]=idusuario;
                ViewBag.Error = mensaje;
                return View();
            }
            
        }

        [HttpPost]
        public ActionResult Guardar(Usuario objeto)
        {
            int resultado;
            string Mensaje = string.Empty;
            
            if (objeto.Id == 0)
            {
             
                ViewData["ApeyNom"] = string.IsNullOrEmpty(objeto.ApeyNom) ? "" : objeto.ApeyNom;
                ViewData["Email"] = string.IsNullOrEmpty(objeto.Correo) ? "" : objeto.Correo;

                if (objeto.Clave != objeto.ConfirmarClave)
                {
                    ViewBag.Error = "Las contraseñas no coinciden";
                    return View();
                }

                resultado = new UsuarioBiz().Registrar(objeto,objeto.Correo, out Mensaje);
            }
            else
            {
                resultado = new UsuarioBiz().Editar(objeto, objeto.Id, out Mensaje);
            }
            // return Json(new { resultado = resultado, mensaje = Mensaje }, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index", "Home");





            ////////XElement usuario = new XElement("Usuario",
            ////////new XElement("IdArea", objeto.IdArea),
            ////////new XElement("Nombres", objeto.Nombres),
            ////////new XElement("Apellidos", objeto.Apellidos),
            ////////new XElement("Correo", objeto.Correo),
            ////////new XElement("Clave", objeto.Clave),
            ////////new XElement("Restablecer", 1/*objeto.Reestablecer*/),
            ////////new XElement("Activo", objeto.Activo)
            ////////);
            //////// XElement usuarioModulo = new XElement("UsuarioModulo");
            //////// if (objeto.oModulo != null) { 
            //////// foreach (UsuarioModulo item in objeto.oModulo)
            //////// {
            ////////     usuarioModulo.Add(new XElement("Item",

            ////////         new XElement("IdUsuario", item.IdUsuario),
            ////////         new XElement("IdModulo", item.IdModulo)
            ////////         ));
            //////// }
            //////// usuario.Add(usuarioModulo);
            //////// }
            //string mensaje = string.Empty;
            //new UsuarioBiz().Registrar(usuario, out mensaje);

            /**/
            //objeto.Activo = true;
            //   resultado = new UsuarioBiz().Registrar(objeto, objeto.Correo, out mensaje);
            if (resultado>0 )
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                ViewBag.Error = Mensaje;
                return View();
            }
        }

        [HttpPost]
        public ActionResult Reestablecer(string correo)
        {
            Usuario oUsuario = new Usuario();
            oUsuario = new UsuarioBiz().Listar().Where(item => item.Correo == correo).FirstOrDefault();
            if (oUsuario == null)
            {
                ViewBag.Error = "No se encontró un usuario relacionado a ese correo";
                return View();
            }
            string mensaje = string.Empty;
            bool respuesta = new UsuarioBiz().ReestablecerClave(oUsuario.Id, correo, out mensaje);
            if (respuesta)
            {
                ViewBag.Error = null;
                return RedirectToAction("Index", "Acceso");
            }
            else
            {
                ViewBag.Error = mensaje;
                return View();
            }
        }
        public ActionResult CerrarSesion()
        {
            Session["Usuario"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Acceso");

        }
    }
}