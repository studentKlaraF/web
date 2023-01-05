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
    public class NarociloController : Controller
    {
        private readonly TrgovinaContext _context;

        public NarociloController(TrgovinaContext context)
        {
            _context = context;
        }

        // GET: Narocilo
        public async Task<IActionResult> Index()
        {
              return View(await _context.Narocilo.ToListAsync());
        }

        // GET: Narocilo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Narocilo == null)
            {
                return NotFound();
            }

            var narocilo = await _context.Narocilo
                .FirstOrDefaultAsync(m => m.NarociloId == id);
            if (narocilo == null)
            {
                return NotFound();
            }

            return View(narocilo);
        }

        // GET: Narocilo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Narocilo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NarociloId,kolicina,skupnaCena")] Narocilo narocilo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(narocilo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(narocilo);
        }

        // GET: Narocilo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Narocilo == null)
            {
                return NotFound();
            }

            var narocilo = await _context.Narocilo.FindAsync(id);
            if (narocilo == null)
            {
                return NotFound();
            }
            return View(narocilo);
        }

        // POST: Narocilo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NarociloId,kolicina,skupnaCena")] Narocilo narocilo)
        {
            if (id != narocilo.NarociloId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(narocilo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NarociloExists(narocilo.NarociloId))
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
            return View(narocilo);
        }

        // GET: Narocilo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Narocilo == null)
            {
                return NotFound();
            }

            var narocilo = await _context.Narocilo
                .FirstOrDefaultAsync(m => m.NarociloId == id);
            if (narocilo == null)
            {
                return NotFound();
            }

            return View(narocilo);
        }

        // POST: Narocilo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Narocilo == null)
            {
                return Problem("Entity set 'TrgovinaContext.Narocilo'  is null.");
            }
            var narocilo = await _context.Narocilo.FindAsync(id);
            if (narocilo != null)
            {
                _context.Narocilo.Remove(narocilo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NarociloExists(int id)
        {
          return _context.Narocilo.Any(e => e.NarociloId == id);
        }
    }
}
