using FirstPro.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstPro.Models
{
    [Table("Country")]
    public class Country
    {
    

    public Country()
    {

    }

    public Country(int id, string name)
    {
        Id = id;
        Name = name;

        }

        public List<City> cities { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }



  }


}
