using Levantamento.Domain.AggregatesModel.Exceptions;
using Levantamento.Domain.Core.Models;
using Levantamento.Domain.Events;
using System;

namespace Levantamento.Domain.AggregatesModel.LevantamentoAggregate
{
    public class Log : Entity
    {
        public decimal Long { get; private set; }
        public decimal Lat { get; private set; }
        public decimal Rate { get; private set; }
        public int Speed { get; private set; }
        public DateTime DateOccurred { get; private set; }
        public Guid LevantamentoId { get; private set; }
        public virtual Levantamentos Levantamento { get; private set; }
        protected Log() { }
        public Log(Guid levantamentoId, decimal @long, decimal lat, decimal rate, int speed, DateTime dateOccurred)
        {
            Id = Guid.NewGuid();
            LevantamentoId = levantamentoId;
            Long = @long;
            Lat = lat;
            Rate = rate;
            Speed = speed >= 0 ? speed : throw new LevantamentoDomainException(nameof(speed));
            DateOccurred = dateOccurred;

            AddLogCreatedDomainEvent(Id, LevantamentoId, Long, Lat, Rate, Speed, DateOccurred);
        }

        private void AddLogCreatedDomainEvent(Guid id, Guid levantamentoId, decimal @long, decimal lat, decimal rate, int speed, DateTime dateOccurred)
        {
            var logCreatedDomainEvent = new LogCreatedDomainEvent(id, levantamentoId, @long, lat, rate, speed, dateOccurred);

            this.AddDomainEvent(logCreatedDomainEvent);
        }
    }
}
