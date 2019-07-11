using Levantamento.SignalR.IntegrationEvents.Events;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZEventBus.Abstractions;

namespace Levantamento.SignalR.IntegrationEvents.EventHandling
{
    public class LogSendedIntegrationEventHandler :
        IIntegrationEventHandler<LogSendedIntegrationEvent>
    {
        private readonly IHubContext<NotificationsHub> _hubContext;
        public LogSendedIntegrationEventHandler(IHubContext<NotificationsHub> hubContext)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }
        public async Task Handle(LogSendedIntegrationEvent @event)
        {
            await _hubContext.Clients
                .Group(@event.LevantamentoId.ToString())
                .SendAsync("LogSended", @event);

        }
    }
}
