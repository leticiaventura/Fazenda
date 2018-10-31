using Fazenda.Dominio.Excecoes;
using Fazenda.Dominio.Features.Itens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicacao.Features.Itens
{
    public class ItemServico : IItemServico
    {
        IItemRepositorio _repositorio;
        public ItemServico(IItemRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Item Adicionar(Item item)
        {
            item.Validar(_repositorio.PegarTodos());
            return _repositorio.Adicionar(item);
        }

        public Item Atualizar(Item item)
        {
            if (item.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            item.Validar(_repositorio.PegarTodos());
            return _repositorio.Atualizar(item);
        }

        public void Remover(Item item)
        {
            if (item.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            _repositorio.Remover(item.Id);
        }

        public Item Pegar(Item item)
        {
            if (item.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();

            return _repositorio.Pegar(item.Id);
        }

        public ICollection<Item> PegarTodos()
        {
            return _repositorio.PegarTodos();
        }

        public ICollection<Item> PegarTodosReloadBancoDados()
        {
            return _repositorio.PegarTodosReloadBancoDados();
        }
    }
}
