using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Model.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<T> IncluirAsync(T obj);
        Task<T> AlterarAsync(T obj);
        Task<T> SelecionarPKAsync(params object[] variavel);
        Task<List<T>> SelecionarTodosAsync();
        Task ExcluirAsync(T obj);
        Task ExcluirAsync(params object[] variavel);

        List<T> SelecionarTodos();
    }
}
