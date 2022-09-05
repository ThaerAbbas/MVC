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
       public string Country { get; set; }

        public PersonDetailsViewModel(int personId, string name, string gender, string mobile, string country)
        {
            PersonId = personId;
            Name = name;
            Gender = gender;
            Mobile = mobile;
            Country = country;
           
        }

        public PersonDetailsViewModel()
        {
        }

        public List<Person> personList = new List<Person>();

       

    }
    
}