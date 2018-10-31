using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Despesas
{
    public class DespesaAnimalInvalidoExcecao : ExcecaoNegocio
    {
        public DespesaAnimalInvalidoExcecao() : base("Uma despesa do tipo plantação/estrutura não pode ter um animal associado")
        {
        }
    }
}
