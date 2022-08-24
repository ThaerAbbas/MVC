using Microsoft.AspNetCore.Mvc;
using FirstPro.Models;


namespace FirstPro.Controllers
{
    public class GuessingGame : Controller
    {

      


            
        public IActionResult GuessGame(int number) { 
            
            if(number > 100 || number < 1)
            {
                ViewBag.Message = "Is not valid number";
            }
            else
            {
                ViewBag.Message = GuessModel.GuessGame(number);
                ViewBag.Count = GuessModel.Count;
               
            }
            return View();
        }
    }
}
