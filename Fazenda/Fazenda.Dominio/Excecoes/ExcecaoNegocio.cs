using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Excecoes
{
    public class ExcecaoNegocio : Exception
    {
        public ExcecaoNegocio(string mensagem) : base(mensagem)
        {

        }
    }
}
