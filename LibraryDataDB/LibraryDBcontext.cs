using ExamEntityFramework.Entities;
using ExamEntityFramework.helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamEntityFramework
{
    public class LibraryDBcontext : DbContext
    {
        public LibraryDBcontext()
        {
            
            this.Database.EnsureCreated();
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\localDB1;Initial Catalog = LibraryDb; Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            

            modelBuilder.Entity<Author>().HasMany(a=>a.Books).WithOne(b=>b.Author).HasForeignKey(b=>b.AuthorID);
            modelBuilder.Entity<Author>().HasOne(a=>a.Country).WithMany(c=>c.Authors).HasForeignKey(a=>a.CountryID);

            modelBuilder.Entity<Book>().HasOne(b=>b.Publisher).WithMany(b=>b.Books).HasForeignKey(b=>b.PublisherID);
            

           // modelBuilder.Entity<Country>().HasMany(c=>c.Authors).WithOne(a=>a.Country).HasForeignKey(a=>a.CountryID);
            
            modelBuilder.Entity<Genre>().HasMany(g => g.Books).WithOne(b=>b.Genre).HasForeignKey(b=>b.GenreID);


            //modelBuilder.Entity<Publisher>().HasMany(p => p.Books).WithOne(b=>b.Publisher).HasForeignKey(b=>b.PublisherID);


            //modelBuilder.SeedGenres();
            //modelBuilder.SeedCountries();
            //modelBuilder.SeedPublishers();
            //modelBuilder.SeedAuthors();
            //modelBuilder.SeedBooks();
            modelBuilder.Seed();

        }
    }
}
