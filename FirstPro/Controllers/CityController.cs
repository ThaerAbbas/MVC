using FirstPro.Data;
using FirstPro.Models;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstPro.Controllers
{
    public class CityController : Controller
    {



        readonly AppDbContext _context;


        public CityController(AppDbContext context)
        {
            _context = context;
        }



        public static PersonDetailsViewModel personDetailsViewModel = new();

        [HttpGet]
        public IActionResult Index()
        {

            personDetailsViewModel.cityList = _context.Cities.ToList();

                return View("Index", personDetailsViewModel);
        }
    }
}
