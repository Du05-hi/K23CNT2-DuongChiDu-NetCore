using System.Diagnostics;
using dcdLesson05.Models;
using Microsoft.AspNetCore.Mvc;

namespace dcdLesson05.Controllers
{
    public class DcdHomeController : Controller
    {
        private readonly ILogger<DcdHomeController> _logger;

        public DcdHomeController(ILogger<DcdHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult DcdIndex()
        {
            return View();
        }
        public IActionResult DcdAbout()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
