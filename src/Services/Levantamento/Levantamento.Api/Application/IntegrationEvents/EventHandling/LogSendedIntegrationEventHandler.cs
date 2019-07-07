using Levantamento.Api.Application.IntegrationEvents.Events.Logs;
using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZEventBus.Abstractions;

namespace Levantamento.Api.Application.IntegrationEvents.EventHandling
{
    public class LogSendedIntegrationEventHandler :
        IIntegrationEventHandler<LogSendedIntegrationEvent>
    {
        private readonly ILevantamentoRepository _levantamentoRepository;
        public LogSendedIntegrationEventHandler(
            ILevantamentoRepository levantamentoRepository
            ) 
        {
            _levantamentoRepository = levantamentoRepository;
        }
        public async Task Handle(LogSendedIntegrationEvent @event)
        {
            var log = new Log(@event.LevantamentoId, @event.Long, @event.Lat, @event.Rate, @event.Speed, @event.DateOccurred);
            var levantamento = await _levantamentoRepository.GetLevantamentoAsync(@event.LevantamentoId);

            if (levantamento == null)
            {
                //save log
                return;
            }
            if (levantamento.IsClosed())
            {
                //save log
                return;
            }
            if (levantamento.Start.CompareTo(log.DateOccurred) > 0)
            {
                //save log
                return;
            }
            if (levantamento.LastLog != null && levantamento.LastLog.DateOccurred.CompareTo(log.DateOccurred) >= 0)
            {
                //save log
                return;
            }

            levantamento.AddLog(log);

            await _levantamentoRepository.UnitOfWork.SaveEntitiesAsync();

        }
    }
}
