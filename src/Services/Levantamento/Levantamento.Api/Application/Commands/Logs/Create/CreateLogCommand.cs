using Levantamento.Api.Application.Commands.Logs.Create.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Logs.Create
{
    public class CreateLogCommand : LogCommand, IRequest<CreateLogResponse>
    {
        public CreateLogCommand(Guid levantamentoId, decimal @long, decimal lat, decimal rate, int speed, DateTime dateOccurred)
        {
            LevantamentoId = levantamentoId;
            Long = @long;
            Lat = lat;
            Rate = rate;
            Speed = speed;
            DateOccurred = dateOccurred;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateLogCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
