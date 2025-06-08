using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prova
{
    public class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Cpf { get; private set; }

        public Cliente(int id, string nome, string email, string cpf)
        {
            if (string.IsNullOrWhiteSpace(nome)) throw new ArgumentException("Nome inválido.");
            if (!email.Contains("@")) throw new ArgumentException("Email inválido.");
            if (cpf.Length != 11) throw new ArgumentException("CPF inválido.");

            Id = id;
            Nome = nome;
            Email = email;
            Cpf = cpf;
        }
    }
}
