using Livraria.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Model.Repositories
{
    public class RepositoryItemAlugado : RepositoryBase<ItemAlugado>
    {
        public RepositoryItemAlugado(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
