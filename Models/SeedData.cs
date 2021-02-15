using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineBooks.Models
{
    public class SeedData
    {
        public static void EnsurePopulated (IApplicationBuilder application)            //populate database with seed data
        {
            BooksDbContext context = application.ApplicationServices.CreateScope().
                ServiceProvider.GetRequiredService<BooksDbContext>();

            if (context.Database.GetPendingMigrations().Any())      //Make migrations when necessary
            {
                context.Database.Migrate();
            }

            if (!context.Books.Any())
            {
                context.Books.AddRange(

                    new Books
                    {
                        Title = "Les Miserables",
                        Author = "Victor Hugo",
                        Publisher = "Signet",
                        Isbn = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = new decimal(9.95)
                    },

                    new Books
                    {
                        Title = "Team of Rivals",
                        Author = "Doris Kearns Goodwin",
                        Publisher = "Simon & Schuster",
                        Isbn = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = new decimal(14.58)
                    },

                    new Books
                    {
                        Title = "The Snowball",
                        Author = "Alice Schroeder",
                        Publisher = "Bantam",
                        Isbn = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = new decimal(21.54)
                    },

                    new Books
                    {
                        Title = "American Ulysses",
                        Author = "Ronald C. White",
                        Publisher = "Random House",
                        Isbn = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = new decimal(11.61)
                    },

                    new Books
                    {
                        Title = "Unbroken",
                        Author = "Laura Hillenbrand",
                        Publisher = "Random House",
                        Isbn = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = new decimal(13.33)
                    },

                    new Books
                    {
                        Title = "The Greate Train Robbery",
                        Author = "Michael Crichton",
                        Publisher = "Vintage",
                        Isbn = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = new decimal(15.95)
                    },

                    new Books
                    {
                        Title = "Deep Work",
                        Author = "Cal Newport",
                        Publisher = "Grand Central Publishing",
                        Isbn = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = new decimal(14.99)
                    },

                    new Books
                    {
                        Title = "It's Your Ship",
                        Author = "Michael Abrashoff",
                        Publisher = "Grand Central Publishing",
                        Isbn = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = new decimal(21.66)
                    },

                    new Books
                    {
                        Title = "The Virgin Way",
                        Author = "Richard Branson",
                        Publisher = "Portfolio",
                        Isbn = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = new decimal(29.16)
                    },

                    new Books
                    {
                        Title = "Sycamore Row",
                        Author = "John Grisham",
                        Publisher = "Bantam",
                        Isbn = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = new decimal(15.03)
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
