using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZEventBus.Events;

namespace Levantamento.Api.Application.IntegrationEvents.Events.Levantamento
{
    public class LevantamentoStartedIntegrationEvent : IntegrationEvent
    {
        public LevantamentoStartedIntegrationEvent(Guid id, string name, string description, DateTime start)
        {
            Id = id;
            Name = name;
            Description = description;
            Start = start;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime Start { get; }
    }
}
