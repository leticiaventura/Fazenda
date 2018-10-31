using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Excecoes
{
    public class IdentificadorIndefinidoExcecao : ExcecaoNegocio
    {
        public IdentificadorIndefinidoExcecao() : base("O ID é inválido.")
        {

        }
    }
}
