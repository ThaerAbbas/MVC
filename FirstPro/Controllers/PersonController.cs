using FirstPro.Models;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstPro.Controllers
{
    public class PersonController : Controller
    {

        public static PersonDetailsViewModel personDetailsViewModel = new();
        [HttpGet]
        public IActionResult Details()
        {
         
            
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(01, "lars", "Male", "070000000", "Roma"));
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(02, "Roben", "Male", "070000000", "Italy"));
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(03, "lara", "Female", "070000000", "Spin"));

               
            
            return View(personDetailsViewModel);
        }



        [HttpPost]
        public IActionResult Search(string name)
        {


            PersonDetailsViewModel serchPerson = new();

            serchPerson.personList = personDetailsViewModel.personList.Where(item => item.Name.Contains(name)).ToList();


            return View("Details", serchPerson);


        }


        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(int personId, string name, string gender, string mobile, string country)
        {
            personDetailsViewModel.personList.Add(new PersonDetailsViewModel(personId + 1, name, gender, mobile , country));
            personId++;
            return View("Details", personDetailsViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

           // PersonDetailsViewModel deletePerson = new();
            //deletePerson.personList = personDetailsViewModel.personList.Where(item => item.PersonId == id).ToList();

            personDetailsViewModel.personList.Remove(personDetailsViewModel.personList
                .FirstOrDefault(e => e.PersonId ==id ));
           


            return  View("Details", personDetailsViewModel);
        }
    }
}