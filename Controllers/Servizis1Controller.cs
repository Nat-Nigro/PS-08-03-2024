using AlbergoNigro.Data;
using AlbergoNigro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AlbergoNigro.Controllers
{
    [Authorize]
    public class Servizis1Controller : Controller
    {
        private readonly AlbergoNigroContext _context;

        public Servizis1Controller(AlbergoNigroContext context)
        {
            _context = context;
        }

        // GET: Servizis1
        public async Task<IActionResult> Index()
        {
            var albergoNigroContext = _context.Servizi.Include(s => s.Prenotazione);
            return View(await albergoNigroContext.ToListAsync());
        }

        // GET: Servizis1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi
                .Include(s => s.Prenotazione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (servizi == null)
            {
                return NotFound();
            }

            return View(servizi);
        }

        // GET: Servizis1/Create
        public IActionResult Create()
        {
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazione, "ID", "ID");
            return View();
        }

        // POST: Servizis1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Descrizione,Prezzo,DataRichiestaServizio,IDPrenotazione")] Servizi servizi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(servizi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazione, "ID", "ID", servizi.IDPrenotazione);
            return View(servizi);
        }

        // GET: Servizis1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi.FindAsync(id);
            if (servizi == null)
            {
                return NotFound();
            }
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazione, "ID", "ID", servizi.IDPrenotazione);
            return View(servizi);
        }

        // POST: Servizis1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Descrizione,Prezzo,DataRichiestaServizio,IDPrenotazione")] Servizi servizi)
        {
            if (id != servizi.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(servizi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiziExists(servizi.ID))
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
            ViewData["IDPrenotazione"] = new SelectList(_context.Prenotazione, "ID", "ID", servizi.IDPrenotazione);
            return View(servizi);
        }

        // GET: Servizis1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var servizi = await _context.Servizi
                .Include(s => s.Prenotazione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (servizi == null)
            {
                return NotFound();
            }

            return View(servizi);
        }

        // POST: Servizis1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var servizi = await _context.Servizi.FindAsync(id);
            if (servizi != null)
            {
                _context.Servizi.Remove(servizi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiziExists(int id)
        {
            return _context.Servizi.Any(e => e.ID == id);
        }
    }
}
