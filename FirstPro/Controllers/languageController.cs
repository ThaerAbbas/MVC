using FirstPro.Data;
using FirstPro.ViewModels;
using FirstPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.ProjectModel;

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
        public IActionResult LangIndex()
        {

            language.languages = _context.languages.ToList();

            return View("LangIndex", language);
        }
        public void btnClick(Language language)
        {
            Response.Redirect("Create");
        }
        public IActionResult CreateLang()
        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateLang(Language language)
        {


            _context.Add(language);
            _context.SaveChanges();

            return RedirectToAction("LangIndex");
        }

        public IActionResult EditLang(int id)
        {

            var language = _context.languages.FirstOrDefault(m => m.LangId == id);
        
                return View(language);
            
        }

        [HttpPost]
        public IActionResult EditLang(int id, Language language)
        {
           
            _context.languages.Update(language);
            _context.SaveChanges();
            return RedirectToAction("LangIndex");

        }

        public IActionResult DeleteLang(int id)
        {

        
            
                var language = _context.languages.FirstOrDefault(l=> l.LangId == id);
                return View(language);
            

           


        }

        [HttpPost]
        public IActionResult DeleteLang(int langid, int id)
        {
           var language = _context.languages.Where(m => m.LangId == langid).FirstOrDefault();
            
            _context.languages.Remove(language);
            _context.SaveChanges();
            return RedirectToAction("LangIndex");
        }
    }
}
