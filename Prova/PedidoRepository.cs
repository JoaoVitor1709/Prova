using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class PedidoRepository : InMemoryRepository<Pedido>
    {
        public PedidoRepository(ILogger logger) : base(pedido => pedido.Id, logger)
        {
        }
    }
}
