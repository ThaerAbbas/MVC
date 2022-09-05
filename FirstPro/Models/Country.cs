namespace FirstPro.Models
{
    public class Country
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public Country()
        {

        }


        public Country(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public List<Person> People = new List<Person>();
    
    }
}
