using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fazenda.Aplicacao.Features.Animais.Commands
{
    public class AnimalUpdateCommand
    {
        public int Id { get; set; }
        public string Especie { get; set; }

        public ValidationResult Validar()
        {
            return new Validador().Validate(this);
        }

        private class Validador : AbstractValidator<AnimalUpdateCommand>
        {
            public Validador()
            {
                RuleFor(a => a.Especie)
                    .NotNull().WithMessage("A espécie não pode ser nula")
                    .NotEmpty().WithMessage("A espécie não pode estar vazia")
                    .MaximumLength(20).WithMessage("A espécie deve  conter no máximo 20 caracteres");
                RuleFor(a => a.Id).NotNull().GreaterThan(0).WithMessage("O id é inválido");
            }
        }
    }
}
