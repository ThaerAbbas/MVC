using FirstPro.Data;
using FirstPro.Models;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstPro.Controllers
{
    public class PersonController : Controller


    {
        readonly AppDbContext _context;

        public PersonController(AppDbContext context) 
        {
            _context = context;
        }


    



        public static PersonDetailsViewModel personDetailsViewModel = new();
        [HttpGet]
        public IActionResult Person()
        {
            personDetailsViewModel.personList= _context.People.ToList();

            return View("Details", personDetailsViewModel);
        }


        //  Useing LINQ

        [HttpPost]
        public IActionResult Search(string name)
        {


            PersonDetailsViewModel serchPerson = new();

                  var result = from person in _context.People where 
                               person.Name == name select person;

            serchPerson.personList = result.ToList();
          


            return View("Details", serchPerson);


        }
/*
        [HttpPost]
        public ActionResult Add(PersonDetailsViewModel personDetails)
        {
            if (ModelState.IsValid)
            {
                Person person = new();

                person.Name = personDetails.Name;
                person.PhoneNumber = personDetails.PhoneNumber;
                person.CityId = personDetails.CityId;



                _context.People.Add(person);

                _context.SaveChanges();

            }
            return View("Details", personDetailsViewModel);

        }
/*


        /*

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

        }*/
    }
    }