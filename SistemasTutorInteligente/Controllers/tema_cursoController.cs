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
    public class tema_cursoController : Controller
    {
        private readonly SistemasTutorInteligenteContext _context;

        public tema_cursoController(SistemasTutorInteligenteContext context)
        {
            _context = context;
        }

        // GET: tema_curso
        public async Task<IActionResult> Index()
        {
            return View(await _context.tema_curso.ToListAsync());
        }

        // GET: tema_curso/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema_curso = await _context.tema_curso
                .SingleOrDefaultAsync(m => m.IDtemas == id);
            if (tema_curso == null)
            {
                return NotFound();
            }

            return View(tema_curso);
        }

        // GET: tema_curso/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tema_curso/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDtemas,nombre_tema")] tema_curso tema_curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tema_curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tema_curso);
        }

        // GET: tema_curso/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema_curso = await _context.tema_curso.SingleOrDefaultAsync(m => m.IDtemas == id);
            if (tema_curso == null)
            {
                return NotFound();
            }
            return View(tema_curso);
        }

        // POST: tema_curso/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDtemas,nombre_tema")] tema_curso tema_curso)
        {
            if (id != tema_curso.IDtemas)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tema_curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tema_cursoExists(tema_curso.IDtemas))
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
            return View(tema_curso);
        }

        // GET: tema_curso/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tema_curso = await _context.tema_curso
                .SingleOrDefaultAsync(m => m.IDtemas == id);
            if (tema_curso == null)
            {
                return NotFound();
            }

            return View(tema_curso);
        }

        // POST: tema_curso/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tema_curso = await _context.tema_curso.SingleOrDefaultAsync(m => m.IDtemas == id);
            _context.tema_curso.Remove(tema_curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tema_cursoExists(int id)
        {
            return _context.tema_curso.Any(e => e.IDtemas == id);
        }
    }
}
