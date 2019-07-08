using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Levantamento.Api.Application.Commands.Levantamentos.Conclude.DTO;
using Levantamento.Api.Application.Commands.Levantamentos.Conclude;
using Levantamento.Api.Application.Commands.Levantamentos.Create;
using Levantamento.Api.Application.Commands.Levantamentos.Create.DTO;
using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Commands;
using Levantamento.Domain.Core.Notifications;
using Levantamento.Infrastructure.Sql.Context;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Levantamento.Api.Application.Commands.Logs.Create;
using Levantamento.Api.Application.Commands.Logs.Create.DTO;

namespace Levantamento.Api.Controllers
{
    [Route("api/levantamentos")]
    public class LevantamentosController : BaseController
    {
        private readonly IMediatorHandler _mediator;
        private readonly ILevantamentoRepository _repository;
        public LevantamentosController(
            ILevantamentoRepository repository,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotification> notifications
            ) : base(notifications, mediator)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet]
        [Route("{idLevantamento}/logs")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetLevantamentoLogsAsync([FromRoute]Guid idLevantamento)
        {
            var result = await _repository.GetLevantamentoLogsAsync(idLevantamento);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLevantamentoAsync([FromBody] CreateLevantamentoDTO createLevantamento)
        {
            var createLevantamentoCommand = new CreateLevantamentoCommand(createLevantamento.Name, createLevantamento.Description, createLevantamento.Start);
            var result =  await _mediator.SendCommand<CreateLeventamentoResponse> (createLevantamentoCommand);
            return Response(result);
        }

        [HttpPut]
        [Route("{levantamentoId}/concluded")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> MarkAsConcludedAsync([FromRoute]Guid levantamentoId,[FromBody] ConcludeLevantamentoDTO concludeLevantamento)
        {
            var concludeLevantamentoCommand = new ConcludeLevantamentoCommand(levantamentoId, concludeLevantamento.ConcludedAt);
            var result = await _mediator.SendCommand<ConcludeLeventamentoResponse>(concludeLevantamentoCommand);
            return Response(result);
        }

        [HttpPost]
        [Route("{levantamentoId}/logs")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateLogAsync([FromRoute]Guid levantamentoId,[FromBody] CreateLogDTO createLog)
        {
            var createLogCommand = new CreateLogCommand(levantamentoId, createLog.Long, createLog.Lat, createLog.Rate, createLog.Speed, createLog.DateOccurred);
            var result = await _mediator.SendCommand<CreateLogResponse>(createLogCommand);
            return Response(result);
        }
    }
}