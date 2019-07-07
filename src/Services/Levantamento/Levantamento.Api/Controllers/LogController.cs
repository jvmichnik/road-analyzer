using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Levantamento.Api.Application.Commands.Logs.Create;
using Levantamento.Api.Application.Commands.Logs.Create.DTO;
using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Levantamento.Api.Controllers
{
    [Route("logs")]
    public class LogController : BaseController
    {
        private readonly IMediatorHandler _mediator;
        public LogController(
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications
            ) : base(notifications, mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLogAsync([FromBody] CreateLogDTO createLog)
        {
            var createLogCommand = new CreateLogCommand(createLog.LevantamentoId, createLog.Long, createLog.Lat, createLog.Rate, createLog.Speed, createLog.DateOccurred);
            var result = await _mediator.SendCommand<CreateLogResponse>(createLogCommand);
            return Response(result);
        }
    }
}