using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Fornecedores
{
    public class FornecedorForeignKeyExcecao : ExcecaoNegocio
    {
        public FornecedorForeignKeyExcecao() : base("Não é possível deletar um fornecedor que já esteja registrado em alguma despesa.")
        {
        }
    }
}
