using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Fornecedores
{
    public class FornecedorContatoInvalidoExcecao : ExcecaoNegocio
    {
        public FornecedorContatoInvalidoExcecao() : base("O contato não pode ter mais do que 30 caracteres")
        {
        }
    }
}
