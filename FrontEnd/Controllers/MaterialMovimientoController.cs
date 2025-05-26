using Frontend.Models;
using FrontEnd.Models;
using FrontEnd.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft;

namespace FrontEnd.Controllers
{
    public class MaterialMovimientoController : Controller
    {
        private readonly ApiService _apiService;
        private readonly IConfiguration _config;

        public MaterialMovimientoController(IConfiguration config)
        {
            _apiService = new ApiService();
            _config = config;
        }

        [Authorize(Roles = "Admin")]
        [ResponseCache(Duration = 30)]
        public async Task<IActionResult> Index()
        {
            int pagesize = _config.GetValue<int>("PageSettings:PageSize");
            List<MaterialMovimiento> lstMaterialMovimiento = new List<MaterialMovimiento>();
            lstMaterialMovimiento = await _apiService.GetAllMaterialMovimientos(HttpContext.Session.GetString("APIToken"));
            return View();

        }


        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllMaterialMovimiento()
        {
            List<MaterialMovimiento> oLista = new List<MaterialMovimiento>();
            oLista = await _apiService.GetAllMaterialMovimientos(HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<JsonResult> GetAllMaterialMovimientosBySocio(int socio)
        {
            List<MaterialMovimiento> oLista = new List<MaterialMovimiento>();
            oLista = await _apiService.GetMaterialMovimientoBySocio(socio,HttpContext.Session.GetString("APIToken"));
            return Json(new { data = oLista });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            return View();
        }



        //[Authorize(Roles = "Admin")]
        //public async Task<JsonResult> CreateMaterialMovimiento([FromBody] MaterialMovimiento materialMovimiento)
        //{
        //    object resultado;
        //    string mensaje = String.Empty;
        //    try
        //    {
        //        if (materialMovimiento.Id == 0)
        //        {
        //            if (materialMovimiento.Descripcion != "")
        //            {
        //                materialMovimiento = await _apiService.AddMaterialMovimiento(materialMovimiento, HttpContext.Session.GetString("APIToken"));
        //                resultado = materialMovimiento.Id;
        //                mensaje = "Movimiento ingresado correctamente";
        //            }
        //            else
        //            {
        //                resultado = false;
        //                mensaje = "Por favor ingrese la descripción";
        //            }

        //        }


        //        else
        //        {
        //            if (materialMovimiento.Descripcion != "")
        //            {
        //                await _apiService.UpdateMaterialMovimiento(materialMovimiento.Id, materialMovimiento, HttpContext.Session.GetString("APIToken"));

        //                resultado = true;
        //                mensaje = "Movimiento Modificado correctamente";

        //            }
        //            else
        //            {
        //                resultado = false;
        //                mensaje = "Por favor ingrese la descripción";
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        resultado = false;
        //        mensaje += ex.Message;

        //    }
        //    return Json(new { resultado = resultado, mensaje = mensaje });
        //}

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Details(int id)
        {

            MaterialMovimiento materialMovimiento = new MaterialMovimiento();
            materialMovimiento = await _apiService.GetMaterialMovimientoById(id, HttpContext.Session.GetString("APIToken"));
            return View(materialMovimiento);
        }

        [Authorize(Roles = "Admin,Student")]
        public async Task<IActionResult> Delete(int id)
        {

            MaterialMovimiento materialMovimiento = new MaterialMovimiento();
            materialMovimiento = await _apiService.GetMaterialMovimientoById(id, HttpContext.Session.GetString("APIToken"));
            return View(materialMovimiento);
        }

        [Authorize(Roles = "Admin,Student")]

        public async Task<JsonResult> DeleteMaterialMovimiento([FromBody] MaterialMovimiento materialMovimiento)
        {
            bool resultado = false;
            string mensaje = string.Empty;
            try
            {
                await _apiService.DeleteMaterialMovimiento(materialMovimiento.Id, HttpContext.Session.GetString("APIToken"));
                resultado = true;
                mensaje = "Movimiento eliminado correctante";
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
