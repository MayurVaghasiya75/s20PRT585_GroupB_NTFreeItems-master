using Microsoft.EntityFrameworkCore;
using BookStoreApp.DAL;

namespace BookStoreApp.Data
{
    public class EfBooksContext: DbContext
    {

        public EfBooksContext (DbContextOptions<EfBooksContext> options)
            : base(options) { }

        public DbSet<Book> Book { get; set; }

        public DbSet<Printer> Printer { get; set; }

        public DbSet<Scanner> Scanner { get; set; }
    }
}
