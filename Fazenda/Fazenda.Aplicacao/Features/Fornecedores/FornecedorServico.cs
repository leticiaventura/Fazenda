using Fazenda.Dominio.Excecoes;
using Fazenda.Dominio.Features.Fornecedores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicacao.Features.Fornecedores
{
    public class FornecedorServico : IFornecedorServico
    {
        IFornecedorRepositorio _repositorio;
        public FornecedorServico(IFornecedorRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Fornecedor Adicionar(Fornecedor fornecedor)
        {
            fornecedor.Validar(_repositorio.PegarTodos());
            return _repositorio.Adicionar(fornecedor);
        }

        public Fornecedor Atualizar(Fornecedor fornecedor)
        {
            if (fornecedor.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            fornecedor.Validar(_repositorio.PegarTodos());
            return _repositorio.Atualizar(fornecedor);
        }

        public void Remover(Fornecedor fornecedor)
        {
            if (fornecedor.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            _repositorio.Remover(fornecedor.Id);
        }

        public Fornecedor Pegar(Fornecedor fornecedor)
        {
            if (fornecedor.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();

            return _repositorio.Pegar(fornecedor.Id);
        }

        public ICollection<Fornecedor> PegarTodos()
        {
            return _repositorio.PegarTodos();
        }
        public ICollection<Fornecedor> PegarTodosReloadBancoDados()
        {
            return _repositorio.PegarTodosReloadBancoDados();
        }
    }
}
