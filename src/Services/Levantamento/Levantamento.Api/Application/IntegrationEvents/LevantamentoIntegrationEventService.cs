using IntegrationEventLog;
using IntegrationEventLogMongo.Services;
using Levantamento.Domain.Core.Bus;
using Levantamento.Infrastructure.Context;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZEventBus.Abstractions;
using ZEventBus.Events;

namespace Levantamento.Api.Application.IntegrationEvents
{
    public class LevantamentoIntegrationEventService : ILevantamentoIntegrationEventService
    {
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly IEventBus _eventBus;
        public LevantamentoIntegrationEventService(IIntegrationEventLogService eventLogService, IEventBus eventBus)
        {
            _eventLogService = eventLogService ?? throw new ArgumentNullException(nameof(eventLogService));
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }
        public Task AddAndSaveEventAsync(IntegrationEvent evt, Guid transactionId)
        {
            return _eventLogService.SaveEventAsync(evt, transactionId);
        }

        public async Task PublishEventsThroughEventBusAsync(Guid transactionId)
        {
            var pendingLogEvents = await _eventLogService.RetrieveEventLogsPendingToPublishAsync(transactionId);
            foreach (var logEvt in pendingLogEvents)
            {               
                try
                {
                    await _eventLogService.MarkEventAsInProgressAsync(logEvt.EventId);
                    _eventBus.Publish(logEvt.IntegrationEvent);
                    await _eventLogService.MarkEventAsPublishedAsync(logEvt.EventId);
                }
                catch (Exception ex)
                {
                    await _eventLogService.MarkEventAsFailedAsync(logEvt.EventId);
                }
            }
        }
    }
}
