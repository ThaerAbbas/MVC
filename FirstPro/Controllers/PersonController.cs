using FirstPro.Models;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstPro.Controllers
{
    public class PersonController : Controller
    {

        public static PersonDetailsViewModel personDetailsViewModel = new();
        public ViewResult Details()
        {

          
            

            personDetailsViewModel.personList.Add(new PersonDetailsViewModel( 01, "lars", "Male", "070000000", "India"));

           
               
               
            return View(personDetailsViewModel);
        }



        [HttpPost]
        public IActionResult Search(string name)
        {


            PersonDetailsViewModel serchPerson = new();

            serchPerson.personList = personDetailsViewModel.personList.Where(item => item.Name.Contains(name)).ToList();


            return View("Details", serchPerson);


        }


        [HttpPost]
        public ActionResult Add(int personId, string name, string gender, string mobile, string country)
        {
            personDetailsViewModel.personList.Add(new PersonDetailsViewModel(personId + 1, name, gender, mobile , country));
            personId++;
            return View("Details", personDetailsViewModel);
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