using FirstPro.Models;

namespace FirstPro.ViewModels
{
    public class PersonDetailsViewModel
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
       
        public string PhoneNumber { get; set; }
       public string City { get; set; }

        public PersonDetailsViewModel(int personId, string name,  string phoneNumber, string city)
        {
            PersonId = personId;
            Name = name;

            PhoneNumber = phoneNumber;
            City = city;
           
        }

        public PersonDetailsViewModel()
        {
        }

        public List<PersonDetailsViewModel> personList = new List<PersonDetailsViewModel>();

    }
    
}