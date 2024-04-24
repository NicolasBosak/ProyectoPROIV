using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto_Resenas_CQS.Data;
using Proyecto_Resenas_CQS.Models;

namespace Proyecto_Resenas_CQS.Areas.Cliente.Controllers
{
    [Area("Cliente")]
    public class ResenasController : Controller
    {
        private readonly Proyecto_Resenas_CQSContext _context;

        public ResenasController(Proyecto_Resenas_CQSContext context)
        {
            _context = context;
        }

        // GET: Cliente/Resenas
        public async Task<IActionResult> Index()
        {
            var proyecto_Resenas_CQSContext = _context.Resena.Include(r => r.Juego);
            return View(await proyecto_Resenas_CQSContext.ToListAsync());
        }

        // GET: Cliente/Resenas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resena = await _context.Resena
                .Include(r => r.Juego)
                .FirstOrDefaultAsync(m => m.ResenaId == id);
            if (resena == null)
            {
                return NotFound();
            }

            return View(resena);
        }

        // GET: Cliente/Resenas/Create
        public IActionResult Create()
        {
            ViewData["JuegoId"] = new SelectList(_context.Set<Juego>(), "JuegoId", "Categoria");
            return View();
        }

        // POST: Cliente/Resenas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ResenaId,JuegoId,UsuarioId,Puntuacion,Comentario")] Resena resena)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resena);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JuegoId"] = new SelectList(_context.Set<Juego>(), "JuegoId", "Categoria", resena.JuegoId);
            return View(resena);
        }

        // GET: Cliente/Resenas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resena = await _context.Resena.FindAsync(id);
            if (resena == null)
            {
                return NotFound();
            }
            ViewData["JuegoId"] = new SelectList(_context.Set<Juego>(), "JuegoId", "Categoria", resena.JuegoId);
            return View(resena);
        }

        // POST: Cliente/Resenas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ResenaId,JuegoId,UsuarioId,Puntuacion,Comentario")] Resena resena)
        {
            if (id != resena.ResenaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resena);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResenaExists(resena.ResenaId))
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
            ViewData["JuegoId"] = new SelectList(_context.Set<Juego>(), "JuegoId", "Categoria", resena.JuegoId);
            return View(resena);
        }

        // GET: Cliente/Resenas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resena = await _context.Resena
                .Include(r => r.Juego)
                .FirstOrDefaultAsync(m => m.ResenaId == id);
            if (resena == null)
            {
                return NotFound();
            }

            return View(resena);
        }

        // POST: Cliente/Resenas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resena = await _context.Resena.FindAsync(id);
            if (resena != null)
            {
                _context.Resena.Remove(resena);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResenaExists(int id)
        {
            return _context.Resena.Any(e => e.ResenaId == id);
        }
    }
}
