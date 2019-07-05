using Levantamento.Domain.AggregatesModel.Exceptions;
using Levantamento.Domain.Core.Models;
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
        public Log(decimal @long, decimal lat, decimal rate, int speed, DateTime dateOccurred)
        {
            Long = @long;
            Lat = lat;
            Rate = rate;
            Speed = speed >= 0 ? speed : throw new LevantamentoDomainException(nameof(speed));
            DateOccurred = dateOccurred < DateTime.Now ? dateOccurred : throw new LevantamentoDomainException(nameof(dateOccurred));
        }
    }
}
