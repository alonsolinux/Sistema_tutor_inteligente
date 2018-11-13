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
    public class cursoesController : Controller
    {
        private readonly SistemasTutorInteligenteContext _context;

        public cursoesController(SistemasTutorInteligenteContext context)
        {
            _context = context;
        }

        // GET: cursoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.curso.ToListAsync());
        }

        // GET: cursoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.curso
                .SingleOrDefaultAsync(m => m.IDcurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: cursoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cursoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDcurso,nombre_curso,nivel")] curso curso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(curso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(curso);
        }

        // GET: cursoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.curso.SingleOrDefaultAsync(m => m.IDcurso == id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: cursoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDcurso,nombre_curso,nivel")] curso curso)
        {
            if (id != curso.IDcurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cursoExists(curso.IDcurso))
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
            return View(curso);
        }

        // GET: cursoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.curso
                .SingleOrDefaultAsync(m => m.IDcurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var curso = await _context.curso.SingleOrDefaultAsync(m => m.IDcurso == id);
            _context.curso.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cursoExists(int id)
        {
            return _context.curso.Any(e => e.IDcurso == id);
        }
    }
}
