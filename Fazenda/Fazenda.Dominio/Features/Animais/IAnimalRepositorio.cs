using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Animais
{
    public interface IAnimalRepositorio
    {
        Animal Adicionar(Animal animal);
        Animal Atualizar(Animal animal);
        void Remover(int Id);
        Animal Pegar(int Id);
        ICollection<Animal> PegarTodos();
        ICollection<Animal> PegarTodosReloadBancoDados();
    }
}
