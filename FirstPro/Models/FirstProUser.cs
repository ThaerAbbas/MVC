
using Microsoft.AspNetCore.Identity;



namespace FirstPro.Models
{
   
 
    public class FirstProUser : IdentityUser
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }

     
        public int Birthdate { get; internal set; }
    }


}
