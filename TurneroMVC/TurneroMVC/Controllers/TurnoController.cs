using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurneroMVC.Context;
using TurneroMVC.Models;

namespace TurneroMVC.Controllers
{
    public class TurnoController : Controller
    {
        private readonly TurneroDatabaseContext _context;

        public TurnoController(TurneroDatabaseContext context)
        {
            _context = context;
        }

        // GET: Turno
        public async Task<IActionResult> Index()
        {
            int cuentaId = Int32.Parse(s: HttpContext.Session.GetString("CuentaId"));
            string rolLogged = HttpContext.Session.GetString("Rol");

            //si es ADMINISTRADOR el rol logueado
            if (rolLogged.Equals(Rol.ADMINISTRADOR.ToString()))
            {
                //muestro todos los turnos
                var turnosReservados = await _context.Turnos
                    .Include(t => t.Cuenta)
                    .OrderBy(t => t.DiaHora)
                    .ToListAsync();
                return View(turnosReservados);
            }
            //es USUARIO el rol logueado
            else
            {
                //muestro solo los turnos con el IdCuenta de Session de ese usuario
                var turnosReservados = await _context.Turnos
                    .Where(s => s.CuentaId == cuentaId)
                    .OrderBy(t => t.DiaHora)
                    .ToListAsync();
                return View(turnosReservados);
            }
        }
               

        // GET: Turno/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Cuenta)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

    

        // GET: Turno/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Turno/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,NroComprobante,DiaHora,Actividad")] Turno turno)
        public async Task<IActionResult> Create([Bind("Id,DiaHora,Actividad,CuentaId")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                //Recuperar valor de la variable de sesión para setearlo al turno
                string idCuenta = HttpContext.Session.GetString("CuentaId");
                turno.CuentaId = int.Parse(idCuenta);

                if (!ExisteTurnoPrevio(turno))
                {
                    _context.Add(turno);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewData["ErrorMessage"] = "Usted puede sacar un solo turno por dia";
                    return View(turno);
                }
            }
            return View(turno);
        }

        // GET: Turno/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            return View(turno);
        }

        // POST: Turno/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,NroComprobante,DiaHora,Actividad")] Turno turno)
        public async Task<IActionResult> Edit(int id, [Bind("Id,DiaHora,Actividad,CuentaId")] Turno turno)
        {
            if (id != turno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (!ExisteTurnoPrevio(turno)) {
                        _context.Update(turno);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    else
                    {
                        ViewData["ErrorMessage"] = "Usted puede sacar un solo turno por dia";
                        return View(turno);
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.Id))
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
            return View(turno);
        }

        // GET: Turno/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.Id == id);
        }

        private bool ExisteTurnoPrevio(Turno turno)
        {
            bool result = true;

            result = _context.Turnos
                .Any(t => t.CuentaId == turno.CuentaId &&
                            //t.Actividad == turno.Actividad &&
                            t.DiaHora.DayOfYear == turno.DiaHora.DayOfYear);

            return result;
        }
    }
}
