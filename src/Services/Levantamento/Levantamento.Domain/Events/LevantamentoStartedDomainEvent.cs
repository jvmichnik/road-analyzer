using Levantamento.Domain.Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Domain.Events
{
    public class LevantamentoStartedDomainEvent : Event
    {
        public LevantamentoStartedDomainEvent(Guid id, string name, string description, DateTime start)
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
