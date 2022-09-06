using Microsoft.AspNetCore.Mvc;
using FirstPro.ViewModels;
using FirstPro.Models;

namespace FirstPro.Controllers
{
    public class AjaxController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public static int id = 1;

        public static int ids;
        public static PersonDetailsViewModel personDetailsViewModel = new();

        public static List<PersonDetailsViewModel> person = personDetailsViewModel.personList.ToList();

        [HttpGet]
        public IActionResult Peopole()
        {
            if (personDetailsViewModel.personList.Count == 0)
            {
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(id++, "lars", "070000000", "Roma"));
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(id++, "Roben", "070000000", "Italy"));
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(id++, "lara", "070000000", "Spin"));
                ids = personDetailsViewModel.personList.Count;
               
            }
            return PartialView("AjaxPerson", personDetailsViewModel);
        }

        [HttpPost]


        public IActionResult Details(int id)
        {

            PersonDetailsViewModel pp = new();
            pp.personList = personDetailsViewModel.personList.Where(item => item.PersonId == id).ToList();

            return PartialView("AjaxPerson", pp);


        }


      

        [HttpPost]
        public ActionResult Delete(int id)
        {
            person.Remove(person.SingleOrDefault(o => o.PersonId == id));


            personDetailsViewModel.personList = person;



            return RedirectToAction("Index");
        }
    }
}
    

