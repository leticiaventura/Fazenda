using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Animais
{
    public class AnimalForeignKeyExcecao : ExcecaoNegocio
    {
        public AnimalForeignKeyExcecao() : base("Não é possível remover um animal que já esteja registrado em uma despesa.")
        {
        }
    }
}
