using Levantamento.SignalR.IntegrationEvents.Events;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using ZEventBus.Abstractions;

namespace Levantamento.SignalR.IntegrationEvents.EventHandling
{
    public class LevantamentoStartedIntegrationEventHandler :
        IIntegrationEventHandler<LevantamentoStartedIntegrationEvent>
    {
        private readonly IHubContext<NotificationsHub> _hubContext;
        public LevantamentoStartedIntegrationEventHandler(IHubContext<NotificationsHub> hubContext)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        public async Task Handle(LevantamentoStartedIntegrationEvent @event)
        {
            await _hubContext.Clients
                    .All
                    .SendAsync("LevantamentoStarted", @event );
        }
    }
}
