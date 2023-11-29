using Livraria.Model.Models;
using Livraria.Models;
using System.ComponentModel;

namespace Livraria.ViewModel
{
    public class AluguelVM
    {
        [DisplayName("Código")]
        public int Id { get; set; }
        [DisplayName("Código Cliente")]
        public int IdCliente { get; set; }

        [DisplayName("Nome do Cliente")]
        public string ClienteName { get; set; }

        [DisplayName("Código Livro")]
        public int IdLivro { get; set; }

        [DisplayName("Quantidade de Livros")]
        public int QtdLivros { get; set;}

        [DisplayName("Nome do Livro")]
        public string LivroName { get; set; }

        [DisplayName("Data de Retorno")]
        public DateTime DataEntrega { get; set; }

        public bool Retornado { get; set; }

        public List<Livro> ListaLivros { get; set; }

        public List<Cliente> ListaClientes { get; set; }

        public List<ItemAlugado> ListaAluguel { get; set; }

        public AluguelVM()
        {
            ListaAluguel = new List<ItemAlugado>();
        }

        public class ItemAlugadoVM
        {
            public int IdLivro { get; set; }
            public string? LivroName { get; set; }
            public int IdCliente { get; set; }
            public string? ClienteName { get; set; }
            public DateTime DataEntrega { get; set; }
            public bool Retornado { get; set; }

        }
        public static AluguelVM SelecionarAlugueis(int id)
        {
            var db = new LivrariaContext();
            var Aluguel = db.Alugado.Find(id);


            return new AluguelVM()
            {
                Id = Aluguel.Id,
                IdCliente = Aluguel.IdCliente,
                ClienteName = db.Cliente.Find(Aluguel.IdCliente).Nome,
                IdLivro = Aluguel.IdLivro,
                QtdLivros = db.Livro.Count(),
                LivroName = db.Livro.Find(Aluguel.IdLivro).Nome,
                DataEntrega = Aluguel.DataRetorno,
                Retornado = Aluguel.Retornado,
            };
        }
        public static List<AluguelVM> ListarTodasAlugueis()
        {
            var db = new LivrariaContext();
            var listaRetorno = new List<AluguelVM>();
            var listaAluguels = db.Alugado.ToList();

            foreach (var v in listaAluguels)
            {

                var Aluguel = new AluguelVM();
                Aluguel.Id = v.Id;
                Aluguel.IdCliente = Aluguel.IdCliente;
                Aluguel.ClienteName = db.Cliente.FirstOrDefault(x => x.Id == v.IdCliente).Nome;
                Aluguel.IdLivro = Aluguel.IdLivro;
                Aluguel.QtdLivros = db.Livro.Count();
                Aluguel.LivroName = db.Livro.FirstOrDefault(x => x.Id == v.IdLivro).Nome;
                Aluguel.DataEntrega = v.DataRetorno;
                Aluguel.Retornado = v.Retornado;
                listaRetorno.Add(Aluguel);
            }
            return listaRetorno;
        }
    }
}
