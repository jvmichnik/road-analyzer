using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Logs
{
    public abstract class LogValidation<T> : AbstractValidator<T> where T : LogCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("Identificador não deve estar vazio.");
        }
        protected void ValidateLevantamento()
        {
            RuleFor(c => c.LevantamentoId)
                .NotEmpty().WithMessage("Identificador do Levantamento não deve estar vazio.");
        }
        protected void ValidateLong()
        {
            RuleFor(c => c.Long)
                .NotEmpty().WithMessage("Longitude não deve estar vazio.")
                .InclusiveBetween((decimal)-999.999999999, (decimal)999.999999999).WithMessage("Latitude Inválida");
        }
        protected void ValidateLat()
        {
            RuleFor(c => c.Lat)
                .NotEmpty().WithMessage("Latitude não deve estar vazio.")
                .InclusiveBetween((decimal)-999.999999999, (decimal)999.999999999).WithMessage("Latitude Inválida");
        }
        protected void ValidateRate()
        {
            RuleFor(c => c.Rate)
                .NotEmpty().WithMessage("A Rate não deve estar vazio.")
                .InclusiveBetween((decimal)-999.999, (decimal)999.999).WithMessage("Rate inválida.");
        }
        protected void ValidateSpeed()
        {
            RuleFor(c => c.Speed)
                .NotEmpty().WithMessage("A Velocidade não deve estar vazia.")
                .GreaterThanOrEqualTo(0).WithMessage("A Velocidade não deve ser menor que 0.");
        }
        protected void ValidateDateOcorrencia()
        {
            RuleFor(c => c.DateOccurred)
                .NotEmpty().WithMessage("A Data de Ocorrência não deve estar vazia.");
        }
    }
}
