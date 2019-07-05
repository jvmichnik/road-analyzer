using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Levantamento.Api.Application.Commands.Levantamentos.Create;
using Levantamento.Api.Application.Commands.Levantamentos.Create.DTO;
using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Commands;
using Levantamento.Domain.Core.Notifications;
using Levantamento.Infrastructure.Sql.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Levantamento.Api.Controllers
{
    [Route("api/levantamentos")]
    public class LevantamentosController : BaseController
    {
        private readonly IMediatorHandler _mediator;
        private readonly LevantamentoContext _context;
        public LevantamentosController(
            IMediatorHandler mediator,
            LevantamentoContext context,
            INotificationHandler<DomainNotification> notifications
            ) : base(notifications, mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _context = context;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLevantamentoAsync([FromBody] CreateLevantamentoDTO createLevantamento)
        {
            var createLevantamentoCommand = new CreateLevantamentoCommand(createLevantamento.Name, createLevantamento.Description);
            var result =  await _mediator.SendCommand<CreateLeventamentoResponse> (createLevantamentoCommand);
            return Response(result);
        }
    }
}