using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using Humanizer;
using System;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente conta = new ContaCorrente(135457, 12347);
            Desenvolvedor desenvolvedor = new Desenvolvedor("12354678910");

            string contaToString = conta.ToString();

            Console.WriteLine(contaToString);
            Console.WriteLine(conta);

            Cliente alberto_1 = new Cliente();
            alberto_1.Profissao = "Desenvolvedor";
            alberto_1.Nome = "Alberto";
            alberto_1.CPF = "123.456.789-10";

            Cliente alberto_2 = new Cliente();
            alberto_2.Profissao = "Desenvolvedor";
            alberto_2.Nome = "Alberto";
            alberto_2.CPF = "123.456.789-10";

            if (alberto_1.Equals(conta))
            {
                Console.WriteLine("São iguais");
            }
            else
            {
                Console.WriteLine("Não são iguais");
            }

            Console.ReadLine();
        }

        static void TestaString()
        {
            // "[123456789][123456789][123456789][123456789][-][123456789][123456789][123456789][123456789]"
            // "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            // "[0-9]{4,5}[-][0-9]{4}";
            // "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            // "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";
            string textoDeTeste = "Meu nome é Alberto, me ligue em 99404-0805";
            Match resultado = Regex.Match(textoDeTeste, padrao);

            Console.WriteLine(resultado.Value);

            Console.ReadLine();

            string urlTeste = "https://www.bytebank.com/cambio";
            int indiceByteBank = urlTeste.IndexOf("https://www.bytebank.com");

            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com"));
            Console.WriteLine(urlTeste.EndsWith("cambio"));

            Console.ReadLine();

            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            ExtratorValorDeArgumentosURL extratorValorDeArgumentosURL = new ExtratorValorDeArgumentosURL(url);

            Console.WriteLine(extratorValorDeArgumentosURL.GetValor("MoedaOrigem"));

            Console.ReadLine();
        }
    }
}
