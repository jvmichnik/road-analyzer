using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZEventBus.Events;

namespace Levantamento.Api.Application.IntegrationEvents
{
    public interface ILevantamentoIntegrationEventService
    {
        Task PublishEventsThroughEventBusAsync(Guid transactionId);
        Task AddAndSaveEventAsync(IntegrationEvent evt);
    }
}
