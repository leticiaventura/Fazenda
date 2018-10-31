using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Apresentacao.Features.Despesas
{
    public interface IFormularioDespesa : IFormulario
    {
        void Exportar();
        double CalcularSomaDespesas();
    }
}
