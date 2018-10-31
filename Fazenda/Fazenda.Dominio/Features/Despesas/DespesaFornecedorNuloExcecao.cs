using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Despesas
{
    public class DespesaFornecedorNuloExcecao : ExcecaoNegocio
    {
        public DespesaFornecedorNuloExcecao() : base("A Despesa deve ter um fornecedor.")
        {
        }
    }
}
