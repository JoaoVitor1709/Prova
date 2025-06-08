using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class CalculadoraDeDescontos
    {
        private readonly List<IDescontoStrategy> _estrategias;
        private readonly ILogger _logger;

        public CalculadoraDeDescontos(List<IDescontoStrategy> estrategias, ILogger logger)
        {
            _estrategias = estrategias;
            _logger = logger;
        }

        public decimal CalcularDescontoTotal(Pedido pedido)
        {
            decimal descontoTotal = 0;

            foreach (var item in pedido.Itens)
            {
                foreach (var estrategia in _estrategias)
                {
                    var desconto = estrategia.CalcularDesconto(item);
                    if (desconto > 0)
                    {
                        _logger.Registrar($"Desconto aplicado: {item.Produto.Nome} - {desconto:C}");
                        descontoTotal += desconto;
                    }
                }
            }

            return descontoTotal;
        }
    }
}
