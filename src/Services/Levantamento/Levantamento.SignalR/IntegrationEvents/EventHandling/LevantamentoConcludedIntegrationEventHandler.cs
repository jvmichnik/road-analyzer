using Levantamento.SignalR.IntegrationEvents.Events;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using ZEventBus.Abstractions;

namespace Levantamento.SignalR.IntegrationEvents.EventHandling
{
    public class LevantamentoConcludedIntegrationEventHandler :
        IIntegrationEventHandler<LevantamentoConcludedIntegrationEvent>
    {
        private readonly IHubContext<NotificationsHub> _hubContext;
        public LevantamentoConcludedIntegrationEventHandler(IHubContext<NotificationsHub> hubContext)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        public async Task Handle(LevantamentoConcludedIntegrationEvent @event)
        {
            await _hubContext.Clients
                        .All
                        .SendAsync("LevantamentoConcluded", @event);
        }
    }
}
