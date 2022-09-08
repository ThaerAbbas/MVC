using  FirstPro.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstPro.Models
{
    [Table("City")]
    public class City
    {
   

    public City()
    {

    }

    public City(int id, string name, int countryId)
    {
        Id = id;
        Name = name;
        CountryId = countryId;
    }
     
        
        public List<Person> People { get; set; }

        public int Id { get; set; }
         
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }
    }
}
