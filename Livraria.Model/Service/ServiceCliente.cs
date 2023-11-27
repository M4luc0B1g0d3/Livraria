using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Model.Repositories;

namespace Livraria.Model.Service
{
    public class ServiceCliente
    {
        public RepositoryCliente oRepositoryCliente { get; set; }

        public ServiceCliente()
        {
            oRepositoryCliente = new RepositoryCliente();
        }
    }
}
