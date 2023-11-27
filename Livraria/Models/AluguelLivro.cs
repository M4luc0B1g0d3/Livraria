using Livraria.Model.Models;

namespace Livraria.Models
{
    public class AluguelLivro
    {
        public int idalu { get; set; }
        public int? IdLivro { get; set; }
        public int? IdCliente { get; set; }
        public string? NomeLivro { get; set; }
        public string? Cliente { get; set;}

        public AluguelLivro()
        {

        }
        public static List<AluguelLivro> ListaAluguelLivro(int idaluguel)
        {
            var db = new LivrariaContext();
            var listaRetorno = new List<AluguelLivro>();
            var listaItens = db.ItemAlugado.Where(x => x.Id == idaluguel).ToList();
            foreach (var item in listaItens)
            {
                listaRetorno.Add(new AluguelLivro
                {
                    idalu = idaluguel,
                    IdLivro = item.IdLivro,
                    NomeLivro = db.Livro.Find(item.IdLivro)!.Nome,
                    IdCliente = item.IdCliente,
                    Cliente = db.Cliente.Find(item.IdCliente)!.Nome,

                });


            }
            return listaRetorno;


        }
    }
}
