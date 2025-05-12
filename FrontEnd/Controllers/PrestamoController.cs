using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;





//namespace FrontEnd.Controllers
//{
//    public class PrestamoController : Controller
//    {
//        private readonly ApiService _apiService;
//        private readonly IConfiguration _config;

//        public PrestamoController(IConfiguration config)
//        {
//            _apiService = new ApiService();
//            _config = config;
//        }

//        [Authorize(Roles = "Admin")]
//        [ResponseCache(Duration = 30)]
//        public async Task<IActionResult> Index()
//        {
//            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
//            List<Prestamo> lstPrestamo = new List<Prestamo>();
//            lstPrestamo = await _apiService.GetAllPrestamos(HttpContext.Session.GetString("APIToken"));
//            return View();

//        }


//        [Authorize(Roles = "Admin")]
//        public async Task<JsonResult> GetAllPrestamos()
//        {
//            List<Prestamo> oLista = new List<Prestamo>();
//            oLista = await _apiService.GetAllPrestamos(HttpContext.Session.GetString("APIToken"));

//            return Json(new { data = oLista });
//        }


//        [Authorize(Roles = "Admin")]
//        public async Task<IActionResult> Create()
//        {
//            return View();
//        }



//        [Authorize(Roles = "Admin")]
//        public async Task<JsonResult> CreatePrestamo([FromBody] Prestamo Prestamo)
//        {
//            object resultado;
//            string mensaje = String.Empty;
//            try
//            {
//                if (Prestamo.Id == 0)
//                {
//                    if (Prestamo.ApeyNom != "")
//                    {
//                        Prestamo = await _apiService.AddPrestamo(Prestamo, HttpContext.Session.GetString("APIToken"));
//                        resultado = Prestamo.Id;
//                        mensaje = "Prestamo ingresado correctamente";
//                    }
//                    else
//                    {
//                        resultado = false;
//                        mensaje = "Por favor ingrese el Apellido y Nombre";
//                    }

//                }


//                else
//                {
//                    if (Prestamo.ApeyNom != "")
//                    {
//                        await _apiService.UpdatePrestamo(Prestamo.Id, Prestamo, HttpContext.Session.GetString("APIToken"));

//                        resultado = true;
//                        mensaje = "Prestamo Modificado correctamente";

//                    }
//                    else
//                    {
//                        resultado = false;
//                        mensaje = "Por favor ingrese el Apellido y Nombre";
//                    }

//                }
//            }
//            catch (Exception ex)
//            {
//                resultado = false;
//                mensaje += ex.Message;

//            }
//            return Json(new { resultado = resultado, mensaje = mensaje });
//        }

//        [Authorize(Roles = "Admin,Student")]
//        public async Task<IActionResult> Details(int id)
//        {

//            Prestamo Prestamo = new Prestamo();
//            Prestamo = await _apiService.GetPrestamoById(id, HttpContext.Session.GetString("APIToken"));
//            return View(Prestamo);
//        }


//        //[Authorize(Roles = "Admin")]
//        //public async Task<IActionResult> UpdatePrestamo(int id, Prestamo Prestamo)
//        //{
//        //    await _apiService.UpdatePrestamo(id, Prestamo, HttpContext.Session.GetString("APIToken"));
//        //    return RedirectToAction("Index");
//        //}

//        [Authorize(Roles = "Admin,Student")]
//        public async Task<IActionResult> Delete(int id)
//        {

//            Prestamo Prestamo = new Prestamo();
//            Prestamo = await _apiService.GetPrestamoById(id, HttpContext.Session.GetString("APIToken"));
//            return View(Prestamo);
//        }

//        [Authorize(Roles = "Admin,Student")]

//        public async Task<JsonResult> DeletePrestamo([FromBody] Prestamo Prestamo)
//        {
//            bool resultado = false;
//            string mensaje = string.Empty;
//            try
//            {
//                await _apiService.DeletePrestamo(Prestamo.Id, HttpContext.Session.GetString("APIToken"));
//                resultado = true;
//                mensaje = "Prestamo eliminado correctante";
//            }
//            catch (Exception ex)
//            {
//                resultado = false;
//                mensaje += ex.Message;

//            }
//            return Json(new { resultado = resultado, mensaje = mensaje });


//        }

//        public IActionResult ErrorPage()
//        {
//            return View();
//        }
//    }
//}
