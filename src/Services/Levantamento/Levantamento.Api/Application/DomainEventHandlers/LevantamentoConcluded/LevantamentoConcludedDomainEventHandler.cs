using Levantamento.Api.Application.IntegrationEvents;
using Levantamento.Api.Application.IntegrationEvents.Events.Levantamento;
using Levantamento.Domain.Events;
using Levantamento.Infrastructure.Sql.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.DomainEventHandlers.LevantamentoConcluded
{
    public class LevantamentoConcludedDomainEventHandler : INotificationHandler<LevantamentoConcludedDomainEvent>
    {
        private readonly ILevantamentoIntegrationEventService _levantamentoIntegrationEventService;
        public LevantamentoConcludedDomainEventHandler(ILevantamentoIntegrationEventService levantamentoIntegrationEventService)
        {
            _levantamentoIntegrationEventService = levantamentoIntegrationEventService ?? throw new ArgumentNullException(nameof(levantamentoIntegrationEventService));
        }
        public async Task Handle(LevantamentoConcludedDomainEvent notification, CancellationToken cancellationToken)
        {
            var eventConcludedIntegrationEvent = new LevantamentoConcludedIntegrationEvent(notification.Id, notification.Name, notification.Description, notification.Start, notification.End);
            await _levantamentoIntegrationEventService.AddAndSaveEventAsync(eventConcludedIntegrationEvent);
        }
    }
}
