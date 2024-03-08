using AlbergoNigro.Data;
using AlbergoNigro.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace AlbergoNigro.Controllers
{
    public class LogInsController : Controller
    {
        private readonly AlbergoNigroContext _context;

        public LogInsController(AlbergoNigroContext context)
        {
            _context = context;
        }

        // GET: LogIns
        public async Task<IActionResult> Index()
        {
            return View(await _context.LogIn.ToListAsync());
        }

        // GET: LogIns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logIn = await _context.LogIn
                .FirstOrDefaultAsync(m => m.ID == id);
            if (logIn == null)
            {
                return NotFound();
            }

            return View(logIn);
        }

        // GET: LogIns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LogIns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Username,Password")] LogIn logIn)
        {
            if (ModelState.IsValid)
            {
                _context.Add(logIn);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(logIn);
        }



        // GET: LogIns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var logIn = await _context.LogIn
                .FirstOrDefaultAsync(m => m.ID == id);
            if (logIn == null)
            {
                return NotFound();
            }

            return View(logIn);
        }

        // POST: LogIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var logIn = await _context.LogIn.FindAsync(id);
            if (logIn != null)
            {
                _context.LogIn.Remove(logIn);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LogInExists(int id)
        {
            return _context.LogIn.Any(e => e.ID == id);
        }

        // Metodo per visualizzare la pagina di login
        public IActionResult Login()
        {
            return View();
        }

        // Metodo POST per gestire il processo di login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LogIn login)
        {
            // Verifica se il modello è valido
            if (ModelState.IsValid)
            {
                // Cerca l'utente nel database
                var user = await _context.LogIn
                    .FirstOrDefaultAsync(m => m.Username == login.Username && m.Password == login.Password);
                // Se l'utente non esiste, ritorna un errore
                if (user == null)
                {
                    TempData["Error"] = "Username o password errati";
                    return RedirectToAction("Login");
                }

                // Crea una lista di claims per l'utente
                var claims = new List<Claim>
                                        {
                                            new Claim(ClaimTypes.Name, user.Username)
                                        };

                // Crea un'identità per l'utente
                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                // Imposta le proprietà di autenticazione
                var authProperties = new AuthenticationProperties
                {
                    ExpiresUtc = DateTimeOffset.UtcNow.AddDays(7),
                    IsPersistent = true
                };

                // Effettua il login dell'utente
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                // Reindirizza l'utente alla pagina principale
                return RedirectToAction("Index", "Home");
            }
            // Se il modello non è valido, ritorna la vista di login
            return View(login);
        }

        // Metodo per gestire il processo di logout
        public async Task<IActionResult> Logout()
        {
            // Effettua il logout dell'utente
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            // Reindirizza l'utente alla pagina di login
            return RedirectToAction("Login");
        }
    }
}
