using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemasTutorInteligente.Models;

namespace SistemasTutorInteligente.Controllers
{
    public class DatosCuentasController : Controller
    {
        private readonly SistemasTutorInteligenteContext _context;

        public DatosCuentasController(SistemasTutorInteligenteContext context)
        {
            _context = context;
        }

        // GET: DatosCuentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.DatosCuenta.ToListAsync());
        }

        // GET: DatosCuentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosCuenta = await _context.DatosCuenta
                .SingleOrDefaultAsync(m => m.IDusuario == id);
            if (datosCuenta == null)
            {
                return NotFound();
            }

            return View(datosCuenta);
        }

        // GET: DatosCuentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DatosCuentas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDusuario,Usuario,Password")] DatosCuenta datosCuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datosCuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datosCuenta);
        }

        // GET: DatosCuentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosCuenta = await _context.DatosCuenta.SingleOrDefaultAsync(m => m.IDusuario == id);
            if (datosCuenta == null)
            {
                return NotFound();
            }
            return View(datosCuenta);
        }

        // POST: DatosCuentas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDusuario,Usuario,Password")] DatosCuenta datosCuenta)
        {
            if (id != datosCuenta.IDusuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosCuenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosCuentaExists(datosCuenta.IDusuario))
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
            return View(datosCuenta);
        }

        // GET: DatosCuentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosCuenta = await _context.DatosCuenta
                .SingleOrDefaultAsync(m => m.IDusuario == id);
            if (datosCuenta == null)
            {
                return NotFound();
            }

            return View(datosCuenta);
        }

        // POST: DatosCuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosCuenta = await _context.DatosCuenta.SingleOrDefaultAsync(m => m.IDusuario == id);
            _context.DatosCuenta.Remove(datosCuenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosCuentaExists(int id)
        {
            return _context.DatosCuenta.Any(e => e.IDusuario == id);
        }
    }
}
