using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicacao.Features.Animais.ViewModels
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string Especie { get; set; }
    }
}
