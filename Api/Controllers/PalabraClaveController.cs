using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    public class PalabraClaveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
