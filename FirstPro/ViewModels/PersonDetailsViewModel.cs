using FirstPro.Models;
using System.ComponentModel.DataAnnotations;

namespace FirstPro.ViewModels
{
    public class PersonDetailsViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }
        public City City { get; set; }

        public PersonDetailsViewModel(int personId, string name, string mobile, City city)
        {
            PersonId = personId;
            Name = name;
         
            Mobile = mobile;
            City = city;
           
        }

        public PersonDetailsViewModel()
        {
        }

        public List<Person> personList = new List<Person>();
        
       

    }
    
}