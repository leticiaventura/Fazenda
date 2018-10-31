using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Animais
{
    public class AnimalEspecieRedundanteExcecao : ExcecaoNegocio
    {
        public AnimalEspecieRedundanteExcecao() : base("Este animal já está cadastrado.")
        {
        }
    }
}
