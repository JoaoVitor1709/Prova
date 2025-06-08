using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class ProdutoRepository : InMemoryRepository<Produto>
    {
        public ProdutoRepository() : base(produto => produto.Id) { }
    }
}
