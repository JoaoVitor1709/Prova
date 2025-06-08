using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class Pedido
    {
        public int Id { get; private set; }
        public Cliente Cliente { get; private set; }
        public List<ItemPedido> Itens { get; private set; } = new();
        public DateTime Data { get; private set; } = DateTime.Now;

        public decimal ValorTotal => Itens.Sum(item => item.Subtotal);

        public Pedido(int id, Cliente cliente)
        {
            if (cliente == null) throw new ArgumentNullException(nameof(cliente));

            Id = id;
            Cliente = cliente;
        }

        public void AdicionarItem(ItemPedido item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item));
            Itens.Add(item);
        }
    }
}
