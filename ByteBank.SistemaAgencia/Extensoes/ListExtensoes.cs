using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensoes
{
    public static class ListExtensoes
    {
        public static void AdicionarVarios<T>(this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }
        }

        static void Test()
        {
            List<int> idades = new List<int>();

            idades.Add(15);
            idades.Add(18);
            idades.Add(20);
            idades.Add(32);

            idades.AdicionarVarios( 5368, 6144, 1756);
        }
    }
}
