using System.ComponentModel.DataAnnotations.Schema;

namespace FirstPro.Models
{
    [Table("Country")]
    public class Country
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Country()
        {

        }


        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public List<City> cities = new List<City>();
    
    }
}
