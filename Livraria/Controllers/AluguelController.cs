using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Livraria.Model.Models;
using Livraria.Model.Service;
using Livraria.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using static Livraria.ViewModel.AluguelVM;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;

namespace Livraria.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AluguelController : Controller
    {
        private ServiceAlugado _ServicoAlugado;
        public LivrariaContext _context;

        public AluguelController()
        {
            _ServicoAlugado = new ServiceAlugado();
            _context = new LivrariaContext();
        }
        [HttpGet]
        public IActionResult Index()
        {
            var lista = AluguelVM.ListarTodasAlugueis();
            return View(lista);
        }
        public void CarregaViewBag()
        {
            ViewData["IdClientes"] = new SelectList(_ServicoAlugado.oRepositoryCliente.SelecionarTodos(), "Id", "Nome");
            ViewData["IdLivros"] = new SelectList(_ServicoAlugado.oRepositoryLivro.SelecionarTodos(), "Id", "Nome");
            ViewBag.listaProdutos = _ServicoAlugado.oRepositoryLivro.SelecionarTodos();
        }
        [HttpGet]

        public IActionResult Details(int id)
        {
            var detalhes = AluguelVM.SelecionarAlugueis(id);

            return View(detalhes);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var alugado = await _ServicoAlugado.oRepositoryAlugado.SelecionarPKAsync(id);
            CarregaViewBag();
            return View(alugado);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Alugado alugado)
        {
            if (ModelState.IsValid)
            {
                var alugadosalterados = await _ServicoAlugado.oRepositoryAlugado.AlterarAsync(alugado);

                return RedirectToAction("Index");
            }
            return View(alugado);
        }
        [HttpGet]

        public IActionResult Create(int id = 0)
        {
            CarregaViewBag();
            if (id > 0)
            {
                return View(AluguelVM.SelecionarAlugueis(id));
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string ListaAluguelTemporaria)
        {
            if (!string.IsNullOrEmpty(ListaAluguelTemporaria))
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                };
                var listaItensTemporaria = JsonConvert.DeserializeObject<List<ItemAlugado>>(ListaAluguelTemporaria, settings);

                foreach (var itemTemp in listaItensTemporaria)
                {
                    var itemAlugado = new Alugado
                    {
                        IdLivro = itemTemp.IdLivro,
                        IdCliente = itemTemp.IdCliente,
                        DataRetorno = itemTemp.DataEntrega,
                        Retornado = itemTemp.Retornado,
                        Id = itemTemp.AlugadoId,
                        
                    };
                    await _ServicoAlugado.oRepositoryAlugado.IncluirAsync(itemAlugado);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var detalhes = AluguelVM.SelecionarAlugueis(id);

            return View(detalhes);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Alugado alugado)
        {
            await _ServicoAlugado.oRepositoryAlugado.ExcluirAsync(alugado);
            return RedirectToAction("Index");
        }
    }
}

