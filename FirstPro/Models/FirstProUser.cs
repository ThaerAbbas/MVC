using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using System.Data;

namespace FirstPro.Models
{
   
 
    public class FirstProUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Birthdate { get; set; }
    }


}
