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

        public CalculadoraDeDescontos(List<IDescontoStrategy> estrategias)
        {
            _estrategias = estrategias;
        }

        public decimal CalcularDescontoTotal(Pedido pedido)
        {
            decimal descontoTotal = 0;

            foreach (var item in pedido.Itens)
            {
                foreach (var estrategia in _estrategias)
                {
                    descontoTotal += estrategia.CalcularDesconto(item);
                }
            }

            return descontoTotal;
        }
    }
}
