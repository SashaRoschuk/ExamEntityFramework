using ExamEntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ExamEntityFramework.helpers
{
    public static class DbInitializer
    {
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                 new Country[]
                 {
                   new Country {ID=1,  Name = "Ukraine" },
                    new Country { ID=2, Name = "United States" }
                  });
        }
        public static void SeedAuthors(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData((
        new Author[]
        {
        new Author {ID=1,  FirstName = "Andrey", LastName = "Shevchenko", Email = "andrey.shevchenko@example.com", Phone = "123-456-7890", CountryID = 1 },
        new Author {ID = 2,   FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", Phone = "098-765-4321", CountryID = 2 }

        }
    ));
        }

        public static void SeedBooks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData((
                new Book[] 
                {
            new Book { ID = 1, Name = "The Great Adventure", Description = "A thrilling adventure story.", Istrilogy = true, PublicationDate = new DateTime(2023, 5, 10), Rating = 5, AuthorID = 1, PublisherID = 1, GenreID = 1 },
            new Book { ID = 2, Name = "Science Unveiled", Description = "An exploration of modern scientific concepts.", Istrilogy = false, PublicationDate = new DateTime(2024, 1, 15), Rating = 4, AuthorID = 2, PublisherID = 2, GenreID = 2 }
                }
            ));
        }

        public static void SeedGenres(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData((
                new Genre[] 
                {
                 new Genre { ID = 1, Name = "Fiction" },
                 new Genre { ID = 2, Name = "Non-Fiction" }
                }
                 ));
        }
        public static void SeedPublishers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Publisher>().HasData((
                new Publisher[] {
                  new Publisher { ID = 1, Name = "Penguin Random House", Description = "A major publishing company." },
                  new Publisher { ID = 2, Name = "HarperCollins", Description = "A leading global publisher." }
                }
                  ));
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedGenres();
            modelBuilder.SeedCountries();
            modelBuilder.SeedPublishers();
            modelBuilder.SeedAuthors();
            modelBuilder.SeedBooks();
        }
    }
}
