using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NTFreeItemsPRT585GroupB2020.DATA;
using NTFreeItemsPRT585GroupB2020.Model;

namespace NTFreeItemsPRT585GroupB2020.Controllers
{
    public class CustomerFeedbackController : Controller
    {
        private readonly FreeItemsDataContext _context;

        public CustomerFeedbackController(FreeItemsDataContext context)
        {
            _context = context;
        }

        // GET: CustomerFeedback
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerFeedback.ToListAsync());
        }

        // GET: CustomerFeedback/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerFeedback = await _context.CustomerFeedback
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (customerFeedback == null)
            {
                return NotFound();
            }

            return View(customerFeedback);
        }

        // GET: CustomerFeedback/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CustomerFeedback/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeedbackId,Userid,Feedback,CreatedTs,UserType,UserName")] CustomerFeedback customerFeedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customerFeedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customerFeedback);
        }

        // GET: CustomerFeedback/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerFeedback = await _context.CustomerFeedback.FindAsync(id);
            if (customerFeedback == null)
            {
                return NotFound();
            }
            return View(customerFeedback);
        }

        // POST: CustomerFeedback/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeedbackId,Userid,Feedback,CreatedTs,UserType,UserName")] CustomerFeedback customerFeedback)
        {
            if (id != customerFeedback.FeedbackId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerFeedbackExists(customerFeedback.FeedbackId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(customerFeedback);
        }

        // GET: CustomerFeedback/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerFeedback = await _context.CustomerFeedback
                .FirstOrDefaultAsync(m => m.FeedbackId == id);
            if (customerFeedback == null)
            {
                return NotFound();
            }

            return View(customerFeedback);
        }

        // POST: CustomerFeedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customerFeedback = await _context.CustomerFeedback.FindAsync(id);
            _context.CustomerFeedback.Remove(customerFeedback);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerFeedbackExists(int id)
        {
            return _context.CustomerFeedback.Any(e => e.FeedbackId == id);
        }
    }
}
