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
        public DbSet<Language> languages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 1, Name = "Laras", PhoneNumber = "07000000 ", CityId = 1,LangId = 1});
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 2, Name = "Roben", PhoneNumber = "07000000", CityId = 2 , LangId = 2 });
            modelBuilder.Entity<Person>().HasData(new Person { PersonId = 3, Name = "Matilda", PhoneNumber = "07000000", CityId = 3, LangId = 3 });


            modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Italy" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Spain" });
            modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Sweden" });
            

            modelBuilder.Entity<City>().HasData(new City { Id = 1, Name = "Milano", CountryId = 1 });
            modelBuilder.Entity<City>().HasData(new City { Id = 2, Name = "Barcalona", CountryId = 2 });
            modelBuilder.Entity<City>().HasData(new City { Id = 3, Name = "Stockholm", CountryId = 3 });

            modelBuilder.Entity<Language>().HasData(new Language { LangId = 1, Name = "Italian", PersonId = 1 });
            modelBuilder.Entity<Language>().HasData(new Language { LangId = 2, Name = "Spanish", PersonId = 2 });
            modelBuilder.Entity<Language>().HasData(new Language { LangId = 3, Name = "Svenska", PersonId = 3 });

            modelBuilder.Entity<Person>().HasOne(c => c.City )
                .WithMany(p => p.People)
                .HasForeignKey(p => p.CityId);

/*
            modelBuilder.Entity<Person>().HasMany(l => l.languages)
                .WithMany(p => p.People)
                .UsingEntity(h => h.HasData(new { PersonId = 1, LangId = 1 }));*/

        }



        /*public class ApplicationDbContext : DbContext
            {
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlServer(@"Data Source=localhost\THAER;Initial Catalog=Person;Integrated Security=True");
                }
            }


     */

    }

}
