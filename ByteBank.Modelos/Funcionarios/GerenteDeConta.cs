namespace ByteBank.Modelos.Funcionarios
{
    public class GerenteDeConta : FuncionarioAutenticavel
    {
        public GerenteDeConta(string cpf) : base(3000, cpf)
        {
        }

        public override void AumentarSalario()
        {
            Salario *= 1.5;
        }

        public override double GetBonificacao()
        {
            return Salario * 0.25;
        }
    }
}
