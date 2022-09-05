using Microsoft.EntityFrameworkCore;
using FirstPro.Models;
using System.Diagnostics.Metrics;

namespace FirstPro.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()

        {

        }


        public AppDbContext(DbContextOptions<AppDbContext> contextOptions) : base(contextOptions)
        {
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<City> Cities { get; set; }

 



        public class ApplicationDbContext : DbContext
        {
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer(@"Data Source=localhost\THAER;Initial Catalog=Person;Integrated Security=True");
            }
        }




    }
}
