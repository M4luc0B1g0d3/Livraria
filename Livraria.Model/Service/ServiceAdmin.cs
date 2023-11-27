using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Model.Repositories;

namespace Livraria.Model.Service
{
    public class ServiceAdmin
    {
        public RepositoryAdmin oRepositoryAdmin { get; set; }

        public ServiceAdmin()
        {
            oRepositoryAdmin = new RepositoryAdmin();
        }
    }
}
