namespace FirstPro.Models
{
    public class Person
    {
       

        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Mobile { get; set; }

       public string Country { get; set; }

        public Person(int personId, string name, string gender, string mobile, string country)
        {
            PersonId = personId;
            Name = name;
            Gender = gender;
            Mobile = mobile;
            Country = country;
        }

        public Person()
        {
        }
    }
}