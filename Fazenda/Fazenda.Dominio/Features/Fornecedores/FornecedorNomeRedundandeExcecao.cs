using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Fornecedores
{
    public class FornecedorNomeRedundandeExcecao : ExcecaoNegocio
    {
        public FornecedorNomeRedundandeExcecao() : base("Este fornecedor já existe.")
        {
        }
    }
}
