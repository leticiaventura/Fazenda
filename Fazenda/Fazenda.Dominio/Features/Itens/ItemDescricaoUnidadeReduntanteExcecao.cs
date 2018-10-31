using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Itens
{
    public class ItemDescricaoUnidadeReduntanteExcecao : ExcecaoNegocio
    {
        public ItemDescricaoUnidadeReduntanteExcecao() : base("Este item já está cadastrado.")
        {
        }
    }
}
