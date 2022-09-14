using Microsoft.AspNetCore.Mvc;
using FirstPro.ViewModels;
using FirstPro.Models;

namespace FirstPro.Controllers
{
    public class AjaxController : Controller
    {

        public static int _id;
        public static PersonDetailsViewModel personDetailsViewModel = new();

      /*
        [HttpGet]
        public IActionResult Peopole()
        {
            _id = 1;
            if (personDetailsViewModel.personList.Count == 0)
            {
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(_id++, "lars", "Male", "070000000", "Roma"));
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(_id++, "lars", "Male", "070000000", "Roma"));
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(_id++, "lars", "Male", "070000000", "Roma"));
                _id = personDetailsViewModel.personList.Count();
            }
            return PartialView("AjaxPerson", personDetailsViewModel);
        }
      */

        [HttpPost]


        public IActionResult Details(int id)
        {

            PersonDetailsViewModel pp = new();
            personDetailsViewModel.personList = personDetailsViewModel.personList.Where(item => item.PersonId == id).ToList();

            return View("AjaxPerson", personDetailsViewModel);


        }


       

        [HttpGet]
        public ActionResult Delete(int id)
        {

            PersonDetailsViewModel deletePerson = new();
            deletePerson.personList = personDetailsViewModel.personList.Where(item => item.PersonId != (id)).ToList();

            personDetailsViewModel.personList.Remove(deletePerson.personList[0]);


            return View("Details", personDetailsViewModel);
        }
    }
}
    

