using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class ConsultaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
