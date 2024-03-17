//namespace BookStore.Services
//{
//    public class CitationGenerator
//    {
//    }
//}

using System;
using BookStore.Models;

namespace BookStore.Services
{
    public static class CitationGenerator
    {
        public static string GenerateMLACitation(Book book)
        {
            return $"{book.AuthorLastName}, {book.AuthorFirstName}. \"{book.Title}\". {book.Publisher}, {book.Price:C}.";
        }

        public static string GenerateChicagoCitation(Book book)
        {
            return $"{book.AuthorLastName}, {book.AuthorFirstName}. {book.Title}. {book.Publisher}, {book.Price:C}.";
        }
    }
}

