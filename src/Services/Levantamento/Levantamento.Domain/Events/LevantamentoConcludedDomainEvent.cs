using Levantamento.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Domain.Events
{
    public class LevantamentoConcludedDomainEvent : Event
    {
        public LevantamentoConcludedDomainEvent(Guid id, string name, string description, DateTime start, DateTime end)
        {
            Id = id;
            Name = name;
            Description = description;
            Start = start;
            End = end;
        }

        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
    }
}
