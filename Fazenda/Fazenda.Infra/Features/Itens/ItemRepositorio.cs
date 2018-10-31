using Fazenda.Dominio.Excecoes;
using Fazenda.Dominio.Features.Itens;
using Fazenda.Infra.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Features.Itens
{
    public class ItemRepositorio : IItemRepositorio
    {
        Contexto _contexto;

        public ItemRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Item Adicionar(Item item)
        {
            item.Validar(PegarTodos());
            item = _contexto.Itens.Add(item);
            ConfirmarAlteracoes();
            return item;
        }

        public Item Atualizar(Item item)
        {
            if (item.Id == 0)
                throw new IdentificadorIndefinidoExcecao();

            item.Validar(PegarTodos());
            Item antigaItem = Pegar(item.Id);
            antigaItem.Descricao = item.Descricao;
            antigaItem.Unidade = item.Unidade;
            ConfirmarAlteracoes();
            return Pegar(item.Id);
        }

        public Item Pegar(int id)
        {
            if (id <= 0) throw new IdentificadorIndefinidoExcecao();
            return _contexto.Itens.Find(id);
        }

        public ICollection<Item> PegarTodos()
        {
            return _contexto.Itens.ToList();
        }

        public void Remover(int Id)
        {
            if (Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            var despesas = _contexto.Despesas.ToList();
            var item = Pegar(Id);
            foreach (var despesa in despesas)
                if (despesa.Item == item) throw new ItemForeignKeyExcecao();

            _contexto.Itens.Remove(item);
            ConfirmarAlteracoes();
        }

        public void ConfirmarAlteracoes()
        {
            _contexto.SaveChanges();
        }

        public ICollection<Item> PegarTodosReloadBancoDados()
        {
            var listaItens = _contexto.Itens.ToList();
            foreach (Item item in listaItens)
                _contexto.Entry(item).Reload();
            return listaItens;
        }
    }
}
