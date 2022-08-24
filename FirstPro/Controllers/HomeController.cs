using Microsoft.AspNetCore.Mvc;
using FirstPro.Models;

namespace FirstPro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
     
        public IActionResult Doctor()
        {
            return View();
        }

        public IActionResult Doctor(int temp)
        {
            ViewBag.Message = CheckFever.CheckTemp(temp);
            return View();
        }


    }
}
