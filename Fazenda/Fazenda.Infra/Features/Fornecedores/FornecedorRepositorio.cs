using Fazenda.Dominio.Excecoes;
using Fazenda.Dominio.Features.Fornecedores;
using Fazenda.Infra.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Infra.Features.Fornecedores
{
    public class FornecedorRepositorio : IFornecedorRepositorio
    {
        Contexto _contexto;

        public FornecedorRepositorio(Contexto contexto)
        {
            _contexto = contexto;
        }

        public Fornecedor Adicionar(Fornecedor fornecedor)
        {
            fornecedor.Validar(PegarTodos());
            fornecedor = _contexto.Fornecedores.Add(fornecedor);
            ConfirmarAlteracoes();
            return fornecedor;
        }

        public Fornecedor Atualizar(Fornecedor fornecedor)
        {
            if (fornecedor.Id == 0)
                throw new IdentificadorIndefinidoExcecao();

            fornecedor.Validar(PegarTodos());
            Fornecedor antigaFornecedor = Pegar(fornecedor.Id);
            antigaFornecedor.Nome = fornecedor.Nome;
            antigaFornecedor.Telefone = fornecedor.Telefone;
            antigaFornecedor.Endereco = fornecedor.Endereco;
            antigaFornecedor.Contato = fornecedor.Contato;
            ConfirmarAlteracoes();
            return Pegar(fornecedor.Id);
        }

        public Fornecedor Pegar(int id)
        {
            if (id <= 0) throw new IdentificadorIndefinidoExcecao();
            return _contexto.Fornecedores.Find(id);
        }

        public ICollection<Fornecedor> PegarTodos()
        {
            return _contexto.Fornecedores.ToList();
        }

        public ICollection<Fornecedor> PegarTodosReloadBancoDados()
        {
            var listaFornecedores = _contexto.Fornecedores.ToList();
            foreach (Fornecedor fornecedor in listaFornecedores)
                _contexto.Entry(fornecedor).Reload();
            return listaFornecedores;
        }

        public void Remover(int Id)
        {
            if (Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            var despesas = _contexto.Despesas.ToList();
            var fornecedor = Pegar(Id);
            foreach (var despesa in despesas)
                if (despesa.Fornecedor == fornecedor) throw new FornecedorForeignKeyExcecao();

            _contexto.Fornecedores.Remove(fornecedor);
            ConfirmarAlteracoes();
        }

        public void ConfirmarAlteracoes()
        {
            _contexto.SaveChanges();
        }
    }
}
