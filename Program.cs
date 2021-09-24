using System;

namespace DIO.Bank
{
    public class Program
    {
        static void Main(string[] args)
        {
            Conta conta = new Conta(TipoConta.PessoaFisica,0110,321231,"Pedro Ivo",100.00,100.00);
            Console.WriteLine(conta);
        }
    }
}
