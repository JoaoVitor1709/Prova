using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public interface IRepository<T>
    {
        void Adicionar(T entidade);
        T ObterPorId(int id);
        IEnumerable<T> ObterTodos();
    }
}
