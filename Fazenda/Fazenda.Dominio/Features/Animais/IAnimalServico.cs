using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Animais
{
    public interface IAnimalServico
    {
        Animal Adicionar (Animal animal);
        Animal Atualizar (Animal animal);
        void Remover (Animal animal);
        Animal Pegar (Animal animal);
        ICollection<Animal> PegarTodos();
        ICollection<Animal> PegarTodosReloadBancoDados();
    }
}
