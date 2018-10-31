using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Itens
{
    public class ItemDescricaoInvalidaExcecao : ExcecaoNegocio
    {
        public ItemDescricaoInvalidaExcecao() : base("A Desrição não pode estar vazia nem ter mais de 70 caracteres")
        {
        }
    }
}
