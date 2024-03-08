using AlbergoNigro.Data;
using AlbergoNigro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlbergoNigro.Controllers
{
    [Authorize]
    public class PensionesController : Controller
    {
        private readonly AlbergoNigroContext _context;

        public PensionesController(AlbergoNigroContext context)
        {
            _context = context;
        }

        // GET: Pensiones
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pensione.ToListAsync());
        }

        // GET: Pensiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pensione = await _context.Pensione
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pensione == null)
            {
                return NotFound();
            }

            return View(pensione);
        }

        // GET: Pensiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Pensiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Tipologia,Prezzo")] Pensione pensione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pensione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pensione);
        }

        // GET: Pensiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pensione = await _context.Pensione.FindAsync(id);
            if (pensione == null)
            {
                return NotFound();
            }
            return View(pensione);
        }

        // POST: Pensiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Tipologia,Prezzo")] Pensione pensione)
        {
            if (id != pensione.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pensione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PensioneExists(pensione.ID))
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
            return View(pensione);
        }

        // GET: Pensiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pensione = await _context.Pensione
                .FirstOrDefaultAsync(m => m.ID == id);
            if (pensione == null)
            {
                return NotFound();
            }

            return View(pensione);
        }

        // POST: Pensiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pensione = await _context.Pensione.FindAsync(id);
            if (pensione != null)
            {
                _context.Pensione.Remove(pensione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PensioneExists(int id)
        {
            return _context.Pensione.Any(e => e.ID == id);
        }
    }
}
