using FirstPro.Models;
using Microsoft.AspNetCore.Mvc;

namespace FirstPro.Controllers
{
    public class PerssonController2 : Controller
    {

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }





        [HttpPost]
        public ActionResult Create(Person person)

        {
            return View();
        }




        [HttpPost]
        public ActionResult Edit(int id=0 )

        {
            return View();
        }





        [HttpPost]
        public ActionResult Edit(Person person)

        {
            return View();
        }


        [HttpGet]
        public ActionResult Delete(int id=0 )

        {
            return View();
        }
    }
}
