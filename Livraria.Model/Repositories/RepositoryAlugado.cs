using Livraria.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Model.Repositories
{
    public class RepositoryAlugado : RepositoryBase<Alugado>
    {
        public RepositoryAlugado(bool saveChanges = true) : base(saveChanges)
        {

        }

        public async Task AlterarAsync(Alugado alugado, List<ItemAlugado> items)
        {
            _context.Entry(alugado).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            _context.Entry(alugado).State = EntityState.Detached;

            var itensExistentes = _context.ItemAlugado.Where(item => item.Id == alugado.Id).ToList();

            if (itensExistentes.Any())
            {
                _context.ItemAlugado.RemoveRange(itensExistentes);
                await _context.SaveChangesAsync();
            }

            if (items.Any())
            {
                foreach (var item in items)
                {
                    item.Id = alugado.Id;
                    _context.ItemAlugado.Add(item);
                }

                await _context.SaveChangesAsync();
            }
        }
    }
}
