using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Despesas
{
    public interface IDespesaRepositorio
    {
        Despesa Adicionar(Despesa Despesa);
        Despesa Atualizar(Despesa Despesa);
        Despesa Pegar(int Id);
        ICollection<Despesa> PegarTodos();
        ICollection<Despesa> PegarTodosReloadBancoDados();
        void Remover(int Id);
    }
}
