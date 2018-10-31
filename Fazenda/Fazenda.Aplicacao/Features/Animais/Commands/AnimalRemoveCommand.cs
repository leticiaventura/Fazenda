using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicacao.Features.Animais.Commands
{
    public class AnimalRemoveCommand
    {
        public int Id { get; set; }

        public ValidationResult Validar()
        {
            return new Validador().Validate(this);
        }

        private class Validador : AbstractValidator<AnimalRemoveCommand>
        {
            public Validador()
            {
                RuleFor(a => a.Id).NotNull().GreaterThan(0).WithMessage("O id é inválido");
            }
        }
    }
}
