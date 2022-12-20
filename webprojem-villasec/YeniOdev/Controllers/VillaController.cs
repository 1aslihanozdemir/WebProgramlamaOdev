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
    public class VillaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VillaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Villas

        public IActionResult Detaylar()
        {
            return View();

        }
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Villa.Include(v => v.Adres).Include(v => v.Bolge).Include(v => v.Kategori);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Villas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villa = await _context.Villa
                .Include(v => v.Adres)
                .Include(v => v.Bolge)
                .Include(v => v.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            return View(villa);
        }

        // GET: Villas/Create
        public IActionResult Create()
        {
            ViewData["AdresId"] = new SelectList(_context.Adres, "Id", "Id");
            ViewData["BolgeId"] = new SelectList(_context.Bolge, "Id", "Id");
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id");
            return View();
        }

        // POST: Villas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VillaAd,KategoriId,AdresId,BolgeId,Fiyat,Metrekare,Kapasite,Fotograf,Aciklama")] Villa villa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(villa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdresId"] = new SelectList(_context.Adres, "Id", "Id", villa.AdresId);
            ViewData["BolgeId"] = new SelectList(_context.Bolge, "Id", "Id", villa.BolgeId);
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", villa.KategoriId);
            return View(villa);
        }

        // GET: Villas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villa = await _context.Villa.FindAsync(id);
            if (villa == null)
            {
                return NotFound();
            }
            ViewData["AdresId"] = new SelectList(_context.Adres, "Id", "Id", villa.AdresId);
            ViewData["BolgeId"] = new SelectList(_context.Bolge, "Id", "Id", villa.BolgeId);
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", villa.KategoriId);
            return View(villa);
        }

        // POST: Villas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VillaAd,KategoriId,AdresId,BolgeId,Fiyat,Metrekare,Kapasite,Fotograf,Aciklama")] Villa villa)
        {
            if (id != villa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(villa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VillaExists(villa.Id))
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
            ViewData["AdresId"] = new SelectList(_context.Adres, "Id", "Id", villa.AdresId);
            ViewData["BolgeId"] = new SelectList(_context.Bolge, "Id", "Id", villa.BolgeId);
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Id", villa.KategoriId);
            return View(villa);
        }

        // GET: Villas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var villa = await _context.Villa
                .Include(v => v.Adres)
                .Include(v => v.Bolge)
                .Include(v => v.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (villa == null)
            {
                return NotFound();
            }

            return View(villa);
        }

        // POST: Villas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var villa = await _context.Villa.FindAsync(id);
            _context.Villa.Remove(villa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VillaExists(int id)
        {
            return _context.Villa.Any(e => e.Id == id);
        }
    }
}
