using Fazenda.Dominio.Excecoes;
using Fazenda.Dominio.Features.Despesas;
using Fazenda.Infra.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Features.Despesas
{
    public class DespesaRepositorio : IDespesaRepositorio
    {
        Contexto _contexto;

        public DespesaRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Despesa Adicionar(Despesa despesa)
        {
            despesa.Validar();
            despesa = _contexto.Despesas.Add(despesa);
            ConfirmarAlteracoes();
            return despesa;
        }

        public Despesa Atualizar(Despesa despesa)
        {
            if (despesa.Id == 0)
                throw new IdentificadorIndefinidoExcecao();

            despesa.Validar();
            Despesa antigaDespesa = Pegar(despesa.Id);
            antigaDespesa.Data = despesa.Data;
            antigaDespesa.Fornecedor = despesa.Fornecedor;
            antigaDespesa.Item = despesa.Item;
            antigaDespesa.Quantidade = despesa.Quantidade;
            antigaDespesa.ValorUnitario = despesa.ValorUnitario;
            ConfirmarAlteracoes();
            return Pegar(despesa.Id);
        }

        public Despesa Pegar(int id)
        {
            if (id <= 0) throw new IdentificadorIndefinidoExcecao();
            return _contexto.Despesas.Find(id);
        }

        public ICollection<Despesa> PegarTodos()
        {
            return _contexto.Despesas.ToList();
        }

        public void Remover(int Id)
        {
            if (Id <= 0)
                throw new IdentificadorIndefinidoExcecao();

            _contexto.Despesas.Remove(Pegar(Id));
            ConfirmarAlteracoes();
        }

        public void ConfirmarAlteracoes()
        {
            _contexto.SaveChanges();
        }

        public ICollection<Despesa> PegarTodosReloadBancoDados()
        {
            var listaDespesas = _contexto.Despesas.ToList();
            foreach (Despesa despesa in listaDespesas)
                _contexto.Entry(despesa).Reload();
            return listaDespesas;
        }
    }
}
