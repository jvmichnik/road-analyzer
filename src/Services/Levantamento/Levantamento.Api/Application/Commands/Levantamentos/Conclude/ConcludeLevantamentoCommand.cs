using Levantamento.Api.Application.Commands.Levantamentos.Conclude.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Levantamentos.Conclude
{
    public class ConcludeLevantamentoCommand : LevantamentoCommand, IRequest<ConcludeLeventamentoResponse>
    {
        public ConcludeLevantamentoCommand(Guid id, DateTime end)
        {
            Id = id;
            End = end;
        }
        public override bool IsValid()
        {
            ValidationResult = new ConcludeLevantamentoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
