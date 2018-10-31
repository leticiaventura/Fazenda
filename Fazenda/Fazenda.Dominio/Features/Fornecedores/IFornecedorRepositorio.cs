using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Fornecedores
{
    public interface IFornecedorRepositorio
    {
        Fornecedor Adicionar(Fornecedor fornecedor);
        Fornecedor Atualizar(Fornecedor fornecedor);
        void Remover(int id);
        Fornecedor Pegar(int Id);
        ICollection<Fornecedor> PegarTodos();
        ICollection<Fornecedor> PegarTodosReloadBancoDados();
    }
}
