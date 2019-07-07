using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trecho.Api.ServiceClient.Models
{
    public class LogDTO
    {
        public Guid Id { get; set; }
        public decimal Long { get; set; }
        public decimal Lat { get; set; }
        public decimal Rate { get; set; }
        public int Speed { get; set; }
        public DateTime DateOccurred { get; set; }
        public Guid LevantamentoId { get; set; }
    }
}
