using Levantamento.Domain.AggregatesModel.Exceptions;
using Levantamento.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Levantamento.Domain.AggregatesModel.LevantamentoAggregate
{
    public class LevantamentoRoot : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? End { get; private set; }

        private List<Log> _logs;
        public IReadOnlyCollection<Log> Logs => _logs.AsReadOnly();

        public LevantamentoRoot(string name, string description)
        {
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            Description = description;
            Start = DateTime.Now;
        }

    }
}
