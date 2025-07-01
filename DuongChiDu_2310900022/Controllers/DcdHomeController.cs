using System.Diagnostics;
using DuongChiDu_2310900022.Models;
using Microsoft.AspNetCore.Mvc;

namespace DuongChiDu_2310900022.Controllers
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
