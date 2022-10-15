using FirstPro.Models;
using System.Xml.Linq;

namespace FirstPro.Controllers
{
    public class Response
    {
        public string ResponseCod { get; set; }
        public string ResponseMessage { get; set; } 
        
        public int IdPerson { get; set; }

        public string Name { get; set; }

             public string PhoneNumber { get; set; }

        public int langId { get; set; }
        public string Languages { get; set; }

        public int CityId { get; set; }

        public string CityName { get; set; }

        public int CountryId { get; set; }


        public string CountryName { get; set; }
      


        public Person Person { get; set; }

        public List<Person> listPersons { get; set; }
        public List<Language> lisLanguage { get; set; }

        public List<Country> lisCountry { get; set; }

    }
}
