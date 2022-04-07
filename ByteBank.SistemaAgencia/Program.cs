using ByteBank.Modelos;
using System;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(847, 989754);

            new ContaCorrente(1245, 5246);

            Console.WriteLine(conta.Numero);

            Console.ReadLine();
        }
    }
}
