﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

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

    
        public Language(int langId, string name, int personId)
        {
            LangId = langId;
            Name = name;
            PersonId = personId;
        }

      



    }
}
