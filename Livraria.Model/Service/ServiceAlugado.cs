using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Model.Repositories;

namespace Livraria.Model.Service
{
    public class ServiceAlugado
    {
        public RepositoryAlugado oRepositoryAlugado { get; set; }
        public RepositoryCliente oRepositoryCliente { get; set; }
        public RepositoryLivro oRepositoryLivro { get; set; }
        public RepositoryItemAlugado oRepositoryItemAlugado { get; set; }


        public ServiceAlugado()
        {
            oRepositoryAlugado = new RepositoryAlugado();
            oRepositoryCliente = new RepositoryCliente();
            oRepositoryLivro = new RepositoryLivro();
            oRepositoryItemAlugado = new RepositoryItemAlugado();
        }
    }
    
}
