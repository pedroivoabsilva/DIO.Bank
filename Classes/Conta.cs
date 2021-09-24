using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Bank
{
    public class Conta
    {

        private int Agencia { get; set; }
        private int NumeroConta { get; set; }

        private string Nome { get; set; }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }

        public Conta(TipoConta tipoConta, int agencia, int numeroConta, string nome, double saldo, double credito)
        {
            Agencia = agencia;
            NumeroConta = numeroConta;
            Nome = nome;
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
        }
        public bool Sacar(double valor)
        {
            if(Saldo - valor < (Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            Saldo -= valor;
            Console.WriteLine($"Saldo atual da contá de {Nome} é R${Saldo}");
            return true;
        }
        public void Depositar(double valor)
        {
            Saldo += valor;
        }
        public void Transferir(double valor, Conta contaDestino)
        {
            if (Sacar(valor))
            {
                contaDestino.Depositar(valor);
            }
        }
        public override string ToString()
        {
            return $"Agencia: {Agencia} / Numero: {NumeroConta}\n" +
                $"Nome: {Nome}\n" +
                $"Saldo: R${Saldo}";
        }
    }
}
