using Levantamento.Api.Application.Commands.Levantamentos.Create.DTO;
using Levantamento.Domain.Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Levantamentos.Create
{
    public class CreateLevantamentoCommand : LevantamentoCommand, IRequest<CreateLeventamentoResponse>
    {
        public CreateLevantamentoCommand(string name, string description, DateTime start)
        {
            Name = name;
            Description = description;
            Start = start;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateLevantamentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
