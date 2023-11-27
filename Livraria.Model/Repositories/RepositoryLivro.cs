using Livraria.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Model.Repositories
{
    public class RepositoryLivro : RepositoryBase<Livro>
    {
        public RepositoryLivro(bool saveChanges = true) : base(saveChanges)
        {

        }
    }
}
