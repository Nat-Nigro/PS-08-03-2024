using AlbergoNigro.Data;
using AlbergoNigro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlbergoNigro.Controllers
{
    [Authorize]
    public class ClientiController : Controller
    {
        private readonly AlbergoNigroContext _context;

        public ClientiController(AlbergoNigroContext context)
        {
            _context = context;
        }

        // GET: Clienti
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clienti.ToListAsync());
        }

        // GET: Clienti/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienti = await _context.Clienti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienti == null)
            {
                return NotFound();
            }

            return View(clienti);
        }

        // GET: Clienti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clienti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Cognome,CodiceFiscale,Citta,Provincia,Email,Telefono,Cellulare")] Clienti clienti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienti);
        }

        // GET: Clienti/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienti = await _context.Clienti.FindAsync(id);
            if (clienti == null)
            {
                return NotFound();
            }
            return View(clienti);
        }

        // POST: Clienti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Cognome,CodiceFiscale,Citta,Provincia,Email,Telefono,Cellulare")] Clienti clienti)
        {
            if (id != clienti.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClientiExists(clienti.Id))
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
            return View(clienti);
        }

        // GET: Clienti/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienti = await _context.Clienti
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienti == null)
            {
                return NotFound();
            }

            return View(clienti);
        }

        // POST: Clienti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienti = await _context.Clienti.FindAsync(id);
            if (clienti != null)
            {
                _context.Clienti.Remove(clienti);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClientiExists(int id)
        {
            return _context.Clienti.Any(e => e.Id == id);
        }
    }
}
