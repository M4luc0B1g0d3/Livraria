using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Model.Models;
using Livraria.Model.Service;
using Microsoft.AspNetCore.Authorization;

namespace Livraria.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ClienteController : Controller
    {
        private ServiceCliente _ServicoCliente;

        public ClienteController()
        {
            _ServicoCliente = new ServiceCliente();
        }
        public async Task<IActionResult> Index()
        {
            var listaClientes = await _ServicoCliente.oRepositoryCliente.SelecionarTodosAsync();

            return View(listaClientes);
        }
        public async Task<IActionResult> Details(int id)
        {
            var cliente = await _ServicoCliente.oRepositoryCliente.SelecionarPKAsync(id);
            return View(cliente);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var cliente = await _ServicoCliente.oRepositoryCliente.SelecionarPKAsync(id);
            return View(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clientealterado = await _ServicoCliente.oRepositoryCliente.AlterarAsync(cliente);

                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                var clientealterado = await _ServicoCliente.oRepositoryCliente.IncluirAsync(cliente);

                return RedirectToAction("Index");
            }
            return View(cliente);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _ServicoCliente.oRepositoryCliente.SelecionarPKAsync(id);
            return View(cliente);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Cliente cliente)
        {
            await _ServicoCliente.oRepositoryCliente.ExcluirAsync(cliente);
            return RedirectToAction("Index");
        }

    }
}
