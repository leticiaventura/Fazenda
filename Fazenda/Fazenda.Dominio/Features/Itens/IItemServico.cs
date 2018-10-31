using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Itens
{
    public interface IItemServico
    {
        Item Adicionar(Item item);
        Item Atualizar(Item item);
        void Remover(Item item);
        Item Pegar(Item item);
        ICollection<Item> PegarTodos();
        ICollection<Item> PegarTodosReloadBancoDados();
    }
}
