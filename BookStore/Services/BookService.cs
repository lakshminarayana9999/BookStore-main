//namespace BookStore.Services
//{
//    public class BookService
//    {

//    }
//}

// Services/BookService.cs
using System.Collections.Generic;
using BookStore.Data;
using BookStore.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Book> GetBooksSortedByPublisher()
        {
            return _context.Books.OrderBy(b => b.Publisher)
                                 .ToList();
        }
        //public void AddBook(Book book)
        //{
        //    _context.Books.Add(book);
        //}
        public void AddBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }
        public List<Book> GetBooksSortedByAuthorFirstName()
        {
            return _context.Books.OrderBy(b => b.AuthorFirstName)
                                 .ToList();
        }

        public List<Book> GetBooksSortedByAuthorLastName()
        {
            return _context.Books.OrderBy(b => b.AuthorLastName)
                                 .ToList();
        }


        public List<Book> GetBooksSortedByTitle()
        {
            return _context.Books.OrderBy(b => b.Title).ToList();
        }

        // Method to calculate the total price of all books
        public decimal GetTotalPriceOfBooks()
        {
            return _context.Books.Sum(b => b.Price);
        }

        // Method to save a list of books to the database in a single call
        public async Task SaveBooksToDatabase(List<Book> books)
        {
            await _context.Books.AddRangeAsync(books);
            await _context.SaveChangesAsync();
        }

        // Method to generate MLA style citation for a book
        public string GetMLACitation(Book book)
        {
            return book.GenerateMLACitation();
            //return $"{book.AuthorLastName}, {book.AuthorFirstName}. \"{book.Title}\". {book.Publisher}, {book.Price:C}.";
        }

        // Method to generate Chicago style citation for a book
        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);

        }

        
        public void DeleteBook(int id)
        {
            var bookToRemove = _context.Books.FirstOrDefault(b => b.Id == id);
            if (bookToRemove != null)
            {
                _context.Books.Remove(bookToRemove);
                _context.SaveChanges(); // Save changes to commit the deletion
            }
        }
        public void UpdateBook(Book book)
        {
            // Optionally, you can attach the book entity to the context and mark it as modified.
            _context.Update(book);
            _context.SaveChanges();
        }

        public string GetChicagoCitation(Book book)
        {
            return book.GenerateChicagoCitation();
            //return $"{book.AuthorLastName}, {book.AuthorFirstName}. {book.Title}. {book.Publisher}, {book.Price:C}.";
        }
    }
}

