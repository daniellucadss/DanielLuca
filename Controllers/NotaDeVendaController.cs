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
    public class NotaDeVendaController : Controller
    {
        private readonly MyDbContext _context;

        public NotaDeVendaController(MyDbContext context)
        {
            _context = context;
        }

        // GET: NotaDeVenda
        public async Task<IActionResult> Index()
        {
            var myDbContext = _context.NotasDeVendas.Include(n => n.Cliente).Include(n => n.TipoDePagamento).Include(n => n.Transportadora).Include(n => n.Vendedor);
            return View(await myDbContext.ToListAsync());
        }

        // GET: NotaDeVenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVendas
                .Include(n => n.Cliente)
                .Include(n => n.TipoDePagamento)
                .Include(n => n.Transportadora)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome");
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TiposDePagamento, "Id", "Tipo");
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "Id", "Nome");
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Nome");
            return View();
        }

        // POST: NotaDeVenda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Data,ClienteId,VendedorId,TransportadoraId,Status,TipoDePagamentoId")] NotaDeVenda notaDeVenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(notaDeVenda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", notaDeVenda.ClienteId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TiposDePagamento, "Id", "Tipo", notaDeVenda.TipoDePagamentoId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "Id", "Nome", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Nome", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVendas.FindAsync(id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", notaDeVenda.ClienteId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TiposDePagamento, "Id", "Tipo", notaDeVenda.TipoDePagamentoId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "Id", "Nome", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Nome", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // POST: NotaDeVenda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Data,ClienteId,VendedorId,TransportadoraId,Status,TipoDePagamentoId")] NotaDeVenda notaDeVenda)
        {
            if (id != notaDeVenda.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(notaDeVenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NotaDeVendaExists(notaDeVenda.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Nome", notaDeVenda.ClienteId);
            ViewData["TipoDePagamentoId"] = new SelectList(_context.TiposDePagamento, "Id", "Tipo", notaDeVenda.TipoDePagamentoId);
            ViewData["TransportadoraId"] = new SelectList(_context.Transportadoras, "Id", "Nome", notaDeVenda.TransportadoraId);
            ViewData["VendedorId"] = new SelectList(_context.Vendedores, "Id", "Nome", notaDeVenda.VendedorId);
            return View(notaDeVenda);
        }

        // GET: NotaDeVenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVendas
                .Include(n => n.Cliente)
                .Include(n => n.TipoDePagamento)
                .Include(n => n.Transportadora)
                .Include(n => n.Vendedor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (notaDeVenda == null)
            {
                return NotFound();
            }

            return View(notaDeVenda);
        }

        // POST: NotaDeVenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var notaDeVenda = await _context.NotasDeVendas.FindAsync(id);
            _context.NotasDeVendas.Remove(notaDeVenda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NotaDeVendaExists(int id)
        {
            return _context.NotasDeVendas.Any(e => e.Id == id);
        }

          // GET: NotasDeVendas/CancelarNota/5
        public async Task<IActionResult> CancelarNota(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVendas.FindAsync(id);

            if (notaDeVenda == null)
            {
                return NotFound();
            }

            notaDeVenda.Status = StatusNotaDeVenda.Cancelado;
            _context.Update(notaDeVenda);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: NotasDeVendas/DevolverNota/5
        public async Task<IActionResult> DevolverNota(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var notaDeVenda = await _context.NotasDeVendas.FindAsync(id);

            if (notaDeVenda == null)
            {
                return NotFound();
            }

            notaDeVenda.Status = StatusNotaDeVenda.Devolvido;
            _context.Update(notaDeVenda);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
