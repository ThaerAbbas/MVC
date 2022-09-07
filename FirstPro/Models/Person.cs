
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

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

        public string PersonCity { get; set; }
   



        public Person(int personId, string name,  string phoneNumber, int cityIdy, string personCity)
        {
            PersonId = personId;
            Name = name;

            PhoneNumber = phoneNumber;
          
            CityId = cityIdy;
            PersonCity = personCity;
           
        }

        public Person()
        {
        }
    }
}