using Microsoft.AspNetCore.Mvc;
using FirstPro.Models;

namespace FirstPro.Controllers
{
    public class FeverController : Controller
    {


        public IActionResult CheckTemp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CheckTemp(int temp)
        {
            ViewBag.Message = CheckFever.CheckTemp(temp);
            return View();
        }

    }
}
