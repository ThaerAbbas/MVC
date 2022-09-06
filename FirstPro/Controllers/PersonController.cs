using FirstPro.Models;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstPro.Controllers
{
    public class PersonController : Controller
    {

     public static   int id = 1;

        public static int ids;



        public static PersonDetailsViewModel personDetailsViewModel = new();

        public static List<PersonDetailsViewModel> person = personDetailsViewModel.personList.ToList();



        [HttpGet]
        public IActionResult Details()
        {
          
            if (personDetailsViewModel.personList.Count == 0 )
            {
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(id++, "lars", "070000000", "Roma"));
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(id++, "Roben", "070000000", "Italy"));
                personDetailsViewModel.personList.Add(new PersonDetailsViewModel(id++, "lara", "070000000", "Spin"));
                ids = personDetailsViewModel.personList.Count;
                return View(personDetailsViewModel);
            }
         

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
        public ActionResult Add(int personId , string name,  string phoneNumber, string city)
        {
            personDetailsViewModel.personList.Add(new PersonDetailsViewModel(id++, name, phoneNumber , city));
            ids++;


     
          return  View("Details", personDetailsViewModel);
        }

       



        [HttpPost]
        public ActionResult Delete(int id)
        {

   

            person.Remove(person.SingleOrDefault(o => o.PersonId == id));


            personDetailsViewModel.personList = person;

        

            return  RedirectToAction("Details");
        }
    }
}