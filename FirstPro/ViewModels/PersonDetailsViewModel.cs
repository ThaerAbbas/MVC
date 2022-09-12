using FirstPro.Models;
using System.ComponentModel.DataAnnotations;

namespace FirstPro.ViewModels
{
    public class PersonDetailsViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
  
        public string PhoneNumber { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public PersonDetailsViewModel(int personId, string name, string phoneNumber,  int cityId)
        {
            PersonId = personId;
            Name = name;

            PhoneNumber = phoneNumber;
            CityId = cityId;
            CityId = cityId;
        }

        public PersonDetailsViewModel()
        {
        }

        public List<Person> personList = new List<Person>();
        
       

    }
    
}