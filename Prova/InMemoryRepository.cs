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
        private readonly ILogger _logger;

        public InMemoryRepository(Func<T, int> getId, ILogger logger)
        {
            _getId = getId;
            _logger = logger;
        }

        public void Adicionar(T entidade)
        {
            _dados.Add(entidade);
            _logger.Registrar($"[{typeof(T).Name}] adicionado com ID = {_getId(entidade)}");
        }

        public T ObterPorId(int id)
        {
            var entidade = _dados.FirstOrDefault(e => _getId(e) == id);
            _logger.Registrar($"[{typeof(T).Name}] buscado por ID = {id} -> {(entidade != null ? "encontrado" : "não encontrado")}");
            return entidade;
        }

        public IEnumerable<T> ObterTodos()
        {
            _logger.Registrar($"[{typeof(T).Name}] todos os registros foram solicitados.");
            return _dados;
        }
    }
}
