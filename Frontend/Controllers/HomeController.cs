using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;


namespace Frontend.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Calles()
        {
            ViewBag.Message = "Calles.";
            return View();
        }
        public ActionResult Cobradores()
        {
            ViewBag.Message = "Cobradores.";
            return View();
        }
        public ActionResult Localidades()
        {
            ViewBag.Message = "Localidades.";
            return View();
        }
        public ActionResult Provincias()
        {
            ViewBag.Message = "Provincias.";
            return View();
        }
        public ActionResult Profesiones()
        {
            ViewBag.Message = "Profesiones.";
            return View();
        }
        public ActionResult Sectores()
        {
            ViewBag.Message = "Sectores.";
            return View();
        }
        public ActionResult TiposDeDocumentos()
        {
            ViewBag.Message = "Tipos de Documentos.";
            return View();
        }
        public ActionResult Usuarios()
        {
            ViewBag.Message = "Usuarios.";
            return View();
        }


     


        //MODULOS
        public ActionResult Socios()
        {
            ViewBag.Message = "Socios";
            return View();
        }
        public ActionResult Materiales()
        {
            ViewBag.Message = "Socios";
            return View();
        }
        public ActionResult Prestamos()
        {
            ViewBag.Message = "Socios";
            return View();
        }

        public ActionResult Cobros()
        {
            ViewBag.Message = "Cobros";
            return View();
        }
    }
}