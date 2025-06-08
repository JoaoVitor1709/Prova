using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public interface IPedidoFactory
    {
        Pedido CriarPedido(int idPedido, Cliente cliente, List<(Produto produto, int quantidade)> itens);
    }
}
