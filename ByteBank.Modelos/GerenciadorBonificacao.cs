using ByteBank.Modelos.Funcionarios;

namespace ByteBank.Modelos
{
    public class GerenciadorBonificacao
    {
        private double _totalBonificacao;

        public void Registrar(Programador funcionario)
        {
            _totalBonificacao += funcionario.GetBonificacao();
        }

        public double GetTotalBonificacao()
        {
            return _totalBonificacao;
        }

    }
}
