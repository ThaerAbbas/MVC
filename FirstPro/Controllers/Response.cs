using FirstPro.Models;

namespace FirstPro.Controllers
{
    public class Response
    {
        public string ResponseCod { get; set; }
        public string ResponseMessage { get; set; }   
        
        public Person Person { get; set; }

        public List<Person> listPersons { get; set; }

    }
}