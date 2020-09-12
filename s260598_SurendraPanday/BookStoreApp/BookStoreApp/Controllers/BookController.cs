using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.DAL;
using BookStoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers
{
    public class BookController : Controller
    {
        private readonly EfBooksContext _bookContext;

        public BookController(EfBooksContext bookContext)
        {
            _bookContext = bookContext;
        }

        // Get a list of book
        public async Task<IActionResult> Book()
        {
            return View(await _bookContext.Book.ToListAsync());
        }


        // Get list of a book
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
         
            var book = await _bookContext.Book
                .FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // Get book created in list : Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name")] Book book)
        {
            if (ModelState.IsValid)
            {
                _bookContext.Add(book);
                await _bookContext.SaveChangesAsync();
                return RedirectToAction(nameof(Book));
            }
            return View(book);
        }

        // GET: Book/Edit/{id} : Specific book that has been edited

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var book = await _bookContext.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        //POST: Book/Edit/bookId
        // To stop over posting attack this method is required for anti forgery, DDOS attack

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _bookContext.Update(book);
                    await _bookContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Book));
            }
            return View(book);
        }

        // Get list after deleting a book

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _bookContext.Book
                .FirstOrDefaultAsync(d => d.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        // POST : Book/Delete

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _bookContext.Book.FindAsync(id);
            _bookContext.Book.Remove(book);
            await _bookContext.SaveChangesAsync();
            return RedirectToAction(nameof(Book));
        }

        private bool BookExists(int id)
        {
            return _bookContext.Book.Any(data => data.Id == id);
        }

    }
}
