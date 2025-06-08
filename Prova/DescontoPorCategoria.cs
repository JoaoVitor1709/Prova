using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class DescontoPorCategoria : IDescontoStrategy
    {
        private readonly string _categoriaAlvo;
        private readonly decimal _percentual;

        public DescontoPorCategoria(string categoriaAlvo, decimal percentual)
        {
            _categoriaAlvo = categoriaAlvo;
            _percentual = percentual;
        }

        public decimal CalcularDesconto(ItemPedido item)
        {
            if (item.Produto.Categoria == _categoriaAlvo)
                return item.Subtotal * _percentual;

            return 0;
        }
    }
}
