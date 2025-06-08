using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class ClienteRepository : InMemoryRepository<Cliente>
    {
        public ClienteRepository(ILogger logger) : base(cliente => cliente.Id, logger)
        {
        }
    }
}
