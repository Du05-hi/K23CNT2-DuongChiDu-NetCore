using System.Diagnostics;
using DcdLesson10EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace DcdLesson10EF.Controllers
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
