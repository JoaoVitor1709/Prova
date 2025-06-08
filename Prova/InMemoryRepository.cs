using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class InMemoryRepository<T> : IRepository<T> where T : class
    {
        protected readonly List<T> _dados = new();
        protected readonly Func<T, int> _getId;

        public InMemoryRepository(Func<T, int> getId)
        {
            _getId = getId;
        }

        public void Adicionar(T entidade)
        {
            _dados.Add(entidade);
        }

        public T ObterPorId(int id)
        {
            return _dados.FirstOrDefault(e => _getId(e) == id);
        }

        public IEnumerable<T> ObterTodos()
        {
            return _dados;
        }
    }
}
