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


        public static PersonDetailsViewModel personDetailsViewModel = new();

        public IActionResult Country()
        {

            personDetailsViewModel.countries = _context.Countries.ToList();

            return View("CountryIndex", personDetailsViewModel);
        }
    }
}
