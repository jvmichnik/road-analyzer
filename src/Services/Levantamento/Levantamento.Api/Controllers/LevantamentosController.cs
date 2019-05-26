using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Levantamento.Api.Application.Commands.Levantamentos.Create;
using Levantamento.Domain.Core.Bus;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Levantamento.Api.Controllers
{
    [Route("api/levantamentos")]
    public class LevantamentosController : Controller
    {
        private readonly IMediatorHandler _mediator;
        public LevantamentosController(
            IMediatorHandler mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        public async Task<ActionResult> CreateLevantamentoAsync([FromBody] CreateLevantamentoCommand createLevantamentoCommand)
        {

            return await _mediator.SendCommand(createLevantamentoCommand);
        }
    }
}