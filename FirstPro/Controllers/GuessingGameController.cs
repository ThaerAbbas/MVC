using Microsoft.AspNetCore.Mvc;
using FirstPro.Models;


namespace FirstPro.Controllers
{
    public class GuessingGameController : Controller
    {
        public IActionResult GuessGame()
        {
            return View();
        }



        [HttpPost]
        public IActionResult GuessGame(int number) { 
            
            if(number > 10 || number < 1)
            {
                ViewBag.Message = "Is not valid number";
            }
            else
            {
                ViewBag.Message = GuessModel.GuessGame(number);
                ViewBag.Count = "Wrong attempts" + " "+ GuessModel.Count;
               
            }
            return View();
        }
    }
}
