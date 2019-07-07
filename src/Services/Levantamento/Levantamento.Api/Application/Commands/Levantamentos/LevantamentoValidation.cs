using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Levantamentos
{
    public abstract class LevantamentoValidation<T> : AbstractValidator<T> where T : LevantamentoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Identificador não deve estar vazio.");
        }
        protected void ValidateName()
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Nome do Levantamento não deve estar vazio.")
                .Length(2, 150).WithMessage("O Nome deve conter entre 2 and 150 caracteres");
        }

        protected void ValidateDescription()
        {
            RuleFor(c => c.Name)
                .MaximumLength(500).WithMessage("A Descrição não deve ultrapassar 500 caracteres");
        }
        protected void ValidateStart()
        {
            RuleFor(c => c.Start)
                .NotEmpty().WithMessage("A Data de Inicio não deve estar vazia.");
        }
        protected void ValidateEnd()
        {
            RuleFor(c => c.End)
                .NotEmpty().WithMessage("A Data de Término não deve estar vazia.");
        }
    }
}
