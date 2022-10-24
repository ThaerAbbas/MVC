
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Xml.Linq;
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
        public City ? City { get; set; }
        [Column("CityId")]
     
        public int CityId { get; set; }

        public List<Language> languages = new List<Language>();
        public int LangId { get; set; }




        public Person(int personId, string name,  string phoneNumber, int cityIdy, int langId)
        {
            PersonId = personId;
            Name = name;

            PhoneNumber = phoneNumber;
          
            CityId = cityIdy;
         
            LangId = langId;


        }
     
        public Person()
        {
        }

        public Person(PersonReact personReact)
        {
            PersonId= personReact.PersonId;
            
            Name = personReact.Name;

            PhoneNumber = personReact.PhoneNumber;

            CityId = personReact.CityId;

            LangId = personReact.LangId;

        }
    }
}