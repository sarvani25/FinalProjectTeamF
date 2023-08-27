using Microsoft.AspNetCore.Mvc;

namespace BooksWeb02.Controllers
{
    public class FavouriteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
