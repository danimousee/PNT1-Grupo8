﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurneroMVC.Context;
using TurneroMVC.Models;

namespace TurneroMVC.Controllers
{
    public class CuentaController : Controller
    {
        private readonly TurneroDatabaseContext _context;

        public CuentaController(TurneroDatabaseContext context)
        {
            _context = context;
        }

        // GET: Cuenta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cuentas.ToListAsync());
            
        }

        // GET: Cuenta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return View(cuenta);
        }

        // GET: Cuenta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cuenta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Contrasenia,CodVerif,NombreCompleto,Edad,Dni")] Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                while (EmailExiste(cuenta) || DniExiste(cuenta))
                {
                    ViewData["ErrorMessage"] = "Email o Dni ya se encuentran registrados. Reintente por favor.";
                    return View("Create");
                }
                 _context.Add(cuenta);
                 await _context.SaveChangesAsync();
                 return View("Views/Home/Index.cshtml");
                
            }
            return View("Index");
        }

        // GET: Cuenta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuentas.FindAsync(id);
            if (cuenta == null)
            {
                return NotFound();
            }
            return View(cuenta);
        }

        // POST: Cuenta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Contrasenia,CodVerif,NombreCompleto,Edad,Dni")] Cuenta cuenta)
        {
            if (id != cuenta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CuentaExists(cuenta.Id))
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
            return View(cuenta);
        }

        // GET: Cuenta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cuenta = await _context.Cuentas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cuenta == null)
            {
                return NotFound();
            }

            return View(cuenta);
        }

        // POST: Cuenta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cuenta = await _context.Cuentas.FindAsync(id);
            _context.Cuentas.Remove(cuenta);
            await _context.SaveChangesAsync();

            if (cuenta.Id == id)
            {
                return View("Views/Cuenta/Create.cshtml");
            }
            else
            {
                return RedirectToAction(nameof(Index));
            }
        }

        private bool CuentaExists(int id)
        {
            return _context.Cuentas.Any(e => e.Id == id);
        }

        private bool EmailExiste(Cuenta c) 
        {
            return _context.Cuentas.Any(e => e.Email == c.Email);
        }
        private bool DniExiste(Cuenta c)
        {
            return _context.Cuentas.Any(e => e.Dni == c.Dni);
        }
    }
}
