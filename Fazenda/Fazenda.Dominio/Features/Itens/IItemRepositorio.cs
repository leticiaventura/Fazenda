using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Itens
{
    public interface IItemRepositorio
    {
        Item Adicionar(Item item);
        Item Atualizar(Item item);
        void Remover(int id);
        Item Pegar(int Id);
        ICollection<Item> PegarTodos();
        ICollection<Item> PegarTodosReloadBancoDados();
    }
}
