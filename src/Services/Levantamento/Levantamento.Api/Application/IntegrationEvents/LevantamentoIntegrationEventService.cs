﻿using IntegrationEventLog;
using IntegrationEventLogEF.Services;
using Levantamento.Domain.Core.Bus;
using Levantamento.Infrastructure.Sql.Context;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using ZEventBus.Abstractions;
using ZEventBus.Events;

namespace Levantamento.Api.Application.IntegrationEvents
{
    public class LevantamentoIntegrationEventService : ILevantamentoIntegrationEventService
    {
        private readonly LevantamentoContext _levantamentoContext;
        private readonly Func<DbConnection, IIntegrationEventLogService> _integrationEventLogServiceFactory;
        private readonly IIntegrationEventLogService _eventLogService;
        private readonly IEventBus _eventBus;
        public LevantamentoIntegrationEventService(
            LevantamentoContext levantamentoContext,
            Func<DbConnection, IIntegrationEventLogService> integrationEventLogServiceFactory,
            IEventBus eventBus)
        {
            _levantamentoContext = levantamentoContext;
            _integrationEventLogServiceFactory = integrationEventLogServiceFactory ?? throw new ArgumentNullException(nameof(integrationEventLogServiceFactory));
            _eventLogService = _integrationEventLogServiceFactory(_levantamentoContext.Database.GetDbConnection());
            _eventBus = eventBus ?? throw new ArgumentNullException(nameof(eventBus));
        }
        public Task AddAndSaveEventAsync(IntegrationEvent evt)
        {
            return _eventLogService.SaveEventAsync(evt, _levantamentoContext.GetCurrentTransaction());
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
        public void PublishEventAsync(IntegrationEvent evt)
        {
            _eventBus.Publish(evt);
        }
    }
}
