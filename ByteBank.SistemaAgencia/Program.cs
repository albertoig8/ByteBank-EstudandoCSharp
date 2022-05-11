using ByteBank.Modelos;
using ByteBank.Modelos.Funcionarios;
using ByteBank.SistemaAgencia.Comparadores;
using ByteBank.SistemaAgencia.Extensoes;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    class Program
    {
        static void Main(string[] args)
        {
            var contas = new List<ContaCorrente>() 
            { 
                new ContaCorrente(5236, 55896),
                new ContaCorrente(3306, 15896),
                new ContaCorrente(3324, 1),
                new ContaCorrente(9636, 22358),
                new ContaCorrente(2236, 22896)
            };

            // contas.Sort(); ~~> Chama a implementação dada em IComparable

            // contas.Sort(new ComparadorContaCorrentePorAgencia());

            var contasOrdenadas = contas
                .Where(conta => conta != null)
                .OrderBy(conta => conta.Numero);

            foreach(var conta in contasOrdenadas)
            {
                Console.WriteLine($"Conta número {conta.Numero} Agência {conta.Agencia}");
               
            }

            Console.ReadLine();
        }

        static void TestaSort()
        {
            var nomes = new List<string>()
            {
                "Alberto",
                "Carlos",
                "Zemberg",
                "Relone"
            };

            nomes.Sort();

            foreach (var nome in nomes)
            {
                Console.WriteLine(nome);
            }


            var idades = new List<int>();

            idades.Add(4);
            idades.Add(15);
            idades.Add(25);
            idades.Add(850);
            idades.Add(47);

            idades.AdicionarVarios(78, 236, 158);

            idades.Sort();

            for (int i = 0; i < idades.Count; i++)
            {
                Console.WriteLine(idades[i]);
            }
        }

        static void TestaListaDeObject()
        {
            ListaDeObject listaDeIdades = new ListaDeObject();

            listaDeIdades.Adicionar(10);
            listaDeIdades.Adicionar(9);
            listaDeIdades.Adicionar(2);
            listaDeIdades.AdicionarVarios(11, 7, 15);

            for(int i = 0; i < listaDeIdades.Tamanho; i++)
            {
                int idade = (int)listaDeIdades[i];
                Console.WriteLine($"Idade no indice {i} : {idade}");
            }

        }

        static int SomarVarios(params int[] numeros)
        {
            int acumulador = 0;
            foreach(int numero in numeros)
            {
                acumulador += numero;
            }
            return acumulador;
        }

        static void TestaListaDeContaCorrente()
        {
            ListaDeContaCorrente lista = new ListaDeContaCorrente();

            ContaCorrente contaDoBeto = new ContaCorrente(1111, 111111);

            ContaCorrente[] contas = new ContaCorrente[]
            {
                contaDoBeto,
                new ContaCorrente(2568, 568475),
                new ContaCorrente(2568, 561245),
                new ContaCorrente(2568, 257896)
            };

            lista.AdicionarVarios(contas);

            lista.AdicionarVarios(
                contaDoBeto,
                new ContaCorrente(2568, 568475),
                new ContaCorrente(2568, 561245),
                new ContaCorrente(2568, 257896)
            );

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente itemAtual = lista[i];
                Console.WriteLine($"Item na posição {i} = Conta {itemAtual.Numero}/{itemAtual.Agencia}");
            }
        }

        static void TestaArrayDeContaCorrente()
        {
            ContaCorrente[] contas = new ContaCorrente[]
            {
                new ContaCorrente(258, 369852),
                new ContaCorrente(258, 148856),
                new ContaCorrente(258, 365221),
            };

            for (int i = 0; i < contas.Length; i++)
            {
                ContaCorrente contaAtual = contas[i];

                Console.WriteLine($"Conta {i} - {contaAtual.Numero}");
            }
        }

        static void TestaArrayInt()
        {
            // ARRAY de inteiros com 5 posições.
            int[] idades = new int[5];

            idades[0] = 37;
            idades[1] = 15;
            idades[2] = 25;
            idades[3] = 14;
            idades[4] = 26;

            int acumulador = 0;

            for (int indice = 0; indice < idades.Length; indice++)
            {
                int idade = idades[indice];

                Console.WriteLine($"Acessando o array idades no indice {indice}");
                Console.WriteLine($"Valor de idades[{indice}] = {idade}");

                acumulador += idade;
            }

            var media = acumulador / idades.Length;

            Console.WriteLine($"madia de idades = {media}");
        }

    }
}
