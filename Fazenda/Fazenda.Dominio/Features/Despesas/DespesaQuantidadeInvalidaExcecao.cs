using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Despesas
{
    public class DespesaQuantidadeInvalidaExcecao : ExcecaoNegocio
    {
        public DespesaQuantidadeInvalidaExcecao() : base("A Quantidade deve ser maior que 0.")
        {
        }
    }
}
