using Levantamento.Domain.Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Levantamentos.Create
{
    public class CreateLevantamentoCommand : LevantamentoCommand, IRequest<CommandResponse>
    {
        public CreateLevantamentoCommand(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateLevantamentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
