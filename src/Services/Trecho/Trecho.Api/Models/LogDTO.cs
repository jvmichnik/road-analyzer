using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trecho.Api.Models
{
    public class LogDTO
    {
        public LogDTO(Guid id, decimal @long, decimal lat, decimal rate, int speed, DateTime dateOccurred)
        {
            Id = id;
            Long = @long;
            Lat = lat;
            Rate = rate;
            Speed = speed;
            DateOccurred = dateOccurred;
        }

        public Guid Id { get; private set; }
        public decimal Long { get; private set; }
        public decimal Lat { get; private set; }
        public decimal Rate { get; private set; }
        public int Speed { get; private set; }
        public DateTime DateOccurred { get; private set; }
    }
}
