//namespace BookStore.Models
//{
//    public class Book
//    {
//    }
//}
// Models/Book.cs
using System;

namespace BookStore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Publisher { get; set; }
        public string? Title { get; set; }
        public string? AuthorLastName { get; set; }
        public string? AuthorFirstName { get; set; }
        public decimal Price { get; set; }

        public string? Year { get; set; }

        // Additional properties for citation generation
        public string PublishedDate { get; set; }
        public string Edition { get; set; }

        // Constructor
        public Book()
        {
            Edition = "first";
            PublishedDate = "01022024";
            // Initialize properties if necessary
        }

        // Method to generate MLA citation
        public string GenerateMLACitation()
        {
            // Implement MLA citation format
            return $"{AuthorLastName}, {AuthorFirstName}. \"{Title}\". {Publisher}, {Year}.";
        }


        // Method to generate Chicago style citation
        public string GenerateChicagoCitation()
        {
            // Implement Chicago citation format
            return $"{AuthorLastName}, {AuthorFirstName}. *{Title}*. {Publisher}, {PublishedDate}.";
        }

    }
}
