using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Itens
{
    public class ItemForeignKeyExcecao : ExcecaoNegocio
    {
        public ItemForeignKeyExcecao() : base("Não é possível deletar um item que esteja cadastrado em uma despesa.")
        {
        }
    }
}
