using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Levantamentos
{
    public abstract class LevantamentoValidation<T> : AbstractValidator<T> where T : LevantamentoCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome do Levantamento não deve estar vazio.")
                .Length(2, 150).WithMessage("O nome deve conter entre 2 and 150 caracteres");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Name)
                .MaximumLength(500).WithMessage("A descrição não deve ultrapassar 500 caracteres");
        }
    }
}
