using System.Diagnostics.Metrics;

namespace FirstPro.Models
{
    public class City
    {

       
        public int Id { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public int CountryId { get; set; }

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
    }
}
    

