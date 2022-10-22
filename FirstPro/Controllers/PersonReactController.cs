﻿using FirstPro.Data;
using FirstPro.Models;
using FirstPro.ViewModels;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Web.Http;
using System.Xml.Linq;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
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
        public static languageViewModel languages = new();
        public static CountryViewModel countryViewModel = new();


        [EnableCors("MyPolicy")]
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

        [EnableCors("MyPolicy")]
        [Route("api/Persons/AddPersons")]
        [HttpPost]
        public Response AddPersons([FromBody]PersonReact personReact)
        {
            Person person = new Person();
            Response response = new Response();

         
            ModelState.Remove("Cities");
            ModelState.Remove("languages");
            ModelState.Remove("Countries");

           
           person.Name=personReact.Name;
            person.PhoneNumber= personReact.PhoneNumber;
            person.CityId = 2;
            person.LangId = 2;

           
            Console.WriteLine("============================" + person.Name);
            Console.WriteLine("============================" + person.PhoneNumber);

            _context.Add(person);    
            _context.SaveChanges();

            response.Person = person;
            response.ResponseCod = "200";
            response.ResponseMessage = "Data fetched";
           
           
            return response;
        }



        [EnableCors("MyPolicy")]
        [Route("api/Persons/GetLanguage")]
        [HttpGet]
        public Response GetLanguage(Language language)
        {

            languages.languages = _context.languages.ToList();

            Response response = new Response();
            List<Language> lisLanguage = new List<Language>();
            lisLanguage = languages.languages.ToList();
            response.ResponseCod = "200";
            response.ResponseMessage = "Data fetched";
            response.lisLanguage = lisLanguage;



            return response;
        }


        [EnableCors("MyPolicy")]
        [Route("api/Persons/GetCountry")]
        [HttpGet]
        public Response GetCountry(Country country)
        {

            countryViewModel.countries = _context.Countries.ToList();

            Response response = new Response();
            List<Country> lisCountry = new List<Country>();
            lisCountry = countryViewModel.countries.ToList();
            response.ResponseCod = "200";
            response.ResponseMessage = "Data fetched";
            response.lisCountry = lisCountry;



            return response;
        }



        [EnableCors("MyPolicy")]
        [Route("api/Persons/GetById/{id}")]
        [HttpPost]
        public Response GetById (int id)
        {
            Response response = new Response();

            personDetailsViewModel.personList = _context.People.ToList();

            Person person = new Person();

            languages.languages = _context.languages.ToList();
            List<Language> lisLanguage = new List<Language>();
            lisLanguage = languages.languages.ToList();

            string language = "";


            foreach (var per in personDetailsViewModel.personList)
            {
                if (per.PersonId == id)
                {

            person = _context.People
                                       .Include(x => x.languages)
                                       .Include(x => x.City)
                                       .Include(x => x.City.Country)
                                       .FirstOrDefault(aPerson => aPerson.PersonId == id);

               

                }
            }

            foreach (var lang in lisLanguage)
            {

                if (person.LangId == lang.PersonId)
                {

                    language = lang.Name;

                    break;
                }
            }



            response.IdPerson = person.PersonId;
            response.Name = person.Name;
            response.PhoneNumber = person.PhoneNumber;
            response.Languages = language;
            response.langId = person.LangId;
            response.CityId = person.CityId;
            response.CityName = person.City.Name;
            response.CountryId = person.City.CountryId;
            response.CountryName = person.City.Country.Name;
            response.ResponseCod = "200";
            response.ResponseMessage = "Data fetched";


            return response;
        }

        [EnableCors("MyPolicy")]
        [Route("api/Persons/Delete/{id}")]
        [HttpDelete]
        public Response DeleteById(int id)
        {
            Response response = new Response();

           
            List<Person> match = (from p in _context.People where p.PersonId == id select p).ToList();

            if (match.Any())
            {
                var person = match.First();
                _context.People.Remove(person);
                _context.SaveChanges();

                response.ResponseCod = "200";
                response.ResponseMessage = "Deleted succsed";
            }
            else
            {
                response.ResponseCod = "100";
                response.ResponseMessage = "Faild to delete";
            }
        


            return response;
        }

        }
}
