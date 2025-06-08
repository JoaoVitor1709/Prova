using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class ClienteRepository : InMemoryRepository<Cliente>
    {
        public ClienteRepository() : base(cliente => cliente.Id) { }
    }
}
