using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public interface IDescontoStrategy
    {
        decimal CalcularDesconto(ItemPedido item);
    }
}
