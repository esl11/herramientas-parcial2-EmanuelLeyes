using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using parcial2.Models;
using parcial2.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace parcial2.Controllers
{   
  // Solicita estar logueado para acceder
   [Authorize]
    public class StoreController : Controller
    {
        private readonly EnterpriseContext _context;

        public StoreController(EnterpriseContext context)
        {
            _context = context;
        }

        // GET: Store
        public async Task<IActionResult> Index()
        {
              return _context.Store != null ? 
                          View(await _context.Store.ToListAsync()) :
                          Problem("Entity set 'EnterpriseContext.Store'  is null.");
        }

        // GET: Store/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Store == null)
            {
                return NotFound();
            }

            var Store = await _context.Store
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Store == null)
            {
                return NotFound();
            }

            return View(Store);
        }

        // GET: Store/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Store/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Price,Company")] StoreVM footwearStoreInput)
        {
            if (ModelState.IsValid)
            {
                var Store = new Store {
                    Name = footwearStoreInput.Name,
                    Company = footwearStoreInput.Company,
                };
                _context.Add(Store);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(footwearStoreInput);
        }

        // GET: Store/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Store == null)
            {
                return NotFound();
            }

            var Store = await _context.Store.FindAsync(id);
            if (Store == null)
            {
                return NotFound();
            }
            return View(Store);
        }

        // POST: Store/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Company")] Store Store)
        {
            if (id != Store.Id)
            {
                return NotFound();
            }

            
            {
                try
                {
                    _context.Update(Store);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FootwearStoreExists(Store.Id))
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
            return View(Store);
        }

        // GET: Store/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Store == null)
            {
                return NotFound();
            }

            var Store = await _context.Store
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Store == null)
            {
                return NotFound();
            }

            return View(Store);
        }

        // POST: Store/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Store == null)
            {
                return Problem("Entity set 'EnterpriseContext.Store'  is null.");
            }
            var Store = await _context.Store.FindAsync(id);
            if (Store != null)
            {
                _context.Store.Remove(Store);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FootwearStoreExists(int id)
        {
          return (_context.Store?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
