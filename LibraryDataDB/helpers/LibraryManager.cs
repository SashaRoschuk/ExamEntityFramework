using ExamEntityFramework.Entities;
using ExamEntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDataDB.helpers
{
    public class LibraryManager
    {
        private LibraryDBcontext _dbContext;

        public LibraryManager()
        {
            _dbContext = new LibraryDBcontext();
        }

        // Додавання нової книги
        public void AddBook(string name, string description, bool isTrilogy, DateTime publicationDate, int rating, int authorID, int publisherID, int genreID)
        {
            var newBook = new Book
            {
                Name = name,
                Description = description,
                Istrilogy = isTrilogy,
                PublicationDate = publicationDate,
                Rating = rating,
                AuthorID = authorID,
                PublisherID = publisherID,
                GenreID = genreID
            };

            _dbContext.Books.Add(newBook);
            _dbContext.SaveChanges();
            Console.WriteLine("Book added successfully!");
        }

        // Видалення книги
        public void DeleteBook(int bookId)
        {
            var book = _dbContext.Books.Find(bookId);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                _dbContext.SaveChanges();
                Console.WriteLine("Book deleted successfully!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        // Редагування книги за параметрами
        public void EditBook(int bookId, string newName = null, int? newAuthorId = null, int? newGenreId = null)
        {
            var book = _dbContext.Books.Find(bookId);
            if (book != null)
            {
                if (!string.IsNullOrEmpty(newName))
                    book.Name = newName;

                if (newAuthorId.HasValue)
                    book.AuthorID = newAuthorId.Value;

                if (newGenreId.HasValue)
                    book.GenreID = newGenreId.Value;

                _dbContext.SaveChanges();
                Console.WriteLine("Book updated successfully!");
            }
            else
            {
                Console.WriteLine("Book not found!");
            }
        }

        // Перегляд новинок (найновіші книги)
        public void ViewLatestBooks(int topN = 5)
        {
            var latestBooks = _dbContext.Books
                .OrderByDescending(b => b.PublicationDate)
                .Take(topN)
                .Join(_dbContext.Authors, b => b.AuthorID, a => a.ID, (b, a) => new { b, a })
                .Join(_dbContext.Genres, ba => ba.b.GenreID, g => g.ID, (ba, g) => new { ba.b, ba.a, g })
                .Select(bg => new
                {
                    bg.b.ID,
                    bg.b.Name,
                    AuthorName = bg.a.FirstName + " " + bg.a.LastName,
                    GenreName = bg.g.Name,
                    bg.b.PublicationDate
                })
                .ToList();

            Console.WriteLine("Latest Books:");
            foreach (var book in latestBooks)
            {
                Console.WriteLine($"{book.ID}|{book.Name}|{book.AuthorName}|{book.GenreName}|{book.PublicationDate.ToShortDateString()}");
            }
        }

        // ------------------- Автори -------------------

        // Додавання нового автора
        public void AddAuthor(string firstName, string lastName, string email, string phone, int countryID)
        {
            var newAuthor = new Author
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Phone = phone,
                CountryID = countryID
            };

            _dbContext.Authors.Add(newAuthor);
            _dbContext.SaveChanges();
            Console.WriteLine("Author added successfully!");
        }

        // Видалення автора
        public void DeleteAuthor(int authorId)
        {
            var author = _dbContext.Authors.Find(authorId);
            if (author != null)
            {
                _dbContext.Authors.Remove(author);
                _dbContext.SaveChanges();
                Console.WriteLine("Author deleted successfully!");
            }
            else
            {
                Console.WriteLine("Author not found!");
            }
        }

        // Редагування автора
        public void EditAuthor(int authorId, string newFirstName = null, string newLastName = null, string newEmail = null, string newPhone = null)
        {
            var author = _dbContext.Authors.Find(authorId);
            if (author != null)
            {
                if (!string.IsNullOrEmpty(newFirstName))
                    author.FirstName = newFirstName;

                if (!string.IsNullOrEmpty(newLastName))
                    author.LastName = newLastName;

                if (!string.IsNullOrEmpty(newEmail))
                    author.Email = newEmail;

                if (!string.IsNullOrEmpty(newPhone))
                    author.Phone = newPhone;

                _dbContext.SaveChanges();
                Console.WriteLine("Author updated successfully!");
            }
            else
            {
                Console.WriteLine("Author not found!");
            }
        }

        // ------------------- Жанри -------------------

        // Додавання нового жанру
        public void AddGenre(string name)
        {
            var newGenre = new Genre
            {
                Name = name
            };

            _dbContext.Genres.Add(newGenre);
            _dbContext.SaveChanges();
            Console.WriteLine("Genre added successfully!");
        }

        // Видалення жанру
        public void DeleteGenre(int genreId)
        {
            var genre = _dbContext.Genres.Find(genreId);
            if (genre != null)
            {
                _dbContext.Genres.Remove(genre);
                _dbContext.SaveChanges();
                Console.WriteLine("Genre deleted successfully!");
            }
            else
            {
                Console.WriteLine("Genre not found!");
            }
        }

        // Редагування жанру
        public void EditGenre(int genreId, string newName)
        {
            var genre = _dbContext.Genres.Find(genreId);
            if (genre != null)
            {
                if (!string.IsNullOrEmpty(newName))
                    genre.Name = newName;

                _dbContext.SaveChanges();
                Console.WriteLine("Genre updated successfully!");
            }
            else
            {
                Console.WriteLine("Genre not found!");
            }
        }

        // ------------------- Видавці -------------------

        // Додавання нового видавця
        public void AddPublisher(string name, string description)
        {
            var newPublisher = new Publisher
            {
                Name = name,
                Description = description
            };

            _dbContext.Publishers.Add(newPublisher);
            _dbContext.SaveChanges();
            Console.WriteLine("Publisher added successfully!");
        }

        // Видалення видавця
        public void DeletePublisher(int publisherId)
        {
            var publisher = _dbContext.Publishers.Find(publisherId);
            if (publisher != null)
            {
                _dbContext.Publishers.Remove(publisher);
                _dbContext.SaveChanges();
                Console.WriteLine("Publisher deleted successfully!");
            }
            else
            {
                Console.WriteLine("Publisher not found!");
            }
        }

        // Редагування видавця
        public void EditPublisher(int publisherId, string newName = null, string newDescription = null)
        {
            var publisher = _dbContext.Publishers.Find(publisherId);
            if (publisher != null)
            {
                if (!string.IsNullOrEmpty(newName))
                    publisher.Name = newName;

                if (!string.IsNullOrEmpty(newDescription))
                    publisher.Description = newDescription;

                _dbContext.SaveChanges();
                Console.WriteLine("Publisher updated successfully!");
            }
            else
            {
                Console.WriteLine("Publisher not found!");
            }
        }

        // ------------------- Країни -------------------

        // Додавання нової країни
        public void AddCountry(string name)
        {
            var newCountry = new Country
            {
                Name = name
            };

            _dbContext.Countries.Add(newCountry);
            _dbContext.SaveChanges();
            Console.WriteLine("Country added successfully!");
        }

        // Видалення країни
        public void DeleteCountry(int countryId)
        {
            var country = _dbContext.Countries.Find(countryId);
            if (country != null)
            {
                _dbContext.Countries.Remove(country);
                _dbContext.SaveChanges();
                Console.WriteLine("Country deleted successfully!");
            }
            else
            {
                Console.WriteLine("Country not found!");
            }
        }

        // Редагування країни
        public void EditCountry(int countryId, string newName)
        {
            var country = _dbContext.Countries.Find(countryId);
            if (country != null)
            {
                if (!string.IsNullOrEmpty(newName))
                    country.Name = newName;

                _dbContext.SaveChanges();
                Console.WriteLine("Country updated successfully!");
            }
            else
            {
                Console.WriteLine("Country not found!");
            }
        }
    }
}
