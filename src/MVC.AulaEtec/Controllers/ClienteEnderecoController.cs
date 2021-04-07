using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC.AulaEtec.Data;
using MVC.AulaEtec.Models;

namespace MVC.AulaEtec.Controllers
{
    public class ClienteEnderecoController : Controller
    {
        private readonly MVCAulaEtecContext _context;

        public ClienteEnderecoController(MVCAulaEtecContext context)
        {
            _context = context;
        }

        // GET: ClienteEndereco
        public async Task<IActionResult> Index()
        {
            var mVCAulaEtecContext = _context.ClienteEnderecoModel.Include(c => c.Cliente);
            return View(await mVCAulaEtecContext.ToListAsync());
        }

        // GET: ClienteEndereco/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEnderecoModel = await _context.ClienteEnderecoModel
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.ClienteEnderecoId == id);
            if (clienteEnderecoModel == null)
            {
                return NotFound();
            }

            return View(clienteEnderecoModel);
        }

        // GET: ClienteEndereco/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "NomeFantasia");
            return View();
        }

        // POST: ClienteEndereco/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteEnderecoId,ClienteId,Rua,Numero,Bairro,Cidade,Estado,Cep,Referencia,Ativo,Padrao")] ClienteEnderecoModel clienteEnderecoModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteEnderecoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "NomeFantasia", clienteEnderecoModel.ClienteId);
            return View(clienteEnderecoModel);
        }

        // GET: ClienteEndereco/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEnderecoModel = await _context.ClienteEnderecoModel.FindAsync(id);
            if (clienteEnderecoModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "NomeFantasia", clienteEnderecoModel.ClienteId);
            return View(clienteEnderecoModel);
        }

        // POST: ClienteEndereco/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteEnderecoId,ClienteId,Rua,Numero,Bairro,Cidade,Estado,Cep,Referencia,Ativo,Padrao")] ClienteEnderecoModel clienteEnderecoModel)
        {
            if (id != clienteEnderecoModel.ClienteEnderecoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteEnderecoModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteEnderecoModelExists(clienteEnderecoModel.ClienteEnderecoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction( nameof(Index), "Cliente");
            }
            ViewData["ClienteId"] = new SelectList(_context.ClienteModel, "ClienteId", "NomeFantasia", clienteEnderecoModel.ClienteId);
            return View(clienteEnderecoModel);
        }

        // GET: ClienteEndereco/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteEnderecoModel = await _context.ClienteEnderecoModel
                .Include(c => c.Cliente)
                .FirstOrDefaultAsync(m => m.ClienteEnderecoId == id);
            if (clienteEnderecoModel == null)
            {
                return NotFound();
            }

            return View(clienteEnderecoModel);
        }

        // POST: ClienteEndereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteEnderecoModel = await _context.ClienteEnderecoModel.FindAsync(id);
            _context.ClienteEnderecoModel.Remove(clienteEnderecoModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteEnderecoModelExists(int id)
        {
            return _context.ClienteEnderecoModel.Any(e => e.ClienteEnderecoId == id);
        }
    }
}
