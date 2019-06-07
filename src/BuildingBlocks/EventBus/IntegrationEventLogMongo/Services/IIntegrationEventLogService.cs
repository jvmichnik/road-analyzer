using IntegrationEventLog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ZEventBus.Events;

namespace IntegrationEventLogMongo.Services
{
    public interface IIntegrationEventLogService
    {
        Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId);
        Task SaveEventAsync(IntegrationEvent @event, Guid transactionId);
        Task MarkEventAsPublishedAsync(Guid eventId);
        Task MarkEventAsInProgressAsync(Guid eventId);
        Task MarkEventAsFailedAsync(Guid eventId);
    }
}
