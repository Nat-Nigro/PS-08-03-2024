using AlbergoNigro.Data;
using AlbergoNigro.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AlbergoNigro.Controllers
{
    [Authorize]
    public class Prenotaziones1Controller : Controller
    {
        private readonly AlbergoNigroContext _context;

        public Prenotaziones1Controller(AlbergoNigroContext context)
        {
            _context = context;
        }

        // GET: Prenotaziones1
        public async Task<IActionResult> Index()
        {
            var albergoNigroContext = _context.Prenotazione.Include(p => p.Camera).Include(p => p.Cliente).Include(p => p.Pensione);
            return View(await albergoNigroContext.ToListAsync());
        }

        // GET: Prenotaziones1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        // GET: Prenotaziones1/Create
        public IActionResult Create()
        {
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID");
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome");
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia");
            return View();
        }

        // POST: Prenotaziones1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DataPrenotazione,DataInizioSoggiorno,DataFineSoggiorno,Anno,Acconto,Prezzo,IDCliente,IDCamera,IDPensione")] Prenotazione prenotazione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prenotazione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID", prenotazione.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome", prenotazione.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia", prenotazione.IDPensione);
            return View(prenotazione);
        }

        // GET: Prenotaziones1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione.FindAsync(id);
            if (prenotazione == null)
            {
                return NotFound();
            }
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID", prenotazione.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome", prenotazione.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia", prenotazione.IDPensione);
            return View(prenotazione);
        }

        // POST: Prenotaziones1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DataPrenotazione,DataInizioSoggiorno,DataFineSoggiorno,Anno,Acconto,Prezzo,IDCliente,IDCamera,IDPensione")] Prenotazione prenotazione)
        {
            if (id != prenotazione.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prenotazione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrenotazioneExists(prenotazione.ID))
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
            ViewData["IDCamera"] = new SelectList(_context.Camere, "ID", "ID", prenotazione.IDCamera);
            ViewData["IDCliente"] = new SelectList(_context.Clienti, "Id", "Cognome", prenotazione.IDCliente);
            ViewData["IDPensione"] = new SelectList(_context.Pensione, "ID", "Tipologia", prenotazione.IDPensione);
            return View(prenotazione);
        }

        // GET: Prenotaziones1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prenotazione == null)
            {
                return NotFound();
            }

            return View(prenotazione);
        }

        // POST: Prenotaziones1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prenotazione = await _context.Prenotazione.FindAsync(id);
            if (prenotazione != null)
            {
                _context.Prenotazione.Remove(prenotazione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrenotazioneExists(int id)
        {
            return _context.Prenotazione.Any(e => e.ID == id);
        }

        // Metodo GET: Prenotaziones1/SearchByCodiceFiscale
        // Questo metodo permette di cercare le prenotazioni di un cliente utilizzando il suo codice fiscale
        [HttpGet]
        public async Task<IActionResult> SearchByCodiceFiscale(string CodiceFiscale)
        {
            // Se il codice fiscale non è fornito, restituisci un errore
            if (string.IsNullOrEmpty(CodiceFiscale))
            {
                return BadRequest("Il codice fiscale è obbligatorio");
            }

            // Cerca il cliente con il codice fiscale fornito
            var cliente = await _context.Clienti.FirstOrDefaultAsync(c => c.CodiceFiscale == CodiceFiscale);

            // Se il cliente non esiste, restituisci un errore
            if (cliente == null)
            {
                return NotFound("Cliente non trovato");
            }

            // Cerca tutte le prenotazioni del cliente
            var prenotazioni = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .Where(p => p.IDCliente == cliente.Id)
                .ToListAsync();

            // Restituisci la vista con le prenotazioni del cliente
            return View(prenotazioni);
        }

        [HttpGet]
        public async Task<IActionResult> TotalPensioneCompleta()
        {
            var pensioneCompleta = await _context.Pensione.FirstOrDefaultAsync(p => p.Tipologia == "pensione completa");

            if (pensioneCompleta == null)
            {
                TempData["Message3"] = "Nessuna pensione completa trovata";
                return RedirectToAction("Index");
            }

            var totalPrenotazioni = await _context.Prenotazione
                .Where(p => p.IDPensione == pensioneCompleta.ID)
                .CountAsync();

            return View(totalPrenotazioni);
        }


        // Metodo per il checkout di una prenotazione
        public async Task<IActionResult> Checkout(int? id)
        {
            // Se l'ID non è fornito, restituisci un errore
            if (id == null)
            {
                return NotFound();
            }

            // Cerca la prenotazione con l'ID fornito
            var prenotazione = await _context.Prenotazione
                .Include(p => p.Camera)
                .Include(p => p.Cliente)
                .Include(p => p.Pensione)
                .FirstOrDefaultAsync(m => m.ID == id);

            // Se la prenotazione non esiste, restituisci un errore
            if (prenotazione == null)
            {
                return NotFound();
            }

            // Cerca tutti i servizi associati alla prenotazione
            var servizi = await _context.Servizi
                .Where(s => s.IDPrenotazione == id)
                .ToListAsync();

            // Crea un nuovo modello di vista per il checkout
            var model = new CheckoutViewModel
            {
                Prenotazione = prenotazione,
                Servizi = servizi
            };

            // Restituisci la vista con il modello di vista per il checkout
            return View(model);
        }

    }
}
