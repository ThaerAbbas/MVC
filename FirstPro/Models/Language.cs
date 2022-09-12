using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstPro.Models
{
    [Table("Language")]
    public class Language
    {

        public int LangId { get; set; }
        public string Name { get; set; }

        public Language()
        {

        }


        public Language(int id, string name)
        {
            LangId = id;
            Name = name;

        }

        public List<Person> People = new List<Person>();



    }
}
