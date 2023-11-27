using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Model.Repositories;

namespace Livraria.Model.Service
{
    public class ServiceLivro
    {
        public RepositoryLivro oRepositoryLivro { get; set; }

        public ServiceLivro()
        {
            oRepositoryLivro = new RepositoryLivro();
        }
    }
}
