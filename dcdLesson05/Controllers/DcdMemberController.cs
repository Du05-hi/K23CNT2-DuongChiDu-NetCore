using Microsoft.AspNetCore.Mvc;
using dcdLesson05.Models.DataModels;

namespace dcdLesson05.Controllers
{
    public class DcdMemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DcdGetMember()
        {
            var dcdMember = new DcdMember();
            dcdMember.DcdMemberId = Guid.NewGuid().ToString();
            dcdMember.DcdUserName = "DuDuDu";
            dcdMember.DcdFullName = "DuongChiDu";
            dcdMember.DcdPassword = "123456a@";
            dcdMember.DcdEmail = "duongchidu30072005@gmail.com";

            ViewBag.dcdMember = dcdMember;
            return View();
        }
    }
}