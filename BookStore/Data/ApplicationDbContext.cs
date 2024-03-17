using Microsoft.EntityFrameworkCore;
using BookStore.Models;

namespace BookStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the Book entity
            modelBuilder.Entity<Book>(entity =>
            {
                // Specify the table name
                entity.ToTable("Books");

                // Specify primary key
                entity.HasKey(e => e.Id);

                // Configure properties
                entity.Property(e => e.Publisher).IsRequired();
                entity.Property(e => e.Title).IsRequired();
                entity.Property(e => e.AuthorLastName).IsRequired();
                entity.Property(e => e.AuthorFirstName).IsRequired();
                entity.Property(e => e.Price).HasColumnType("decimal(18,2)").IsRequired();
            });
        }
    }
}
