using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class PedidoFactory : IPedidoFactory
    {
        private readonly ILogger _logger;

        public PedidoFactory(ILogger logger)
        {
            _logger = logger;
        }

        public Pedido CriarPedido(int idPedido, Cliente cliente, List<(Produto produto, int quantidade)> itens)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));
            if (itens == null || !itens.Any()) throw new ArgumentException("Lista de itens inválida.");

            var pedido = new Pedido(idPedido, cliente);

            foreach (var (produto, quantidade) in itens)
            {
                var item = new ItemPedido(produto, quantidade);
                pedido.AdicionarItem(item);
            }

            _logger.Registrar($"Pedido #{idPedido} criado para o cliente {cliente.Nome}");

            return pedido;
        }
    }
}
