using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Trecho.Api.Models
{
    public class TrechoDTO
    {
        public TrechoDTO(Guid id, string name, string description, DateTime start)
        {
            Id = id;
            Name = name;
            Description = description;
            Start = start;

        }
        public TrechoDTO(Guid id, string name, string description, DateTime start, DateTime end)
        {
            Id = id;
            Name = name;
            Description = description;
            Start = start;
            End = end;

            Logs = new List<LogDTO>();
        }
        public Guid Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? End { get; private set; }

        public List<LogDTO> Logs { get; private set; }

        public void AddLog(Guid id, decimal @long, decimal lat, decimal rate, int speed, DateTime dateOccurred)
        {
            var log = new LogDTO(id, @long, lat, rate, speed, dateOccurred);
            Logs.Add(log);
        }
    }
}
