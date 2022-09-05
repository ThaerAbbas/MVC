
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
        [Column("Gender")]
        public string Gender { get; set; }
        [Column("Mobile")]
        public string Mobile { get; set; }
       

        [Column("City")]
        public City City { get; set; }
        [Column("CityId")]
        public int CityId { get; set; }



        public Person(int personId, string name, string gender, string mobile, int cityIdy)
        {
            PersonId = personId;
            Name = name;
            Gender = gender;
            Mobile = mobile;
          
            CityId = cityIdy;
           
        }

        public Person()
        {
        }
    }
}