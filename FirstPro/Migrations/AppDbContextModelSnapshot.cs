﻿// <auto-generated />
using FirstPro.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FirstPro.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FirstPro.Models.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Milano"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 2,
                            Name = "Barcalona"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 3,
                            Name = "Stockholm"
                        });
                });

            modelBuilder.Entity("FirstPro.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Country");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Italy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Spain"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Sweden"
                        });
                });

            modelBuilder.Entity("FirstPro.Models.Language", b =>
                {
                    b.Property<int>("LangId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LangId"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("LangId");

                    b.ToTable("Language");

                    b.HasData(
                        new
                        {
                            LangId = 1,
                            Name = "Italian",
                            PersonId = 1
                        },
                        new
                        {
                            LangId = 2,
                            Name = "Spanish",
                            PersonId = 2
                        },
                        new
                        {
                            LangId = 3,
                            Name = "Svenska",
                            PersonId = 3
                        });
                });

            modelBuilder.Entity("FirstPro.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PersonId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"), 1L, 1);

                    b.Property<int>("CityId")
                        .HasColumnType("int")
                        .HasColumnName("CityId");

                    b.Property<int>("LangId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Name");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("PersonId");

                    b.HasIndex("CityId");

                    b.ToTable("Person");

                    b.HasData(
                        new
                        {
                            PersonId = 1,
                            CityId = 1,
                            LangId = 1,
                            Name = "Laras",
                            PhoneNumber = "07000000 "
                        },
                        new
                        {
                            PersonId = 2,
                            CityId = 2,
                            LangId = 2,
                            Name = "Roben",
                            PhoneNumber = "07000000"
                        },
                        new
                        {
                            PersonId = 3,
                            CityId = 3,
                            LangId = 3,
                            Name = "Matilda",
                            PhoneNumber = "07000000"
                        });
                });

            modelBuilder.Entity("LanguagePerson", b =>
                {
                    b.Property<int>("PeoplePersonId")
                        .HasColumnType("int");

                    b.Property<int>("languagesLangId")
                        .HasColumnType("int");

                    b.HasKey("PeoplePersonId", "languagesLangId");

                    b.HasIndex("languagesLangId");

                    b.ToTable("LanguagePerson");
                });

            modelBuilder.Entity("FirstPro.Models.City", b =>
                {
                    b.HasOne("FirstPro.Models.Country", "Country")
                        .WithMany("cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("FirstPro.Models.Person", b =>
                {
                    b.HasOne("FirstPro.Models.City", "City")
                        .WithMany("People")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("LanguagePerson", b =>
                {
                    b.HasOne("FirstPro.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PeoplePersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FirstPro.Models.Language", null)
                        .WithMany()
                        .HasForeignKey("languagesLangId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FirstPro.Models.City", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("FirstPro.Models.Country", b =>
                {
                    b.Navigation("cities");
                });
#pragma warning restore 612, 618
        }
    }
}
