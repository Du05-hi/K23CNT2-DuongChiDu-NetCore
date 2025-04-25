using Microsoft.AspNetCore.Mvc;

namespace DcdLesson01Mvc.Controllers
{
    public class DcdHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
