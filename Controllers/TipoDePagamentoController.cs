#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DanielLuca.Models;

namespace DanielLuca.Controllers
{
    public class TipoDePagamentoController : Controller
    {
        private readonly MyDbContext _context;

        public TipoDePagamentoController(MyDbContext context)
        {
            _context = context;
        }

        // GET: TipoDePagamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.TiposDePagamento.ToListAsync());
        }

        // GET: TipoDePagamento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePagamento = await _context.TiposDePagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDePagamento == null)
            {
                return NotFound();
            }

            return View(tipoDePagamento);
        }

        // GET: TipoDePagamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoDePagamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeDoCobrado,InformacoesAdicionais,Tipo")] TipoDePagamento tipoDePagamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoDePagamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoDePagamento);
        }

        // GET: TipoDePagamento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePagamento = await _context.TiposDePagamento.FindAsync(id);
            if (tipoDePagamento == null)
            {
                return NotFound();
            }
            return View(tipoDePagamento);
        }

        // POST: TipoDePagamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeDoCobrado,InformacoesAdicionais,Tipo")] TipoDePagamento tipoDePagamento)
        {
            if (id != tipoDePagamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoDePagamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoDePagamentoExists(tipoDePagamento.Id))
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
            return View(tipoDePagamento);
        }

        // GET: TipoDePagamento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoDePagamento = await _context.TiposDePagamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoDePagamento == null)
            {
                return NotFound();
            }

            return View(tipoDePagamento);
        }

        // POST: TipoDePagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoDePagamento = await _context.TiposDePagamento.FindAsync(id);
            _context.TiposDePagamento.Remove(tipoDePagamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoDePagamentoExists(int id)
        {
            return _context.TiposDePagamento.Any(e => e.Id == id);
        }
    }
}
