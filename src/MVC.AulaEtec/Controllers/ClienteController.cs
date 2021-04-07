using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.AulaEtec.Data;
using MVC.AulaEtec.Models;
using MVC.AulaEtec.ViewModel;

namespace MVC.AulaEtec.Controllers
{
    public class ClienteController : Controller
    {
        private readonly MVCAulaEtecContext _context;
        private readonly IMapper _mapper;

        public ClienteController(MVCAulaEtecContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: Cliente
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClienteModel.ToListAsync());
        }

        // GET: Cliente/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.ClienteModel
                                            .Include(a => a.Enderecos)
                                            .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // GET: Cliente/Create
        public IActionResult Create()
        {
            return View();
        }

        // GET: Cliente/CreateFull
        public IActionResult CreateFull()
        {
            return View();
        }


        // POST: Cliente/CreateFull
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateFull( ClienteFullViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                var cliente = _mapper.Map<ClienteModel>(clienteViewModel);
                
                /* - todo o código abaixo foi substituído pela linha acima feita pelo automapper
                 * 
                var cliente = new ClienteModel();
                
                cliente.NomeFantasia = clienteModel.NomeFantasia;
                cliente.RazaoSocial = clienteModel.RazaoSocial;
                cliente.Apelido = clienteModel.Apelido;
                cliente.Cnpj = clienteModel.Cnpj;
                cliente.IE = clienteModel.IE;
                cliente.Observacoes = clienteModel.Observacoes;
                */

                _context.Add(cliente);
                await _context.SaveChangesAsync();

                var endereco = _mapper.Map<ClienteEnderecoModel>(clienteViewModel);
                /* - todo o código abaixo foi substituído pela linha acima feita pelo automapper
                 * 
                var endereco = new ClienteEnderecoModel();
                // a chave clienteId só é obtida depois de incluir no contexto (auto increment)
                endereco.Rua = clienteViewModel.Rua;
                endereco.Bairro = clienteViewModel.Bairro;
                endereco.Cidade = clienteViewModel.Cidade;
                endereco.Estado = clienteViewModel.Estado;
                endereco.Cep = clienteViewModel.Cep;
                */
                endereco.ClienteId = cliente.ClienteId;

                _context.Add(endereco);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }
            return View(clienteViewModel);
        }



        // POST: Cliente/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,NomeFantasia,RazaoSocial,Apelido,Cnpj,IE,Email,Observacoes,LogoAddress,CodigoExterno")] ClienteModel clienteModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteModel);
        }

        // GET: Cliente/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.ClienteModel.FindAsync(id);
            if (clienteModel == null)
            {
                return NotFound();
            }
            return View(clienteModel);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,NomeFantasia,RazaoSocial,Apelido,Cnpj,IE,Email,Observacoes,LogoAddress,CodigoExterno")] ClienteModel clienteModel)
        {
            if (id != clienteModel.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteModelExists(clienteModel.ClienteId))
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
            return View(clienteModel);
        }

        // GET: Cliente/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteModel = await _context.ClienteModel
                .FirstOrDefaultAsync(m => m.ClienteId == id);
            if (clienteModel == null)
            {
                return NotFound();
            }

            return View(clienteModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteModel = await _context.ClienteModel.FindAsync(id);
            _context.ClienteModel.Remove(clienteModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteModelExists(int id)
        {
            return _context.ClienteModel.Any(e => e.ClienteId == id);
        }
    }
}
