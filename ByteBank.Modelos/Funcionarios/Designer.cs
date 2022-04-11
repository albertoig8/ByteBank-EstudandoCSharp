using System;

namespace ByteBank.Modelos.Funcionarios
{
    public class Designer : Programador
    {
        public Designer(String cpf) : base(3000, cpf)
        {

        }

        public override void AumentarSalario()
        {
            Salario *= 1.11;
        }

        internal protected override double GetBonificacao()
        {
            return Salario * 0.17;
        }
    }
}
