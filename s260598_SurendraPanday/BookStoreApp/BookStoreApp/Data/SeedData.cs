using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using BookStoreApp.Data;
using BookStoreApp.DAL;
using System.IO.Pipelines;

namespace BookStoreApp.DATA
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new EfBooksContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<EfBooksContext>>()))
            {
                // Look for any movies.
                if (context.Book.Any())
                {
                    return;   // DB has been seeded
                }

                context.Book.AddRange(
                    new Book
                    {
                        Name = "Lord of the Ring",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Price = 7.99

                    },

                    new Book
                    {
                        Name = "William Shakespeare book",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Price = 8.99
                    },

                    new Book
                    {
                        Name = "Sir Isaac's Boat",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Price = 9.99
                    },

                    new Book
                    {
                        Name = "Rio De Generio",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Price = 3.99
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
