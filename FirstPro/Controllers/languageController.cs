using FirstPro.Data;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstPro.Controllers
{
    public class languageController : Controller
    {

        readonly AppDbContext _context;


        public languageController(AppDbContext context)
        {
            _context = context;
        }



        public static languageViewModel language = new();

        [HttpGet]
        public IActionResult Index()
        {

            language.languages = _context.languages.ToList();

            return View("Index",language);
        }
    }
}
