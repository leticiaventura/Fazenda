using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Fornecedores
{
    public class FornecedorTelefoneInvalidoExcecao : ExcecaoNegocio
    {
        public FornecedorTelefoneInvalidoExcecao() : base("O telefone não pode ter mais do que 15 caracteres.")
        {
        }
    }
}
