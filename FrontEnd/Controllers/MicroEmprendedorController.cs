

using FrontEnd.Models;
using FrontEnd.Models.DTOs;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;
using RtfPipe;
using System.Security.Claims;
using System.Text;
using System.Web.Razor.Parser;


namespace FrontEnd.Controllers
{
    public class MicroEmprendedorController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;


        public MicroEmprendedorController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // Register the provider
        }

        

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            string userId = string.Empty;
            if (userIdClaim != null)
            {
                userId = userIdClaim.Value;
            }
            TotalesDTO totales = new TotalesDTO();
            totales = await _apiService.GetTotales(int.Parse(userId), HttpContext.Session.GetString("APIToken"));
            return View(totales);

        }
        public ActionResult ConverHCToHTML(string historia)
        {
            string htmlContent = RtfHelper.ConvertRtfToHtml(historia);
          //  ViewBag.HtmlContent = htmlContent; // Pasar el contenido HTML al modelo de la vista.
            return Json(new { data = htmlContent });
        }


        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> GetAllMicroEmprendedor()
        {
            List<MicroEmprendedor> lstMicroEmprendedor = new List<MicroEmprendedor>();
            
            lstMicroEmprendedor = await _apiService.GetAllMicroEmprendedores(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = lstMicroEmprendedor });
        }
        
        
        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> GetMicroEmprendedorFiltrados(int localidad,int rubro)
        {
            List<MicroEmprendedor> oLista = new List<MicroEmprendedor>();
            oLista = await _apiService. GetMicroEmprendedoresFiltrados(localidad,rubro,HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }


        

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> CreateMicroEmprendedor([FromBody] MicroEmprendedor MicroEmprendedor)
        {
            object resultado = null;
            string mensaje = String.Empty;
            if (MicroEmprendedor != null) { 
            try
            {
                if (MicroEmprendedor.Id == 0)
                {
                    if (MicroEmprendedor.ApeyNom != "")
                    {
                        MicroEmprendedor = await _apiService.AddMicroEmprendedor(MicroEmprendedor, HttpContext.Session.GetString("APIToken"));
                        resultado = MicroEmprendedor.Id;
                        mensaje = "MicroEmprendedor ingresado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }
                }
                else
                {
                    if (MicroEmprendedor.ApeyNom != "")
                    {
                        await _apiService.UpdateMicroEmprendedor(MicroEmprendedor.Id, MicroEmprendedor, HttpContext.Session.GetString("APIToken"));

                        resultado = true;
                        mensaje = "MicroEmprendedor modificado correctamente";
                    }
                    else
                    {
                        resultado = false;
                        mensaje = "Por favor ingrese el Apellido y Nombre";
                    }
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;
            }
            }
            else
            {
                resultado = false;
                mensaje = "Por favor ingrese el Apellido y Nombre";
            }
            return Json(new { resultado = resultado, mensaje = mensaje });
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Details(int id)
        {
            MicroEmprendedor MicroEmprendedor = new MicroEmprendedor();
            MicroEmprendedor = await _apiService.GetMicroEmprendedorById(id, HttpContext.Session.GetString("APIToken"));
            return View(MicroEmprendedor);
        }


        //[Authorize(Roles = "Admin")]
        //public async Task<IActionResult> UpdateMicroEmprendedor(int id, MicroEmprendedor MicroEmprendedor)
        //{
        //    await _apiService.UpdateMicroEmprendedor(id, MicroEmprendedor, HttpContext.Session.GetString("APIToken"));
        //    return RedirectToAction("Index");
        //}

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Delete(int id)
        {

            MicroEmprendedor MicroEmprendedor = new MicroEmprendedor();
            MicroEmprendedor = await _apiService.GetMicroEmprendedorById(id, HttpContext.Session.GetString("APIToken"));
            return View(MicroEmprendedor);
        }

        [Authorize(Roles = "Admin,Student")]
        [ResponseCache(Duration = 30)]
        public async Task<JsonResult> DeleteMicroEmprendedor([FromBody] MicroEmprendedor MicroEmprendedor)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteMicroEmprendedor(MicroEmprendedor.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "MicroEmprendedor eliminado correctamente";
            }
            catch (Exception ex)
            {
                resultado = false;
                mensaje += ex.Message;

            }
            return Json(new { resultado = resultado, mensaje = mensaje });

        }

        public IActionResult ErrorPage()
        {
            return View();
        }
    }
}
