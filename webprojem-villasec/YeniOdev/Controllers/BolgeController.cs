using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YeniOdev.Data;
using YeniOdev.Models;

namespace YeniOdev.Controllers
{
    public class BolgeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BolgeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bolge
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bolge.ToListAsync());
        }

        // GET: Bolge/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolge = await _context.Bolge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bolge == null)
            {
                return NotFound();
            }

            return View(bolge);
        }

        // GET: Bolge/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bolge/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BolgeAd")] Bolge bolge)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolge);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bolge);
        }

        // GET: Bolge/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolge = await _context.Bolge.FindAsync(id);
            if (bolge == null)
            {
                return NotFound();
            }
            return View(bolge);
        }

        // POST: Bolge/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BolgeAd")] Bolge bolge)
        {
            if (id != bolge.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bolge);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BolgeExists(bolge.Id))
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
            return View(bolge);
        }

        // GET: Bolge/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bolge = await _context.Bolge
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bolge == null)
            {
                return NotFound();
            }

            return View(bolge);
        }

        // POST: Bolge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bolge = await _context.Bolge.FindAsync(id);
            _context.Bolge.Remove(bolge);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolgeExists(int id)
        {
            return _context.Bolge.Any(e => e.Id == id);
        }
    }
}
