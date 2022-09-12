using FirstPro.Data;
using FirstPro.Models;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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

            personDetailsViewModel.personList = _context.People.ToList();
            return View("Details", personDetailsViewModel);
        }


        //  Useing LINQ

        [HttpPost]
        public IActionResult Search(string name)
        {


            PersonDetailsViewModel serchPerson = new();

            var result = from person in _context.People
                         where
                         person.Name == name
                         select person;

            serchPerson.personList = result.ToList();



            return View("Details", serchPerson);


        }

    }  
}
