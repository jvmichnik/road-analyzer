using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZEventBus.Events;

namespace Levantamento.Api.Application.IntegrationEvents.Events.Levantamento
{
    public class EventStartedIntegrationEvent : IntegrationEvent
    {
        public EventStartedIntegrationEvent(string name, string description, DateTime start)
        {
            Name = name;
            Description = description;
            Start = start;
        }

        public string Name { get; }
        public string Description { get; }
        public DateTime Start { get; }
    }
}
