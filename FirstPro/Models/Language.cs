using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FirstPro.Models
{
    [Table("Language")]

    public class Language
    {
        [Key]
        public int LangId { get; set; }
        public string Name { get; set; }

        public List<Person> People = new List<Person>();
        public int PersonId { get; set; }

        public Language()
        {

        }


        public Language(int id, string name, int personId)
        {
            LangId = id;
            Name = name;
            PersonId = personId;
        }

      



    }
}
