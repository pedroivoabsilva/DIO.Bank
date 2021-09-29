using System;
using System.Collections.Generic;

namespace DIO.Bank
{
    public class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                Console.Clear();
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Trasferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    default:
                        Console.WriteLine("Você digitou uma opção inexistente!");
                        break;
                }
                Console.ReadLine();
                Console.Clear();

                opcaoUsuario = ObterOpcaoUsuario();
            }

        }

        private static void Depositar()
        {
            Console.Write("Digite o valor que deseja depositar: ");
            double valor = double.Parse(Console.ReadLine());
            Console.WriteLine("Depositar:");
            int index = EncontraConta();
            listaContas[index].Depositar(valor);
        }

        private static int EncontraConta() {
            Console.Write("Digite o numero da agencia: ");
            int agencia = int.Parse(Console.ReadLine());

            Console.Write("Digite o numero da conta: ");
            int numeroConta = int.Parse(Console.ReadLine());

            int index = listaContas.FindIndex(x => x.NumeroConta == numeroConta && x.Agencia == agencia);
            if(index == -1)
            {
                throw new ModelException("Conta não encontrada!");
            }
            return index;
        }


        private static void Sacar()
        {
            try
            {
                int index = EncontraConta();

                Console.Write("Digite o valor que deseja sacar: ");
                double valor = double.Parse(Console.ReadLine());

                listaContas[index].Sacar(valor);
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
            
        }

        private static void Trasferir()
        {
            try
            {
                Console.Write("Digite o valor á ser transferido: ");
                Console.WriteLine();
                double valor = double.Parse(Console.ReadLine());
                Console.WriteLine("Digite os dados da sua conta");
                int indexContaOrigem = EncontraConta();

                Console.WriteLine("Digite a conta para onde deseja trasferir");
                Console.WriteLine();
                int index = EncontraConta();
                Conta contaDestino = listaContas[index];


                listaContas[indexContaOrigem].Transferir(valor: valor, contaDestino: contaDestino);
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
            
        }

        private static void InserirConta()
        {
            try
            {
                Console.WriteLine("Inserir nova conta");
                Console.Write("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");
                int entradaTipoConta = int.Parse(Console.ReadLine());
                if(entradaTipoConta != null)
                {
                    throw new ModelException("Tipo de conta inexistente");
                }

                Console.Write("Digite o numero da agencia: ");
                int agencia = int.Parse(Console.ReadLine());

                Console.Write("Digite o numero da conta: ");
                int numeroConta = int.Parse(Console.ReadLine());

                Console.Write("Digite o nome do Cliente: ");
                string nome = Console.ReadLine();

                Console.Write("Digite o crédito: ");
                double credito = double.Parse(Console.ReadLine());

                Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, agencia: agencia,
                    numeroConta: numeroConta, nome: nome, credito: credito);
                listaContas.Add(novaConta);
            }
            catch (Exception e)
            {

                Console.WriteLine("Erro: " + e.Message);
            }
           
        }

        private static void ListarContas()
        {
            Console.WriteLine("Lista de contas:");
            Console.WriteLine();
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada!");
            }
            else
            {

                foreach (var conta in listaContas)
                {
                    Console.WriteLine(conta);
                }
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Bank a seu dispor!!!!");

            Console.WriteLine("1 - Listar contas");
            Console.WriteLine("2 - Inserir nova conta");
            Console.WriteLine("3 - Transferir");
            Console.WriteLine("4 - Sacar");
            Console.WriteLine("5 - Depositar");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            Console.Write("Informe a opção desejada:");
            string opcao = Console.ReadLine();
            return opcao;
        }
    }
}
