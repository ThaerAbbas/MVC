using FirstPro.Data;
using FirstPro.Models;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstPro.Controllers
{
    public class CountryController : Controller
    {



        readonly AppDbContext _context;

        public CountryController(AppDbContext context)
        {
            _context = context;
        }


        public static  CountryViewModel countryViewModel = new();

        public IActionResult Country()
        {

            countryViewModel.countries = _context.Countries.ToList();

            return View("CountryIndex", countryViewModel);
        }

        public void btnClick(Country country)
        {
            Response.Redirect("CreateCountry");
        }




        public IActionResult CreateCountry()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateCountry(Country country)
        {


            _context.Add(country);
            _context.SaveChanges();

            return RedirectToAction("CountryIndex");
        }


        public IActionResult EditCountry(int id)
        {

            var country = _context.Countries.FirstOrDefault(m => m.Id == id);

            return View(country);

        }

        [HttpPost]
        public IActionResult EditCountry(int id, Country country)
        {

            _context.Countries.Update(country);
            _context.SaveChanges();
            return RedirectToAction("CountryIndex");

        }


        public IActionResult DeleteCountry(int id)
        {



            var country = _context.Countries.FirstOrDefault(l => l.Id == id);
            return View(country);


           


        }

        [HttpPost]
        public IActionResult DeleteCountry(int id,int c)
        {
            var country = _context.Countries.Where(m => m.Id == id).FirstOrDefault();

            _context.Countries.Remove(country);
            _context.SaveChanges();
            return RedirectToAction("CountryIndex");
        }
    }
}
