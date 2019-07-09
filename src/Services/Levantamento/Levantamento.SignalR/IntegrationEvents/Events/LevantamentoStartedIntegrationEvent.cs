using System;
using ZEventBus.Events;

namespace Levantamento.SignalR.IntegrationEvents.Events
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
        public Guid Id { get;}
        public string Name { get; }
        public string Description { get; }
        public DateTime Start { get; }
    }
}
