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
    public class Nova_contaController : Controller
    {
        private readonly Context _context;

        public Nova_contaController(Context context)
        {
            _context = context;
        }

        // GET: Nova_conta
        public async Task<IActionResult> Index()
        {
            return View(await _context.Nova_Contas.ToListAsync());
        }

        // GET: Nova_conta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nova_conta = await _context.Nova_Contas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nova_conta == null)
            {
                return NotFound();
            }

            return View(nova_conta);
        }

        // GET: Nova_conta/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nova_conta/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,DataNascimento,Celular,Email,Senha")] Nova_conta nova_conta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nova_conta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nova_conta);
        }

        // GET: Nova_conta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nova_conta = await _context.Nova_Contas.FindAsync(id);
            if (nova_conta == null)
            {
                return NotFound();
            }
            return View(nova_conta);
        }

        // POST: Nova_conta/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,DataNascimento,Celular,Email,Senha")] Nova_conta nova_conta)
        {
            if (id != nova_conta.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nova_conta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Nova_contaExists(nova_conta.Id))
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
            return View(nova_conta);
        }

        // GET: Nova_conta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nova_conta = await _context.Nova_Contas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nova_conta == null)
            {
                return NotFound();
            }

            return View(nova_conta);
        }

        // POST: Nova_conta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nova_conta = await _context.Nova_Contas.FindAsync(id);
            _context.Nova_Contas.Remove(nova_conta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Nova_contaExists(int id)
        {
            return _context.Nova_Contas.Any(e => e.Id == id);
        }
    }
}
