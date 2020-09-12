
using System.Linq;
using System.Threading.Tasks;
using BookStoreApp.DAL;
using BookStoreApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApp.Controllers
{
    public class PrinterController : Controller
    {
        private readonly EfBooksContext _printerContext;

        public PrinterController(EfBooksContext printerContext)
        {
            _printerContext = printerContext;
        }

        // Get a list of printers

        public async Task<IActionResult> Printer()
        {
            return View(await _printerContext.Printer.ToListAsync());
        }

        // Get detail of a printer
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printer = await _printerContext.Printer
                .FirstOrDefaultAsync(b => b.Id == id);
            if (printer == null)
            {
                return NotFound();
            }
            return View(printer);
        }

        // Get printer created in list : printer/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: printer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id, Name, Brand, Model")] Printer printer)
        {
            if (ModelState.IsValid)
            {
                _printerContext.Add(printer);
                await _printerContext.SaveChangesAsync();
                return RedirectToAction(nameof(Printer));
            }
            return View(printer);
        }

        // GET: printer/Edit/{id} : Specific printer that has been edited

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var printer = await _printerContext.Printer.FindAsync(id);
            if (printer == null)
            {
                return NotFound();
            }
            return View(printer);
        }

        //POST: Book/Edit/printerId
        // To stop over posting attack this method is required for anti forgery, DDOS attack

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, Brand, Model")] Printer printer)
        {
            if (id != printer.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _printerContext.Update(printer);
                    await _printerContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrinterExists(printer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Printer));
            }
            return View(printer);
        }

        // Get list after deleting a book

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var printer = await _printerContext.Printer
                .FirstOrDefaultAsync(d => d.Id == id);
            if (printer == null)
            {
                return NotFound();
            }
            return View(printer);
        }
        // POST : printer/Delete

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var printer = await _printerContext.Printer.FindAsync(id);
            _printerContext.Printer.Remove(printer);
            await _printerContext.SaveChangesAsync();
            return RedirectToAction(nameof(Printer));
        }

        private bool PrinterExists(int id)
        {
            return _printerContext.Printer.Any(data => data.Id == id);
        }

    }
}
