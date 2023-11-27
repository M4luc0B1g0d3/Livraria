using Livraria.Model.Models;
using Livraria.Models;

namespace Livraria.ViewModel
{
    public class AluguelVM
    {
        public int Id { get; set; }

        public int IdCliente { get; set; }

        public string ClienteName { get; set; }

        public string LivroName { get; set; }

        public int IdLivro { get; set; }

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

            //var listaAluguel = new List<AluguelLivro>();
            //listaAluguel = AluguelLivro.ListaAluguelLivro(id);

            return new AluguelVM()
            {
                Id = Aluguel.Id,
                IdCliente = Aluguel.IdCliente,
                ClienteName = db.Cliente.Find(Aluguel.IdCliente).Nome,
                IdLivro = Aluguel.IdLivro,
                LivroName = db.Livro.Find(Aluguel.IdLivro).Nome,
                DataEntrega = Aluguel.DataRetorno,
                //ListaAluguel = listaAluguel,
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
                //var listaAluguel = new List<AluguelLivro>();
                //listaAluguel = AluguelLivro.ListaAluguelLivro(v.Id);

                var Aluguel = new AluguelVM();
                Aluguel.Id = v.Id;
                Aluguel.IdCliente = v.IdCliente;
                Aluguel.ClienteName = db.Cliente.FirstOrDefault(x => x.Id == v.IdCliente).Nome;
                Aluguel.IdLivro = v.IdLivro;
                Aluguel.LivroName = db.Livro.FirstOrDefault(x => x.Id == v.IdLivro).Nome;
                Aluguel.DataEntrega = v.DataRetorno;
                Aluguel.Retornado = v.Retornado;
                //Aluguel.ListaAluguel = listaAluguel;
                listaRetorno.Add(Aluguel);
            }
            return listaRetorno;
        }
    }
}
