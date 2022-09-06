namespace FirstPro.Models
{
    public class Person
    {
       

        public int PersonId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

       public string City { get; set; }

        public Person(int personId, string name,   string phoneNumber, string city)
        {
            PersonId = personId;
            Name = name;
            PhoneNumber = phoneNumber;
            City = city;
        }

        public Person()
        {
        }
    }
}