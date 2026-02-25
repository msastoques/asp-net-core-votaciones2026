using AspNetCoreVotaciones2026.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreVotaciones2026.Models;

namespace AspNetCoreVotaciones2026.Controllers
{
    public class VotacionCerradasController : Controller
    {
        private readonly VotacionesDbContext _context;

        public VotacionCerradasController(VotacionesDbContext context)
        {
            _context = context;
        }




        // GET: VotacionCerradasController/Edit/5
        public async Task<IActionResult> Edit(int id = 1)
        {
            var estado = await _context.VotacionCerrada.FindAsync(id);

            if (estado == null)
            {
                estado = new VotacionCerrada
                {
                    Id = 1,
                    Cerrado = false
                };

                _context.Add(estado);
                await _context.SaveChangesAsync();
            }

            return View(estado);
        }

        // POST: VotacionCerradasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {
            if (id != 1)
                return NotFound();

            var estado = await _context.VotacionCerrada.FindAsync(id);

            if (estado == null)
                return NotFound();

            // Alternar manualmente (más seguro que confiar en el form)
            estado.Cerrado = !estado.Cerrado;

            _context.Update(estado);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Edit), new { id = 1 });
        }

        // GET: VotacionCerradasController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VotacionCerradasController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
