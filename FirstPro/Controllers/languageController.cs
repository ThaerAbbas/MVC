using FirstPro.Data;
using FirstPro.ViewModels;
using FirstPro.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
       
           
                
             return View();
         
            
        }

        [HttpPost]
        public IActionResult EditLang(int id, Language l)
        {
            var language = _context.languages.FirstOrDefault(m => m.LangId == id);
            _context.languages.Update(l);
            _context.SaveChanges();
            return RedirectToAction("LangIndex");

        }

        public IActionResult DeleteLang(int id)
        {

            if (ModelState.IsValid)
            {
                var language = _context.languages.FirstOrDefault(l=> l.LangId == id);
                return View(language);
            }

            return RedirectToAction("LangIndex");


        }

        [HttpPost]
        public IActionResult DeleteLangِِ(Language l , int lngid)
        {
           var language = _context.languages.FirstOrDefault(m => m.LangId == lngid);
            _context.Remove(l);
            _context.SaveChanges();
            return RedirectToAction("LangIndex");
        }
    }
}
