using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    /// <summary>
    /// Cliente
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Nome
        /// </summary>
        /// 
        public string Nome { get; set; }
        /// <summary>
        /// CPF
        /// </summary>
        /// 
        public string CPF { get; set; }

        /// <summary>
        /// Profissao
        /// </summary>
        public string Profissao { get; set; }

        /// <summary>
        /// Método Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            //Cliente outroCliente = (Cliente)obj;
            Cliente outroCliente = obj as Cliente;

            if(outroCliente == null)
            {
                return false;
            }

            return
                CPF == outroCliente.CPF;
        }
    }

}
