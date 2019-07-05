using Levantamento.Api.Application.IntegrationEvents;
using Levantamento.Api.Application.IntegrationEvents.Events.Levantamento;
using Levantamento.Domain.Events;
using Levantamento.Infrastructure.Sql.Context;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.DomainEventHandlers.LevantamentoStarted
{
    public class LevantamentoStartedDomainEventHandler : INotificationHandler<LevantamentoStartedDomainEvent>
    {
        private readonly ILevantamentoIntegrationEventService _levantamentoIntegrationEventService;
        private readonly LevantamentoContext _context;
        public LevantamentoStartedDomainEventHandler(ILevantamentoIntegrationEventService levantamentoIntegrationEventService, LevantamentoContext context)
        {
            _levantamentoIntegrationEventService = levantamentoIntegrationEventService ?? throw new ArgumentNullException(nameof(levantamentoIntegrationEventService));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task Handle(LevantamentoStartedDomainEvent notification, CancellationToken cancellationToken)
        {
            var eventStartedIntegrationEvent = new LevantamentoStartedIntegrationEvent(notification.Id, notification.Name, notification.Description, notification.Start);
            await _levantamentoIntegrationEventService.AddAndSaveEventAsync(eventStartedIntegrationEvent);
        }
    }
}
