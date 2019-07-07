using Levantamento.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Domain.Events
{
    public class LogCreatedDomainEvent : Event
    {
        public LogCreatedDomainEvent(Guid id, Guid levantamentoId, decimal @long, decimal lat, decimal rate, int speed, DateTime dateOccurred)
        {
            Id = id;
            LevantamentoId = levantamentoId;
            Long = @long;
            Lat = lat;
            Rate = rate;
            Speed = speed;
            DateOccurred = dateOccurred;
        }

        public Guid Id { get; }
        public Guid LevantamentoId { get; }
        public decimal Long { get; }
        public decimal Lat { get; }
        public decimal Rate { get; }
        public int Speed { get; }
        public DateTime DateOccurred { get; }
    }
}
