using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Fornecedores
{
    public class FornecedorNomeInvalidoExcecao : ExcecaoNegocio
    {
        public FornecedorNomeInvalidoExcecao() : base("O Nome não pode estar vazio e nem ter mais de 30 caracteres")
        {
        }
    }
}
