using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Logs.Create
{
    public class CreateLogCommandValidation : LogValidation<CreateLogCommand>
    {
        public CreateLogCommandValidation()
        {
            ValidateLevantamento();
            ValidateLong();
            ValidateLat();
            ValidateRate();
            ValidateSpeed();
            ValidateDateOcorrencia();
        }
    }
}
