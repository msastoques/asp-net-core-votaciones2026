using AspNetCoreVotaciones2026.Data;
using AspNetCoreVotaciones2026.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreVotaciones2026.Controllers
{
    public class SedesController : Controller
    {
        private readonly VotacionesDbContext _context;

        public SedesController(VotacionesDbContext context)
        {
            _context = context;
        }

        public IActionResult Votation(string idSede)
        {
            if (string.IsNullOrEmpty(idSede))
                return NotFound();

            // 1. Consultar estado de la votación
            var estado = _context.VotacionCerrada.FirstOrDefault();

            // 2. Validar si está cerrada
            if (estado == null || estado.Cerrado)
            {
                ViewBag.Mensaje = "La votación está CERRADA";
                return View("VotacionCerrada"); // Vista informativa
            }

            var candidatos = _context.Candidatos.ToList();

            ViewBag.IdSede = idSede;

            return View(candidatos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Votation(string idSede, IFormCollection form)
        {
            if (string.IsNullOrEmpty(idSede))
                return NotFound();

            var personeroId = form["Personero"];
            var contralorId = form["Contralor"];

            if (string.IsNullOrEmpty(personeroId) || string.IsNullOrEmpty(contralorId))
            {
                TempData["Error"] = "Debe seleccionar un candidato por cada corporación";
                return RedirectToAction(nameof(Votation), new { idSede });
            }

            // Guardar votos (dos registros)
            _context.Votos.Add(new Voto
            {
                CandidatoId = int.Parse(personeroId),
                SedeId = idSede,
                Fecha = DateTime.Now
            });

            _context.Votos.Add(new Voto
            {
                CandidatoId = int.Parse(contralorId),
                SedeId = idSede,
                Fecha = DateTime.Now
            });

            _context.SaveChanges();

            return RedirectToAction(nameof(HomeVotation), new { idSede = idSede }); // puedes crear esta vista
        }

        public IActionResult HomeVotation(string idSede)
        {
            if (string.IsNullOrEmpty(idSede))
                return NotFound();

            // 1. Consultar estado de la votación
            var estado = _context.VotacionCerrada.FirstOrDefault();

            // 2. Validar si está cerrada
            if (estado == null || estado.Cerrado)
            {
                ViewBag.Mensaje = "La votación está CERRADA";
                return View("VotacionCerrada"); // Vista informativa
            }

            // 3. Si está abierta, continuar
            ViewBag.IdSede = idSede;

            return View();
        }
        // =========================
        // GET: Sedes/Iniciar?nombre=xxx
        // =========================
        public IActionResult Iniciar(string nombre)
        {
            if (string.IsNullOrEmpty(nombre))
                return RedirectToAction("Index", "Home");

            var sede = _context.Sedes
                .FirstOrDefault(s => s.Nombre == nombre);

            if (sede == null)
            {
                TempData["Error"] = "La sede no existe";
                return RedirectToAction("Index", "Home");
            }

            var vm = new IniciarVotacionViewModel
            {
                Id = sede.Id,
                Nombre = sede.Nombre
            };

            return View(vm);
        }

        // =========================
        // POST: Sedes/Iniciar
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Iniciar(IniciarVotacionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var sede = _context.Sedes
                .FirstOrDefault(s => s.Id == model.Id);

            if (sede == null)
            {
                ModelState.AddModelError("", "La sede no existe");
                return View(model);
            }

            if (sede.Code != model.Codigo)
            {
                ModelState.AddModelError("", "Código incorrecto");
                return View(model);
            }

            return RedirectToAction(nameof(HomeVotation), new { idSede = sede.Id });
        }

       
    }
}
