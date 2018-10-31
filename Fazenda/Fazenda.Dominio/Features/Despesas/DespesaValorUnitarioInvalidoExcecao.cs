using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Despesas
{
    public class DespesaValorUnitarioInvalidoExcecao : ExcecaoNegocio
    {
        public DespesaValorUnitarioInvalidoExcecao() : base("O valor unitário deve ser maior que 0")
        {
        }
    }
}
