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

                return View(alugadosalterados);
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
        //public async Task<IActionResult> Create(AluguelVM aluguelVM, string ListaAluguelTemporaria)
        //{
        //    var alugado = new Alugado();
        //    var listaItens = new List<ItemAlugado>();

        //    if (aluguelVM.Id > 0)
        //    {
        //       alugado.Id = aluguelVM.Id;
        //    }
        //    alugado.IdCliente = aluguelVM.IdCliente;
        //    alugado.IdLivro = aluguelVM.IdLivro;
        //    alugado.DataRetorno = aluguelVM.DataEntrega;
        //    alugado.Retornado = aluguelVM.Retornado;

        //    foreach (var item in aluguelVM.ListaAluguel)
        //    {
        //        listaItens.Add(new ItemAlugado
        //        {
        //            IdCliente = item.IdCliente,
        //            IdLivro = item.IdLivro,
        //        });
        //    }



        //    alugado.ItemAlugado = listaItens;
        //    await _ServicoAlugado.oRepositoryAlugado.IncluirAsync(alugado);
        //    CarregaViewBag();
        //    return View();







        //    var alugado = new Alugado
        //    {
        //        Id = aluguelVM.Id,
        //        IdCliente = aluguelVM.IdCliente,
        //        IdLivro = aluguelVM.IdLivro,
        //        DataRetorno = aluguelVM.DataEntrega,
        //        Retornado = aluguelVM.Retornado
        //    };

        //    // Salva o aluguel principal no banco de dados
        //    var alugadoAlterado = await _ServicoAlugado.oRepositoryAlugado.IncluirAsync(alugado);

        //    if (!string.IsNullOrEmpty(ListaAluguelTemporaria))
        //    {
        //        var settings = new JsonSerializerSettings
        //        {
        //            NullValueHandling = NullValueHandling.Ignore // Ignora valores nulos durante a desserialização
        //        };
        //        var listaItensTemporaria = JsonConvert.DeserializeObject<List<ItemAlugado>>(ListaAluguelTemporaria, settings);


        //        // Remove o rastreamento dos itens de aluguel existentes no alugadoAlterado
        //        _context.Entry(alugadoAlterado).Collection(a => a.ItemAlugado).EntityEntry.State = EntityState.Detached;

        //        // Adiciona os novos itens de aluguel
        //        foreach (var itemTemp in listaItensTemporaria)
        //        {
        //            var itemAlugado = new ItemAlugado
        //            {
        //                IdLivro = itemTemp.IdLivro,
        //                IdCliente = itemTemp.IdCliente,
        //                DataEntrega = itemTemp.DataEntrega,
        //                Retornado = itemTemp.Retornado,
        //                // Configure outras propriedades conforme necessário
        //            };

        //            // Adiciona o item de aluguel ao aluguel principal
        //            alugadoAlterado.ItemAlugado.Add(itemAlugado);
        //        }

        //        // Atualiza os dados no banco de dados
        //        await _ServicoAlugado.oRepositoryAlugado.AlterarAsync(alugadoAlterado, alugadoAlterado.ItemAlugado.ToList());
        //    }
        //    CarregaViewBag();
        //    return View(aluguelVM);
        //}
        //}
        [HttpPost]
        public async Task<IActionResult> Create(string ListaAluguelTemporaria)
        {
            if (!string.IsNullOrEmpty(ListaAluguelTemporaria))
            {
                var settings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore // Ignora valores nulos durante a desserialização
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
                        // Configure outras propriedades conforme necessário
                    };

                    // Você pode salvar cada item aqui, se preferir:
                    await _ServicoAlugado.oRepositoryAlugado.IncluirAsync(itemAlugado);
                }
            }

            // Você também pode retornar uma mensagem de sucesso, redirecionar para outra página, ou fazer outra ação desejada aqui.

            return View();
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

