using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class Cliente
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }

        public Endereco endereco;
        public Conta conta;

        // CONSTRUTORES
        public Cliente()
        {
            Cpf = "0";
            Nome = "User";
        }
        public Cliente(Conta conta, Endereco endereco)
        {
            this.conta = conta;
            this.endereco = endereco;
        }
        public Cliente(string cpf, string nome, Endereco endereco, Conta conta)
        {
            Cpf = cpf;
            Nome = nome;
            this.endereco = endereco;
            this.conta = conta;
        }

        // IMPRESSAO
        public override string ToString()
        {
            return ("CLIENTE\nCPF: " + Cpf + " Nome: " + Nome + 
                "\n\nCONTA\n" + conta.ToString() + 
                "\n\nENDEREÇO\n" + endereco.ToString());
        }
    }
}
