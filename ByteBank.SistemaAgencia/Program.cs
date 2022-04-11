using ByteBank.Modelos;
using Humanizer;
using System;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
           

            string urlTeste = "https://www.bytebank.com/cambio";
            int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");

            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
            Console.WriteLine(urlTeste.EndsWith("cambio"));

            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            ExtratorValorDeArgumentosURL extratorValorDeArgumentosURL = new ExtratorValorDeArgumentosURL(url);

            Console.WriteLine(extratorValorDeArgumentosURL.GetValor("MoedaOrigem"));

            Console.ReadLine();
        }
    }
}
