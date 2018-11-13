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
    public class preguntas_test_inteligenciaController : Controller
    {
        private readonly SistemasTutorInteligenteContext _context;

        public preguntas_test_inteligenciaController(SistemasTutorInteligenteContext context)
        {
            _context = context;
        }

        // GET: preguntas_test_inteligencia
        public async Task<IActionResult> Index()
        {
            return View(await _context.preguntas_test_inteligencia.ToListAsync());
        }

        // GET: preguntas_test_inteligencia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntas_test_inteligencia = await _context.preguntas_test_inteligencia
                .SingleOrDefaultAsync(m => m.IDpreguntas_test == id);
            if (preguntas_test_inteligencia == null)
            {
                return NotFound();
            }

            return View(preguntas_test_inteligencia);
        }

        // GET: preguntas_test_inteligencia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: preguntas_test_inteligencia/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDpreguntas_test,num_pregunta,pregunta")] preguntas_test_inteligencia preguntas_test_inteligencia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(preguntas_test_inteligencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(preguntas_test_inteligencia);
        }

        // GET: preguntas_test_inteligencia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntas_test_inteligencia = await _context.preguntas_test_inteligencia.SingleOrDefaultAsync(m => m.IDpreguntas_test == id);
            if (preguntas_test_inteligencia == null)
            {
                return NotFound();
            }
            return View(preguntas_test_inteligencia);
        }

        // POST: preguntas_test_inteligencia/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDpreguntas_test,num_pregunta,pregunta")] preguntas_test_inteligencia preguntas_test_inteligencia)
        {
            if (id != preguntas_test_inteligencia.IDpreguntas_test)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(preguntas_test_inteligencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!preguntas_test_inteligenciaExists(preguntas_test_inteligencia.IDpreguntas_test))
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
            return View(preguntas_test_inteligencia);
        }

        // GET: preguntas_test_inteligencia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var preguntas_test_inteligencia = await _context.preguntas_test_inteligencia
                .SingleOrDefaultAsync(m => m.IDpreguntas_test == id);
            if (preguntas_test_inteligencia == null)
            {
                return NotFound();
            }

            return View(preguntas_test_inteligencia);
        }

        // POST: preguntas_test_inteligencia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var preguntas_test_inteligencia = await _context.preguntas_test_inteligencia.SingleOrDefaultAsync(m => m.IDpreguntas_test == id);
            _context.preguntas_test_inteligencia.Remove(preguntas_test_inteligencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool preguntas_test_inteligenciaExists(int id)
        {
            return _context.preguntas_test_inteligencia.Any(e => e.IDpreguntas_test == id);
        }
    }
}
