using Humanizer;
using Microsoft.AspNetCore.Mvc;
using dcdLesson4.Models;

namespace dcdLesson4.Controllers
{
    public class DcdBookController : Controller
    {
        protected Book book = new Book();
        public IActionResult DcdIndex()
        {
            ViewBag.authors = book.Authors;
            ViewBag.genres = book.Genres;

            var books = book.GetBookList();
            return View(books);
        }
    }
}
