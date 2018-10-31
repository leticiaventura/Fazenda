using Fazenda.Dominio.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Dominio.Features.Animais
{
    public class AnimalEspecieVaziaExcecao : ExcecaoNegocio
    {
        public AnimalEspecieVaziaExcecao() : base("A espécie não pode estar vazia e nem ter mais de 20 caracteres.")
        {
        }
    }
}
