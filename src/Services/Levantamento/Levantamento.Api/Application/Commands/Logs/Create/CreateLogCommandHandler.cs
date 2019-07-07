using Levantamento.Api.Application.Commands.Logs.Create.DTO;
using Levantamento.Api.Application.IntegrationEvents;
using Levantamento.Api.Application.IntegrationEvents.Events.Logs;
using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Commands;
using Levantamento.Domain.Core.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Logs.Create
{
    public class CreateLogCommandHandler :
        CommandHandler,
        IRequestHandler<CreateLogCommand, CreateLogResponse>
    {
        private readonly ILevantamentoIntegrationEventService _eventBus;
        private readonly IMediatorHandler Bus;
        public CreateLogCommandHandler(
            ILevantamentoIntegrationEventService eventBus,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications
            ) : base(bus, notifications)
        {
            _eventBus = eventBus;
            Bus = bus;
        }

        public Task<CreateLogResponse> Handle(CreateLogCommand request, CancellationToken cancellationToken)
        {
            var logSendedIntegrationEvent = new LogSendedIntegrationEvent(request.LevantamentoId, request.Long, request.Lat, request.Rate, request.Speed, request.DateOccurred);

            _eventBus.PublishEventAsync(logSendedIntegrationEvent);


            return Task.FromResult(new CreateLogResponse
            {
                LevantamentoId = logSendedIntegrationEvent.LevantamentoId,
                Long = logSendedIntegrationEvent.Long,
                Lat = logSendedIntegrationEvent.Lat,
                Rate = logSendedIntegrationEvent.Rate,
                Speed = logSendedIntegrationEvent.Speed,
                DateOccurred = logSendedIntegrationEvent.DateOccurred
            });
        }
    }
}
