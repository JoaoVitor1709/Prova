using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class ProdutoRepository : InMemoryRepository<Produto>
    {
        public ProdutoRepository(ILogger logger) : base(produto => produto.Id, logger)
        {
        }
    }
}
