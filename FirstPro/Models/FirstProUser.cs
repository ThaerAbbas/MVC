using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FirstPro.Models
{
    // Add profile data for application users by adding properties to the FirstProUser class
 
    public class FirstProUser : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public int Birthdate { get; set; }
    }
}
