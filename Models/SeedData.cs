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

                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirstName = "Victor",
                        AuthorLastName = "Hugo",
                        Publisher = "Signet",
                        Isbn = "978-0451419439",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = new decimal(9.95),
                        NumPages = 1488
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirstName = "Doris",
                        AuthorMiddleName = "Kearns",
                        AuthorLastName = "Goodwin",
                        Publisher = "Simon & Schuster",
                        Isbn = "978-0743270755",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = new decimal(14.58),
                        NumPages = 944
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirstName = "Alice",
                        AuthorLastName = "Schroeder",
                        Publisher = "Bantam",
                        Isbn = "978-0553384611",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = new decimal(21.54),
                        NumPages = 832
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirstName = "Ronald",
                        AuthorMiddleName = "C",
                        AuthorLastName = "White",
                        Publisher = "Random House",
                        Isbn = "978-0812981254",
                        Classification = "Non-Fiction",
                        Category = "Biography",
                        Price = new decimal(11.61),
                        NumPages = 864
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirstName = "Laura",
                        AuthorLastName = "Hillenbrand",
                        Publisher = "Random House",
                        Isbn = "978-0812974492",
                        Classification = "Non-Fiction",
                        Category = "Historical",
                        Price = new decimal(13.33),
                        NumPages = 528
                    },

                    new Book
                    {
                        Title = "The Greate Train Robbery",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Crichton",
                        Publisher = "Vintage",
                        Isbn = "978-0804171281",
                        Classification = "Fiction",
                        Category = "Historical Fiction",
                        Price = new decimal(15.95),
                        NumPages = 288
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirstName = "Cal",
                        AuthorLastName = "Newport",
                        Publisher = "Grand Central Publishing",
                        Isbn = "978-1455586691",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = new decimal(14.99),
                        NumPages = 304
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirstName = "Michael",
                        AuthorLastName = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        Isbn = "978-1455523023",
                        Classification = "Non-Fiction",
                        Category = "Self-Help",
                        Price = new decimal(21.66),
                        NumPages = 240
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirstName = "Richard",
                        AuthorLastName = "Branson"
,                        Publisher = "Portfolio",
                        Isbn = "978-1591847984",
                        Classification = "Non-Fiction",
                        Category = "Business",
                        Price = new decimal(29.16),
                        NumPages = 400
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirstName = "John",
                        AuthorLastName = "Grisham",
                        Publisher = "Bantam",
                        Isbn = "978-0553393613",
                        Classification = "Fiction",
                        Category = "Thrillers",
                        Price = new decimal(15.03),
                        NumPages = 642
                    },

                    new Book
                    {
                        Title = "The Awakening",
                        AuthorFirstName = "Kate",
                        AuthorLastName = "Chopin",
                        Publisher = "Herbert S. Stone & Co.",
                        Isbn = "978-0312062354",
                        Classification = "Fiction",
                        Category = "Classic",
                        Price = new decimal(5.99),
                        NumPages = 303
                    },

                    new Book
                    {
                        Title = "And Then There Were None",
                        AuthorFirstName = "Agatha",
                        AuthorLastName = "Christie",
                        Publisher = "Collins Crime Club",
                        Isbn = "978-0062325549",
                        Classification = "Fiction",
                        Category = "Mystery",
                        Price = new decimal(7.99),
                        NumPages = 272
                    },

                    new Book
                    {
                        Title = "The Joy Luck Club",
                        AuthorFirstName = "Amy",
                        AuthorLastName = "Tan",
                        Publisher = "G. P. Putnam's Sons",
                        Isbn = "978-0143038092",
                        Classification = "Fiction",
                        Category = "Novel",
                        Price = new decimal(11.98),
                        NumPages = 288
                    }

                );

                context.SaveChanges();
            }
        }
    }
}
