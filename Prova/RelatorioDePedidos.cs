using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class RelatorioDePedidos
    {
        private readonly IRepository<Pedido> _pedidoRepository;
        private readonly CalculadoraDeDescontos _calculadoraDeDescontos;
        private readonly ILogger _logger;

        public RelatorioDePedidos(IRepository<Pedido> pedidoRepository, CalculadoraDeDescontos calculadoraDeDescontos, ILogger logger)
        {
            _pedidoRepository = pedidoRepository;
            _calculadoraDeDescontos = calculadoraDeDescontos;
            _logger = logger;
        }

        public void Gerar()
        {
            _logger.Registrar("Geração de relatório iniciada.");

            var pedidos = _pedidoRepository.ObterTodos();

            foreach (var pedido in pedidos)
            {
                _logger.Registrar($"Relatório: Pedido #{pedido.Id} do cliente {pedido.Cliente.Nome}.");
                Console.WriteLine("==================================");
                Console.WriteLine($"Pedido #{pedido.Id}");
                Console.WriteLine($"Cliente: {pedido.Cliente.Nome} ({pedido.Cliente.Email})");
                Console.WriteLine($"Data: {pedido.Data}");
                Console.WriteLine();

                Console.WriteLine("Itens:");
                foreach (var item in pedido.Itens)
                {
                    Console.WriteLine($"- {item.Produto.Nome} ({item.Quantidade}x) - {item.Subtotal:C}");
                }

                var total = pedido.ValorTotal;
                var desconto = _calculadoraDeDescontos.CalcularDescontoTotal(pedido);
                var totalComDesconto = total - desconto;

                Console.WriteLine();
                Console.WriteLine($"Valor Total: {total:C}");
                Console.WriteLine($"Desconto: {desconto:C}");
                Console.WriteLine($"Total com Desconto: {totalComDesconto:C}");
                Console.WriteLine("==================================\n");
            }

            _logger.Registrar("Geração de relatório finalizada.");
        }
    }
}
