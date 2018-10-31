using Fazenda.Dominio.Excecoes;
using Fazenda.Dominio.Features.Animais;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicacao.Features.Animais
{
    public class AnimalServico : IAnimalServico
    {
        IAnimalRepositorio _repositorio;
        public AnimalServico(IAnimalRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Animal Adicionar(Animal animal)
        {
            animal.Validar(_repositorio.PegarTodos());
            return _repositorio.Adicionar(animal);
        }

        public Animal Atualizar(Animal animal)
        {
            if (animal.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            animal.Validar(_repositorio.PegarTodos());
            return _repositorio.Atualizar(animal);
        }

        public void Remover(Animal animal)
        {
            if (animal.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            _repositorio.Remover(animal.Id);
        }

        public Animal Pegar(Animal animal)
        {
            if (animal.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();

            return _repositorio.Pegar(animal.Id);
        }

        public ICollection<Animal> PegarTodos()
        {
            return _repositorio.PegarTodos();
        }

        public ICollection<Animal> PegarTodosReloadBancoDados()
        {
            return _repositorio.PegarTodosReloadBancoDados();
        }
    }
}
