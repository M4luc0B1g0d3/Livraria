using Livraria.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Model.Service
{
    public class ServiceItemAlugado
    {
        public RepositoryItemAlugado oRepositoryItemAlugado { get; set; }

        public ServiceItemAlugado()
        {
            oRepositoryItemAlugado = new RepositoryItemAlugado();
        }
    }
}
