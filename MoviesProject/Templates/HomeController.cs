using Microsoft.AspNetCore.Mvc;

namespace MVC.Templates
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
