using Fazenda.Dominio.Excecoes;
using Fazenda.Dominio.Features.Animais;
using Fazenda.Infra.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Features.Animais
{
    public class AnimalRepositorio : IAnimalRepositorio
    {
        Contexto _contexto;

        public AnimalRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Animal Adicionar(Animal animal)
        {
            animal = _contexto.Animais.Add(animal);
            ConfirmarAlteracoes();
            return animal;
        }

        public Animal Atualizar(Animal animal)
        {
            if (animal.Id == 0)
                throw new IdentificadorIndefinidoExcecao();

            Animal antigaAnimal = Pegar(animal.Id);
            antigaAnimal.Especie = animal.Especie;
            ConfirmarAlteracoes();
            return Pegar(animal.Id);
        }

        public Animal Pegar(int id)
        {
            if (id <= 0) throw new IdentificadorIndefinidoExcecao();
            return _contexto.Animais.Find(id);
        }

        public ICollection<Animal> PegarTodos()
        {
            return _contexto.Animais.ToList();
        }

        public void Remover(int Id)
        {
            if (Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            var despesas = _contexto.Despesas.ToList();
            var animal = Pegar(Id);
            foreach (var despesa in despesas)
                if (despesa.Animal == animal) throw new AnimalForeignKeyExcecao();

            _contexto.Animais.Remove(animal);
            ConfirmarAlteracoes();
        }

        public void ConfirmarAlteracoes()
        {
            _contexto.SaveChanges();
        }

        public ICollection<Animal> PegarTodosReloadBancoDados()
        {
            var listaAnimais = _contexto.Animais.ToList();
            foreach (Animal animal in listaAnimais)
                _contexto.Entry(animal).Reload();
            return listaAnimais;
        }
    }
}
