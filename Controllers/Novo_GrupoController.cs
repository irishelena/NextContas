using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NextConta.Models;

namespace NextConta.Controllers
{
    public class Novo_GrupoController : Controller
    {
        private readonly Context _context;

        public Novo_GrupoController(Context context)
        {
            _context = context;
        }

        // GET: Novo_Grupo
        public async Task<IActionResult> Index()
        {
            return View(await _context.Novo_Grupos.ToListAsync());
        }

        // GET: Novo_Grupo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novo_Grupo = await _context.Novo_Grupos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (novo_Grupo == null)
            {
                return NotFound();
            }

            return View(novo_Grupo);
        }

        // GET: Novo_Grupo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Novo_Grupo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Categoria,Descricao,ValorInt,QtdTelas,TelasDisponiveis,ValorPessoa")] Novo_Grupo novo_Grupo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novo_Grupo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(novo_Grupo);
        }

        // GET: Novo_Grupo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novo_Grupo = await _context.Novo_Grupos.FindAsync(id);
            if (novo_Grupo == null)
            {
                return NotFound();
            }
            return View(novo_Grupo);
        }

        // POST: Novo_Grupo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Categoria,Descricao,ValorInt,QtdTelas,TelasDisponiveis,ValorPessoa")] Novo_Grupo novo_Grupo)
        {
            if (id != novo_Grupo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novo_Grupo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Novo_GrupoExists(novo_Grupo.Id))
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
            return View(novo_Grupo);
        }

        // GET: Novo_Grupo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novo_Grupo = await _context.Novo_Grupos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (novo_Grupo == null)
            {
                return NotFound();
            }

            return View(novo_Grupo);
        }

        // POST: Novo_Grupo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var novo_Grupo = await _context.Novo_Grupos.FindAsync(id);
            _context.Novo_Grupos.Remove(novo_Grupo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Novo_GrupoExists(int id)
        {
            return _context.Novo_Grupos.Any(e => e.Id == id);
        }
    }
}
