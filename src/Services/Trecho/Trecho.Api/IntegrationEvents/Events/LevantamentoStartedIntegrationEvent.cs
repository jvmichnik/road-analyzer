using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZEventBus.Events;

namespace Trecho.Api.IntegrationEvents.Events
{
    public class LevantamentoStartedIntegrationEvent : IntegrationEvent
    {
        public LevantamentoStartedIntegrationEvent(Guid id,string name, string description, DateTime start)
        {
            Id = id;
            Name = name;
            Description = description;
            Start = start;
        }
        public Guid Id { get; set; }
        public string Name { get; }
        public string Description { get; }
        public DateTime Start { get; }
    }
}
