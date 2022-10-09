using FirstPro.Data;
using FirstPro.Models;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FirstPro.Controllers
{
    [EnableCors("MyPolicy")]
    public class PersonReactController : ApiController
    {
        readonly AppDbContext _context;

        public PersonReactController(AppDbContext context)
        {
            _context = context;
        }

        public static PersonDetailsViewModel personDetailsViewModel = new();


        [Route("api/Persons/GetPersons")]
        [HttpGet]
        public Response GetPersons(Person person)
        {

            personDetailsViewModel.personList = _context.People.ToList();

            Response response = new Response();
            List<Person> listPerson = new List<Person>();
            listPerson = personDetailsViewModel.personList.ToList();
            response.ResponseCod = "200";
            response.ResponseMessage = "Data fetched";
            response.listPersons = listPerson;



            return response;
        }
    }
}
