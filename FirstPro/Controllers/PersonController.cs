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

        
        public IActionResult Create()
        {
          
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {

            ModelState.Remove("City");
            ModelState.Remove("Languages"); 
            _context.Add(person);
            _context.SaveChanges();

            return RedirectToAction("Details");
        }

        // Method Go to the create page
        public void btnClick(Person person)
        {
            Response.Redirect("Create");
        }

        public IActionResult Edit()
        {
            ViewBag.CityNames = new SelectList(_context.Cities, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Edit(int id, Person person)
        {
            ModelState.Remove("City");
            ModelState.Remove("id");
            ModelState.Remove("Languages");
            if (ModelState.IsValid)
            {
                _context.Update(person);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityNames = new SelectList(_context.Cities, "Id", "Name", person.CityId);
            return View(person);
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

        [HttpPost]
        public ActionResult Delete(int id)
        {

            id = personDetailsViewModel.Id;



                Person person =    _context.People.Find(id);
                Console.WriteLine(person);

                _context.People.Remove(person);


                _context.SaveChanges();

            





            return RedirectToAction("Details");
        }

    }  
}
