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

namespace Levantamento.Api.Controllers
{
    [Route("levantamentos")]
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
        [Route("concluded")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> MarkAsConcludedAsync([FromBody] ConcludeLevantamentoDTO concludeLevantamento)
        {
            var concludeLevantamentoCommand = new ConcludeLevantamentoCommand(concludeLevantamento.Id, concludeLevantamento.ConcludedAt);
            var result = await _mediator.SendCommand<ConcludeLeventamentoResponse>(concludeLevantamentoCommand);
            return Response(result);
        }
    }
}