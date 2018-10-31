using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Despesas
{
    public class DespesaTipoCriacaoSemAnimalExcecao : ExcecaoNegocio
    {
        public DespesaTipoCriacaoSemAnimalExcecao() : base ("Uma despesa do tipo Criação precisa estar relacionada a um animal")
        {

        }
    }
}
