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
    public class DatosPersonalesController : Controller
    {
        private readonly SistemasTutorInteligenteContext _context;

        public DatosPersonalesController(SistemasTutorInteligenteContext context)
        {
            _context = context;
        }

        // GET: DatosPersonales
        public async Task<IActionResult> Index()
        {
            var sistemasTutorInteligenteContext = _context.DatosPersonales.Include(d => d.datosCuenta);
            return View(await sistemasTutorInteligenteContext.ToListAsync());
        }

        // GET: DatosPersonales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosPersonales = await _context.DatosPersonales
                .Include(d => d.datosCuenta)
                .SingleOrDefaultAsync(m => m.IDdatos == id);
            if (datosPersonales == null)
            {
                return NotFound();
            }

            return View(datosPersonales);
        }

        // GET: DatosPersonales/Create
        public IActionResult Create()
        {
            ViewData["IDusuario"] = new SelectList(_context.DatosCuenta, "IDusuario", "IDusuario");
            return View();
        }

        // POST: DatosPersonales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDdatos,Nombre,Apaterno,Amaterno,Edad,IDusuario")] DatosPersonales datosPersonales)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datosPersonales);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IDusuario"] = new SelectList(_context.DatosCuenta, "IDusuario", "IDusuario", datosPersonales.IDusuario);
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosPersonales = await _context.DatosPersonales.SingleOrDefaultAsync(m => m.IDdatos == id);
            if (datosPersonales == null)
            {
                return NotFound();
            }
            ViewData["IDusuario"] = new SelectList(_context.DatosCuenta, "IDusuario", "IDusuario", datosPersonales.IDusuario);
            return View(datosPersonales);
        }

        // POST: DatosPersonales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDdatos,Nombre,Apaterno,Amaterno,Edad,IDusuario")] DatosPersonales datosPersonales)
        {
            if (id != datosPersonales.IDdatos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datosPersonales);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatosPersonalesExists(datosPersonales.IDdatos))
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
            ViewData["IDusuario"] = new SelectList(_context.DatosCuenta, "IDusuario", "IDusuario", datosPersonales.IDusuario);
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datosPersonales = await _context.DatosPersonales
                .Include(d => d.datosCuenta)
                .SingleOrDefaultAsync(m => m.IDdatos == id);
            if (datosPersonales == null)
            {
                return NotFound();
            }

            return View(datosPersonales);
        }

        // POST: DatosPersonales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datosPersonales = await _context.DatosPersonales.SingleOrDefaultAsync(m => m.IDdatos == id);
            _context.DatosPersonales.Remove(datosPersonales);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatosPersonalesExists(int id)
        {
            return _context.DatosPersonales.Any(e => e.IDdatos == id);
        }
    }
}
