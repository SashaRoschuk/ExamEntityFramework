using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System;

using ExamEntityFramework;

using LibraryDataDB.helpers;
using ExamEntityFramework.Entities;


namespace WpfApp1
{
    public static class PlaceholderService
    {
        public static readonly DependencyProperty PlaceholderProperty =
            DependencyProperty.RegisterAttached("Placeholder", typeof(string), typeof(PlaceholderService), new PropertyMetadata(string.Empty, OnPlaceholderChanged));

        public static string GetPlaceholder(TextBox textBox)
        {
            return (string)textBox.GetValue(PlaceholderProperty);
        }

        public static void SetPlaceholder(TextBox textBox, string value)
        {
            textBox.SetValue(PlaceholderProperty, value);
        }

        private static void OnPlaceholderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is TextBox textBox)
            {
                textBox.GotFocus += RemovePlaceholder;
                textBox.LostFocus += ShowPlaceholder;

                if (string.IsNullOrEmpty(textBox.Text))
                {
                    ShowPlaceholder(textBox, null);
                }
            }
        }

        private static void ShowPlaceholder(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
            {
                textBox.Text = GetPlaceholder(textBox);
                textBox.Foreground = Brushes.Gray;
            }
        }

        private static void RemovePlaceholder(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox && textBox.Text == GetPlaceholder(textBox))
            {
                textBox.Text = string.Empty;
                textBox.Foreground = Brushes.Black;
            }
        }
    }
    public partial class MainWindow : Window
    {
        // Method to show countries
        private void ShowCountries_Click(object sender, RoutedEventArgs e)
        {
            var countries = db.Countries.ToList();
            CountriesList.Items.Clear();
            foreach (var country in countries)
            {
                CountriesList.Items.Add($"{country.Name}");
            }
        }

        // Method to add a country
        private void AddCountry_Click(object sender, RoutedEventArgs e)
        {
            var newCountry = new Country
            {
                Name = CountryName.Text
            };

            db.Countries.Add(newCountry);
            db.SaveChanges();
            MessageBox.Show("Country added successfully!");
            ShowCountries_Click(sender, e); // Refresh the list
        }

        // Method to edit an existing country
        private void EditCountry_Click(object sender, RoutedEventArgs e)
        {
            var selectedCountry = db.Countries.FirstOrDefault(c => c.Name == CountryName.Text);
            if (selectedCountry != null)
            {
                selectedCountry.Name = CountryName.Text;
                db.SaveChanges();
                MessageBox.Show("Country updated successfully!");
                ShowCountries_Click(sender, e); // Refresh the list
            }
            else
            {
                MessageBox.Show("Country not found!");
            }
        }

        // Method to delete a country
        private void DeleteCountry_Click(object sender, RoutedEventArgs e)
        {
            var selectedCountry = db.Countries.FirstOrDefault(c => c.Name == CountryName.Text);
            if (selectedCountry != null)
            {
                db.Countries.Remove(selectedCountry);
                db.SaveChanges();
                MessageBox.Show("Country deleted successfully!");
                ShowCountries_Click(sender, e); // Refresh the list
            }
            else
            {
                MessageBox.Show("Country not found!");
            }
        }

        // Method to show publishers
        private void ShowPublishers_Click(object sender, RoutedEventArgs e)
        {
            var publishers = db.Publishers.ToList();
            PublishersList.Items.Clear();
            foreach (var publisher in publishers)
            {
                PublishersList.Items.Add($"{publisher.Name} - {publisher.Description}");
            }
        }

        // Method to add a publisher
        private void AddPublisher_Click(object sender, RoutedEventArgs e)
        {
            var newPublisher = new Publisher
            {
                Name = PublisherName.Text,
                Description = PublisherDescription.Text
            };

            db.Publishers.Add(newPublisher);
            db.SaveChanges();
            MessageBox.Show("Publisher added successfully!");
            ShowPublishers_Click(sender, e); // Refresh the list
        }

        // Method to edit an existing publisher
        private void EditPublisher_Click(object sender, RoutedEventArgs e)
        {
            var selectedPublisher = db.Publishers.FirstOrDefault(p => p.Name == PublisherName.Text);
            if (selectedPublisher != null)
            {
                selectedPublisher.Description = PublisherDescription.Text;
                db.SaveChanges();
                MessageBox.Show("Publisher updated successfully!");
                ShowPublishers_Click(sender, e); // Refresh the list
            }
            else
            {
                MessageBox.Show("Publisher not found!");
            }
        }

        // Method to delete a publisher
        private void DeletePublisher_Click(object sender, RoutedEventArgs e)
        {
            var selectedPublisher = db.Publishers.FirstOrDefault(p => p.Name == PublisherName.Text);
            if (selectedPublisher != null)
            {
                db.Publishers.Remove(selectedPublisher);
                db.SaveChanges();
                MessageBox.Show("Publisher deleted successfully!");
                ShowPublishers_Click(sender, e); // Refresh the list
            }
            else
            {
                MessageBox.Show("Publisher not found!");
            }
        }


        private LibraryDBcontext db;

        public MainWindow()
        {
            InitializeComponent();
            db = new LibraryDBcontext();
        }

        // Function to show authors
        private void ShowAuthors_Click(object sender, RoutedEventArgs e)
        {
            var authors = db.Authors.ToList();
            AuthorsList.Items.Clear();
            foreach (var author in authors)
            {
                AuthorsList.Items.Add($"{author.FirstName} {author.LastName} - {author.Email}");
            }
        }

        // Function to add a new author
        private void AddAuthor_Click(object sender, RoutedEventArgs e)
        {
            var newAuthor = new Author
            {
                FirstName = AuthorFirstName.Text,
                LastName = AuthorLastName.Text,
                Email = AuthorEmail.Text,
                Phone = AuthorPhone.Text,
                CountryID = int.Parse(AuthorCountryID.Text)
            };

            db.Authors.Add(newAuthor);
            db.SaveChanges();
            MessageBox.Show("Author added successfully!");
            ShowAuthors_Click(sender, e); // Refresh list after adding
        }

        // Function to edit an existing author
        private void EditAuthor_Click(object sender, RoutedEventArgs e)
        {
            var selectedAuthor = db.Authors.FirstOrDefault(a => a.FirstName == AuthorFirstName.Text && a.LastName == AuthorLastName.Text);
            if (selectedAuthor != null)
            {
                selectedAuthor.Email = AuthorEmail.Text;
                selectedAuthor.Phone = AuthorPhone.Text;
                selectedAuthor.CountryID = int.Parse(AuthorCountryID.Text);

                db.SaveChanges();
                MessageBox.Show("Author updated successfully!");
                ShowAuthors_Click(sender, e); // Refresh list after editing
            }
            else
            {
                MessageBox.Show("Author not found!");
            }
        }

        // Function to delete an author
        private void DeleteAuthor_Click(object sender, RoutedEventArgs e)
        {
            var selectedAuthor = db.Authors.FirstOrDefault(a => a.FirstName == AuthorFirstName.Text && a.LastName == AuthorLastName.Text);
            if (selectedAuthor != null)
            {
                db.Authors.Remove(selectedAuthor);
                db.SaveChanges();
                MessageBox.Show("Author deleted successfully!");
                ShowAuthors_Click(sender, e); // Refresh list after deletion
            }
            else
            {
                MessageBox.Show("Author not found!");
            }
        }

        // Function to show genres
        private void ShowGenres_Click(object sender, RoutedEventArgs e)
        {
            var genres = db.Genres.ToList();
            GenresList.Items.Clear();
            foreach (var genre in genres)
            {
                GenresList.Items.Add(genre.Name);
            }
        }

        // Function to add a new genre
        private void AddGenre_Click(object sender, RoutedEventArgs e)
        {
            var newGenre = new Genre { Name = GenreName.Text };
            db.Genres.Add(newGenre);
            db.SaveChanges();
            MessageBox.Show("Genre added successfully!");
            ShowGenres_Click(sender, e); // Refresh list after adding
        }

        // Function to edit an existing genre
        private void EditGenre_Click(object sender, RoutedEventArgs e)
        {
            var selectedGenre = db.Genres.FirstOrDefault(g => g.Name == GenreName.Text);
            if (selectedGenre != null)
            {
                selectedGenre.Name = GenreName.Text;

                db.SaveChanges();
                MessageBox.Show("Genre updated successfully!");
                ShowGenres_Click(sender, e); // Refresh list after editing
            }
            else
            {
                MessageBox.Show("Genre not found!");
            }
        }

        // Function to delete a genre
        private void DeleteGenre_Click(object sender, RoutedEventArgs e)
        {
            var selectedGenre = db.Genres.FirstOrDefault(g => g.Name == GenreName.Text);
            if (selectedGenre != null)
            {
                db.Genres.Remove(selectedGenre);
                db.SaveChanges();
                MessageBox.Show("Genre deleted successfully!");
                ShowGenres_Click(sender, e); // Refresh list after deletion
            }
            else
            {
                MessageBox.Show("Genre not found!");
            }
        }

        // Function to show books
        private void ShowBooks_Click(object sender, RoutedEventArgs e)
        {
            var books = db.Books.ToList();
            BooksList.Items.Clear();
            foreach (var book in books)
            {
                BooksList.Items.Add($"{book.Name} - {book.Description}");
            }
        }

        // Function to add a new book
        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            var newBook = new Book
            {
                Name = BookName.Text,
                Description = BookDescription.Text,
                Istrilogy = BookIsTrilogy.IsChecked ?? false,
                PublicationDate = BookPublicationDate.SelectedDate ?? DateTime.Now,
                Rating = int.Parse(BookRating.Text),
                AuthorID = int.Parse(BookAuthorID.Text),
                PublisherID = int.Parse(BookPublisherID.Text),
                GenreID = int.Parse(BookGenreID.Text)
            };

            db.Books.Add(newBook);
            db.SaveChanges();
            MessageBox.Show("Book added successfully!");
            ShowBooks_Click(sender, e); // Refresh list after adding
        }

        // Function to edit an existing book
        private void EditBook_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = db.Books.FirstOrDefault(b => b.Name == BookName.Text);
            if (selectedBook != null)
            {
                selectedBook.Description = BookDescription.Text;
                selectedBook.Istrilogy = BookIsTrilogy.IsChecked ?? false;
                selectedBook.PublicationDate = BookPublicationDate.SelectedDate ?? DateTime.Now;
                selectedBook.Rating = int.Parse(BookRating.Text);
                selectedBook.AuthorID = int.Parse(BookAuthorID.Text);
                selectedBook.PublisherID = int.Parse(BookPublisherID.Text);
                selectedBook.GenreID = int.Parse(BookGenreID.Text);

                db.SaveChanges();
                MessageBox.Show("Book updated successfully!");
                ShowBooks_Click(sender, e); // Refresh list after editing
            }
            else
            {
                MessageBox.Show("Book not found!");
            }
        }

        // Function to delete a book
        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            var selectedBook = db.Books.FirstOrDefault(b => b.Name == BookName.Text);
            if (selectedBook != null)
            {
                db.Books.Remove(selectedBook);
                db.SaveChanges();
                MessageBox.Show("Book deleted successfully!");
                ShowBooks_Click(sender, e); // Refresh list after deletion
            }
            else
            {
                MessageBox.Show("Book not found!");
            }
        }
    }
}
