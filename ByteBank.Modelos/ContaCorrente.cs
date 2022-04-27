﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Define uma Conta Corrente do banco ByteBank.
    /// </summary>
    public class ContaCorrente
    {
        private static int TaxaOperacao;

        /// <summary>
        /// TotalDeContasCriadas
        /// </summary>
        public static int TotalDeContasCriadas { get; private set; }

        /// <summary>
        /// Titular
        /// </summary>
        public Cliente Titular { get; set; }

        /// <summary>
        /// ContadorSaquesNaoPermitidos
        /// </summary>
        public int ContadorSaquesNaoPermitidos { get; private set; }

        /// <summary>
        /// ContadorTransferenciasNaoPermitidas
        /// </summary>
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        /// <summary>
        /// Numero
        /// </summary>
        public int Numero { get; }

        /// <summary>
        /// Agencia
        /// </summary>
        public int Agencia { get; }

        private double _saldo = 100;

        /// <summary>
        /// Saldo
        /// </summary>
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        /// <summary>
        /// Cria uma intâcia de ContaCorrente com os argumentos utilizados.
        /// </summary>
        /// <param name="agencia">Representa o valor da propiedade <see cref="Agencia"/> e deve possuir um valor maior que zero</param>
        /// <param name="numero">Representa o valor da propiedade <see cref="Numero"/> e deve possuir um valor maior que zero</param>
        /// <exception cref="ArgumentException">Exceção lançada quando o parametro <paramref name="agencia"/> ou <paramref name="numero"/> é menor ou igual a 0.</exception>
        public ContaCorrente(int agencia, int numero)
        {
            if (numero <= 0)
            {
                throw new ArgumentException("O argumento agencia deve ser maior que 0.", nameof(agencia));
            }

            if(numero <= 0)
            {
                throw new ArgumentException("O argumento numero deve ser maior que 0.", nameof(numero));
            }

            Agencia = agencia;
            Numero = numero;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas;
        }

        /// <summary>
        /// Realiza o saque e atualiza o valor da propiedade <see cref="Saldo"/>.
        /// </summary>
        /// <param name="valor">Representa o valor do saque e deve ser maior que 0 e menor que o <see cref="Saldo"/></param>
        /// <exception cref="ArgumentException">Exceção lançada quando um valor negativo é utilizado no argumento <paramref name="valor"/></exception>
        /// <exception cref="SaldoInsuficienteException">Exceção lançada quando o valor do argumento <paramref name="valor"/> é maior que o valor da propiedade <see cref="Saldo"/></exception>
        public void Sacar(double valor)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para o saque.", nameof(valor));
            }

            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }

            _saldo -= valor;
        }

        /// <summary>
        /// Adiciona um <paramref name="valor"/> ao <see cref="Saldo"/> da Conta
        /// </summary>
        /// <param name="valor">Representa o valor de saque e deve ser maior que zero</param>
        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        /// <summary>
        /// Transfere um valor de uma conta para a outra
        /// </summary>
        /// <param name="valor">Representa o valor que vai ser transferido e deve ser maior que zero</param>
        /// <param name="contaDestino">Representa uma ContaCorrente instanciada para qual o valor vai ser depositado</param>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="OperacaoFinanceiraException"></exception>
        public void Transferir(double valor, ContaCorrente contaDestino)
        {
            if (valor < 0)
            {
                throw new ArgumentException("Valor inválido para a transferência.", nameof(valor));
            }
            
            try
            {
                Sacar(valor);
            }
            catch(SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw new OperacaoFinanceiraException("Operação não realizada.", ex);
            }

            contaDestino.Depositar(valor);
        }
        /// <summary>
        /// ToString
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"Número {Numero}, Agência {Agencia}, Saldo {Saldo}";
        }

        public override bool Equals(object obj)
        {
            ContaCorrente outraConta = obj as ContaCorrente;

            if (outraConta == null)
            {
                return false;
            }

            return Numero == outraConta.Numero && Agencia == outraConta.Agencia;
        }
    }
}
