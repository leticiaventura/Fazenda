using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Despesas
{
    public interface IDespesaServico
    {
        Despesa Adicionar(Despesa despesa);
        Despesa Atualizar(Despesa despesa);
        void Remover(Despesa despesa);
        Despesa Pegar(Despesa despesa);
        ICollection<Despesa> PegarTodos();
        ICollection<Despesa> PegarTodosReloadBancoDados();
    }
}
