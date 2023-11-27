using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Livraria.Model.Models;

namespace Livraria.Model.Repositories
{
    public class RepositoryAdmin : RepositoryBase<Admin>
    {
        public RepositoryAdmin(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
