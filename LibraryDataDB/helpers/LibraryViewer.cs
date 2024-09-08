using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExamEntityFramework;
using ExamEntityFramework.Entities;

namespace LibraryDataDB.helpers
{
    
   
    

    public class LibraryViewer
    {
        private LibraryDBcontext _dbContext;

        public LibraryViewer()
        {
            _dbContext = new LibraryDBcontext();
        }

        // ------------------- Автори -------------------

        // Показати авторів за параметром або всіх
        public List<Author> ShowAuthors(string lastName = null, int topN = 10)
        {
            var authors = _dbContext.Authors
                .Where(a => lastName == null || a.LastName.Contains(lastName))
                .Take(topN);
                //.Select(a => new { a.FirstName, a.LastName, a.Email, a.Phone })
                //.ToList();
            
            return authors.ToList();
        }

        // ------------------- Жанри -------------------

        // Показати жанри за параметром або всі
        public List<Genre> ShowGenres(string name = null, int topN = 10)
        {
            var genres = _dbContext.Genres
                .Where(g => name == null || g.Name.Contains(name))
                .Take(topN);
                //.Select(g => new { g.Name })
                //.ToList();
                return genres.ToList();
            
        }

        // ------------------- Видавці -------------------

        // Показати видавців за параметром або всіх
        public List<Publisher> ShowPublishers(string name = null, int topN = 10)
        {
            var publishers = _dbContext.Publishers
                .Where(p => name == null || p.Name.Contains(name))
                .Take(topN);
                //.Select(p => new { p.Name, p.Description })
                //.ToList();

            return publishers.ToList();
        }

        // ------------------- Країни -------------------

        // Показати країни за параметром або всі
        public List<Country> ShowCountries(string name = null, int topN = 10)
        {
            var countries = _dbContext.Countries
                .Where(c => name == null || c.Name.Contains(name))
                .Take(topN);
                //.Select(c => new { c.Name })
                //.ToList();
                return countries.ToList();
            
        }
    }

}
