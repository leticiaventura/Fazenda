using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Fornecedores
{
    public class FornecedorEnderecoInvalidoExcecao : ExcecaoNegocio
    {
        public FornecedorEnderecoInvalidoExcecao() : base("O Endereço não pode ter mais do que 70 caracteres")
        {
        }
    }
}
