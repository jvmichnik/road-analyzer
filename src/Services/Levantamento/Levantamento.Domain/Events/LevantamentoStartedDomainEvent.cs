using Levantamento.Domain.Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Domain.Events
{
    public class LevantamentoStartedDomainEvent : Event
    {
        public LevantamentoStartedDomainEvent(string name, string description, DateTime start)
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
