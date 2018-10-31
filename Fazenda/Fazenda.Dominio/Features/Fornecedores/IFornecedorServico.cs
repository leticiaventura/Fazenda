using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Fornecedores
{
    public interface IFornecedorServico
    {
        Fornecedor Adicionar(Fornecedor fornecedor);
        Fornecedor Atualizar(Fornecedor fornecedor);
        void Remover(Fornecedor fornecedor);
        Fornecedor Pegar(Fornecedor fornecedor);
        ICollection<Fornecedor> PegarTodos();
        ICollection<Fornecedor> PegarTodosReloadBancoDados();
    }
}
