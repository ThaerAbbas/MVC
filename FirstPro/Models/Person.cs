
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using static FirstPro.ViewModels.CityViewModel;

namespace FirstPro.Models
{
   


    [Table("Person")]
    public class Person 
    {

        [Column("PersonId")]
        public int PersonId { get; set; }
        [Column("Name")]
        public string Name { get; set; }
    
        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }
      
        [Column("City")]
        public City City { get; set; }
        [Column("CityId")]
        public int CityId { get; set; }

        public int LangId { get; set; }




        public Person(int personId, string name,  string phoneNumber, int cityIdy, City city, int langId)
        {
            PersonId = personId;
            Name = name;

            PhoneNumber = phoneNumber;
          
            CityId = cityIdy;
            City = city;
            LangId = langId;


        }
        public List<Language> languages = new List<Language>();
        public Person()
        {
        }
    }
}