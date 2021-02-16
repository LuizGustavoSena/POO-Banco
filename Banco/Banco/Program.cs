using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            int escolha;
            double deposito, saque, transferir;
            Conta conta = new Conta();
            Cliente cliente = new Cliente();
            Endereco endereco = new Endereco();

            // CONTA DE EXEMPLO PARA TRANSFERENCIA
            Conta contExemplo = new Conta(001, 12358, 10);
            Endereco endExemplo = new Endereco("Pirulito", 09, "Araraquara");
            Cliente papini = new Cliente("123.456.789-78", "Papini", endExemplo, contExemplo);
            
            do
            { // MENU DE OPÇÕES
                Console.WriteLine("\n1 - Informe dados da conta a ser criada\n" +
                    "2 - Depósito\n3 - Saque\n4 - Transferência\n5 - Saldo\n" +
                    "6 - Contas cadastradas\n0 - Sair");
                try
                {
                    escolha = int.Parse(Console.ReadLine());

                }
                catch (Exception) // CASO INSERIR VALOR DIFERENTE QUE NÚMERO ATRIBUI 7 E O LAÇO COMEÇA NOVAMENTE
                {
                    escolha = 7;
                }

                Console.Clear(); // LIMPA TELA

                // SE INFORMAR ALGUMA AÇÃO DO BANCO ANTES DE CADASTRAR A CONTA CAI NO IF E JÁ O DIRECIONA PARA CADASTRO
                if (cliente.Nome == "User" && escolha > 1) { 
                    Console.WriteLine("Primeiramente Informe os dados para criação de uma conta:");
                    escolha = 1;
                }

                switch (escolha)
                {
                    case 1: // INFORMA DADOS CONTA 

                        cadastroConta(conta);
                        cadastroEndereco(endereco);

                        cliente = new Cliente(conta, endereco); // ATRIBUI AO CLIENTE CONTA E ENDEREÇO

                        cadastroCliente(cliente);

                        break;

                    case 2: // DEPÓSITO

                        Console.Write("Qual o valor do depósito: ");
                        deposito = double.Parse(Console.ReadLine());
                        if (deposito > 0) // CONDIÇÃO PARA DEPOSITO
                        {
                            cliente.conta.Deposito(deposito);
                            Console.WriteLine("Depósito concluido, saldo atual: " + cliente.conta.Saldo);
                        }
                        else
                            Console.WriteLine("Depósito não concluido, saldo atual: " + cliente.conta.Saldo);
                        break;

                    case 3: // SAQUE

                        Console.Write("Qual o valor do saque: ");
                        saque = double.Parse(Console.ReadLine());
                        if ((cliente.conta.Saldo - saque) >= 0 && saque > 0)// CONDIÇÃO PARA SAQUE
                        { 
                            cliente.conta.Saque(saque);
                            Console.WriteLine("Saque concluido, saldo atual: " + cliente.conta.Saldo);
                        }
                        else
                            Console.WriteLine("Saque não concluido, saldo atual: " + cliente.conta.Saldo);
                        break;

                    case 4: // TRANSFERÊNCIA

                        Console.Write("Valor a ser transferido: ");
                        transferir = double.Parse(Console.ReadLine());
                        if ((cliente.conta.Saldo - transferir) >= 0 && transferir > 0) // CONDIÇÃO PARA A TRANSFERÊNCIA
                        {
                            cliente.conta.Saque(transferir);
                            papini.conta.Deposito(transferir);
                            Console.WriteLine("Transferência concluida, saldo atual: " + cliente.conta.Saldo);
                        }
                        else 
                            Console.WriteLine("Transferência não concluida, saldo atual: " + cliente.conta.Saldo);
                        break;

                    case 5: // SALDO

                        Console.WriteLine("Saldo: " + cliente.GetSaldo());
                        break;

                    case 6: // CONTAS CADASTRADAS

                        Console.WriteLine(cliente.ToString()); // IMPRESSÃO DAS CONTAS 
                        Console.WriteLine("------------------------------------------");
                        Console.WriteLine(papini.ToString()); //  CONTA DE EXEMPLO PARA TRANSFERÊNCIA 
                        break;
                }

            } while (escolha != 0);

            Console.ReadKey();
        }

        static void cadastroConta(Conta conta)
        {
            try
            {
                Console.Write("Informe a Agência da conta: ");
                conta.Agencia = int.Parse(Console.ReadLine());

                Console.Write("Informe o Número da conta: ");
                conta.Numero = int.Parse(Console.ReadLine());
            }
            catch (Exception) // CASO DER ERRO CHAMA A FUNÇÃO NOVAMENTE
            {
                Console.WriteLine("Digite apenas números");
                cadastroConta(conta);
            }
        }

        static void cadastroEndereco(Endereco endereco)
        {
            try
            {
                do // LAÇO PARA NÃO DEIXAR CAMPO VAZIO
                {
                    Console.Write("Informe sua rua: ");
                    endereco.Rua = Console.ReadLine();
                } while (endereco.Rua == "");

                Console.Write("Informe seu número: ");
                endereco.Numero = int.Parse(Console.ReadLine());

                do // LAÇO PARA NÃO DEIXAR CAMPO VAZIO
                {
                    Console.Write("Informe sua cidade: ");
                    endereco.Cidade = Console.ReadLine();
                } while (endereco.Cidade == "");
            }
            catch (Exception) // CASO DER ERRO CHAMA A FUNÇÃO NOVAMENTE
            {
                Console.WriteLine("Preencha o formulário com o que se pede");
                cadastroEndereco(endereco);
            }
        }

        static void cadastroCliente(Cliente cliente)
        {
            try
            {
                do // LAÇO PARA NÃO DEIXAR CAMPO VAZIO
                {
                    Console.Write("Informe seu CPF: ");
                    cliente.Cpf = Console.ReadLine();
                } while (cliente.Cpf == "");

                do // LAÇO PARA NÃO DEIXAR CAMPO VAZIO
                {
                    Console.Write("Informe seu Nome: ");
                    cliente.Nome = Console.ReadLine();
                } while (cliente.Nome == "");

            }
            catch (Exception) // CASO DER ERRO CHAMA A FUNÇÃO NOVAMENTE
            {
                Console.WriteLine("Preencha o formulário com o que se pede");
                cadastroCliente(cliente);
            }
        }
    }
}
