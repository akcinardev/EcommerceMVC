using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                    new Category { Id = 1, Name = "Action", DisplayOrder = 1 },
                    new Category { Id = 2, Name = "SciFi", DisplayOrder = 2 },
                    new Category { Id = 3, Name = "History", DisplayOrder = 3 }
            );

            modelBuilder.Entity<Product>().HasData(
                    new Product
                    {
                        Id = 1,
                        Title = "Pride and Prejudice",
                        Description = "A romantic novel of manners written by Jane Austen.",
                        ISBN = "9780141040349",
                        Author = "Jane Austen",
                        ListPrice = 7.49,
                        CategoryId = 1,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = 2,
                        Title = "1984",
                        Description = "A dystopian social science fiction novel and cautionary tale.",
                        ISBN = "9780451524935",
                        Author = "George Orwell",
                        ListPrice = 9.99,
						CategoryId = 1,
						ImageUrl = ""
					},
                    new Product
                    {
                        Id = 3,
                        Title = "To Kill a Mockingbird",
                        Description = "A novel about the serious issues of rape and racial inequality.",
                        ISBN = "9780061120084",
                        Author = "Harper Lee",
                        ListPrice = 8.99,
                        CategoryId = 1,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = 4,
                        Title = "The Great Gatsby",
                        Description = "A novel about the American dream and the roaring twenties.",
                        ISBN = "9780743273565",
                        Author = "F. Scott Fitzgerald",
                        ListPrice = 10.99,
                        CategoryId = 1,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = 5,
                        Title = "Moby Dick",
                        Description = "A novel about the voyage of the whaling ship Pequod.",
                        ISBN = "9781503280786",
                        Author = "Herman Melville",
                        ListPrice = 11.99,
                        CategoryId = 1,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = 6,
                        Title = "War and Peace",
                        Description = "A historical novel that tells the story of five families.",
                        ISBN = "9780140447934",
                        Author = "Leo Tolstoy",
                        ListPrice = 12.99,
                        CategoryId = 1,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = 7,
                        Title = "The Catcher in the Rye",
                        Description = "A story about adolescent alienation and loss of innocence.",
                        ISBN = "9780316769488",
                        Author = "J.D. Salinger",
                        ListPrice = 7.99,
                        CategoryId = 1,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = 8,
                        Title = "The Hobbit",
                        Description = "A fantasy novel about the journey of Bilbo Baggins.",
                        ISBN = "9780547928227",
                        Author = "J.R.R. Tolkien",
                        ListPrice = 10.99,
                        CategoryId = 1,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = 9,
                        Title = "The Odyssey",
                        Description = "An ancient Greek epic poem attributed to Homer.",
                        ISBN = "9780140268867",
                        Author = "Homer",
                        ListPrice = 9.49,
                        CategoryId = 1,
                        ImageUrl = ""
                    },
                    new Product
                    {
                        Id = 10,
                        Title = "Crime and Punishment",
                        Description = "A novel about the mental anguish and moral dilemmas of a poor ex-student.",
                        ISBN = "9780140449136",
                        Author = "Fyodor Dostoevsky",
                        ListPrice = 11.49,
                        CategoryId = 1,
                        ImageUrl = ""
                    }
            );
        }
    }
}
