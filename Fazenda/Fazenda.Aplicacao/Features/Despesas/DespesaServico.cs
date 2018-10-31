using Fazenda.Dominio.Excecoes;
using Fazenda.Dominio.Features.Despesas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicacao.Features.Despesas
{
    public class DespesaServico : IDespesaServico
    {
        IDespesaRepositorio _repositorio;
        public DespesaServico(IDespesaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public Despesa Adicionar(Despesa despesa)
        {
            despesa.Validar();
            return _repositorio.Adicionar(despesa);
        }

        public Despesa Atualizar(Despesa despesa)
        {
            if (despesa.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            despesa.Validar();
            return _repositorio.Atualizar(despesa);
        }

        public Despesa Pegar(Despesa despesa)
        {
            if (despesa.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();

            return _repositorio.Pegar(despesa.Id);
        }

        public ICollection<Despesa> PegarTodos()
        {
            return _repositorio.PegarTodos();
        }

        public ICollection<Despesa> PegarTodosReloadBancoDados()
        {
            return _repositorio.PegarTodosReloadBancoDados();
        }

        public void Remover(Despesa despesa)
        {
            if (despesa.Id <= 0)
                throw new IdentificadorIndefinidoExcecao();
            _repositorio.Remover(despesa.Id);
        }
    }
}
