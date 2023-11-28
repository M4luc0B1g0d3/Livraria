using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Model.Models;
using Livraria.Model.Service;
using Microsoft.AspNetCore.Authorization;

namespace Livraria.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LivrosController : Controller
    {
        private ServiceLivro _Servicolivro;

        public LivrosController()
        {
            _Servicolivro = new ServiceLivro();
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var listalivros = await _Servicolivro.oRepositoryLivro.SelecionarTodosAsync();

            return View(listalivros);
        }
        public async Task<IActionResult> Details(int id)
        {
            var livro = await _Servicolivro.oRepositoryLivro.SelecionarPKAsync(id);
            return View(livro);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var livro = await _Servicolivro.oRepositoryLivro.SelecionarPKAsync(id);
            return View(livro);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Livro livro)
        {
            if (ModelState.IsValid)
            {
                var livrosalterados = await _Servicolivro.oRepositoryLivro.AlterarAsync(livro);

                return RedirectToAction("Index");
            }
            return View(livro);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Livro livro)
        {
            if (ModelState.IsValid)
            {
                var livroalterado = await _Servicolivro.oRepositoryLivro.IncluirAsync(livro);

                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
            var livro = await _Servicolivro.oRepositoryLivro.SelecionarPKAsync(id);
            return View(livro);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Livro livro)
        {
            await _Servicolivro.oRepositoryLivro.ExcluirAsync(livro);
            return RedirectToAction("Index");
        }
    }
}
