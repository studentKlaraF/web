using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeminarskaNaloga.Data;
using SeminarskaNaloga.Models;

namespace SeminarskaNaloga.Controllers
{
    public class LastnikController : Controller
    {
        private readonly TrgovinaContext _context;

        public LastnikController(TrgovinaContext context)
        {
            _context = context;
        }

        // GET: Lastnik
        public async Task<IActionResult> Index()
        {
              return View(await _context.Lastnik.ToListAsync());
        }

        // GET: Lastnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Lastnik == null)
            {
                return NotFound();
            }

            var lastnik = await _context.Lastnik
                .FirstOrDefaultAsync(m => m.LastnikId == id);
            if (lastnik == null)
            {
                return NotFound();
            }

            return View(lastnik);
        }

        // GET: Lastnik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lastnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastnikId")] Lastnik lastnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lastnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lastnik);
        }

        // GET: Lastnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Lastnik == null)
            {
                return NotFound();
            }

            var lastnik = await _context.Lastnik.FindAsync(id);
            if (lastnik == null)
            {
                return NotFound();
            }
            return View(lastnik);
        }

        // POST: Lastnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LastnikId")] Lastnik lastnik)
        {
            if (id != lastnik.LastnikId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lastnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LastnikExists(lastnik.LastnikId))
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
            return View(lastnik);
        }

        // GET: Lastnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Lastnik == null)
            {
                return NotFound();
            }

            var lastnik = await _context.Lastnik
                .FirstOrDefaultAsync(m => m.LastnikId == id);
            if (lastnik == null)
            {
                return NotFound();
            }

            return View(lastnik);
        }

        // POST: Lastnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Lastnik == null)
            {
                return Problem("Entity set 'TrgovinaContext.Lastnik'  is null.");
            }
            var lastnik = await _context.Lastnik.FindAsync(id);
            if (lastnik != null)
            {
                _context.Lastnik.Remove(lastnik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LastnikExists(int id)
        {
          return _context.Lastnik.Any(e => e.LastnikId == id);
        }
    }
}
