using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZEventBus.Events;

namespace Levantamento.Api.Application.IntegrationEvents.Events.Logs
{
    public class LogSendedIntegrationEvent : IntegrationEvent
    {
        public LogSendedIntegrationEvent(Guid levantamentoId, decimal @long, decimal lat, decimal rate, int speed, DateTime dateOccurred)
        {
            LevantamentoId = levantamentoId;
            Long = @long;
            Lat = lat;
            Rate = rate;
            Speed = speed;
            DateOccurred = dateOccurred;
        }
        public Guid LevantamentoId { get; private set; }
        public decimal Long { get; private set; }
        public decimal Lat { get; private set; }
        public decimal Rate { get; private set; }
        public int Speed { get; private set; }
        public DateTime DateOccurred { get; private set; }
    }
}
