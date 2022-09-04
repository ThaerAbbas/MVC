using Microsoft.AspNetCore.Mvc;
using FirstPro.Models;


namespace FirstPro.Controllers
{
    public class GuessingGameController : Controller
    {
        public IActionResult GuessGame()
        {

            if (String.IsNullOrEmpty(HttpContext.Session.GetString("empty number")))
            {
                int rand = GuessModel.guessNum();
                GuessModel.GuessGamenumber = rand;
                HttpContext.Session.SetString("number is", rand.ToString());
            }
            else
            {
                GuessModel.GuessGamenumber = int.Parse(HttpContext.Session.GetString("number is"));
            }
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

                Console.WriteLine(GuessModel.GuessGamenumber);
            }
            return View();
        }
    }
}
