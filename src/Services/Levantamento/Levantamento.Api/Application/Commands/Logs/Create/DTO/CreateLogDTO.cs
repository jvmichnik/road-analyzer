using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Logs.Create.DTO
{
    public class CreateLogDTO
    {
        public decimal Long { get; set; }
        public decimal Lat { get; set; }
        public decimal Rate { get; set; }
        public int Speed { get; set; }
        public DateTime DateOccurred { get; set; }
    }
}
