using Levantamento.Domain.Core.Models;
using Levantamento.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Levantamento.Domain.AggregatesModel.LevantamentoAggregate
{
    public class Levantamentos : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime? End { get; private set; }

        private readonly List<Log> _logs;

        public IReadOnlyCollection<Log> Logs => _logs;
        public Log LastLog => _logs.OrderByDescending(x => x.DateOccurred).FirstOrDefault();
        public Levantamentos(string name, string description, DateTime start)
        {
            Id = Guid.NewGuid();
            Name = !string.IsNullOrWhiteSpace(name) ? name : throw new ArgumentNullException(nameof(name));
            Description = description;
            Start = start;

            AddLevantamentoStartedDomainEvent(Id, Name, Description, Start);
            _logs = new List<Log>();
        }
        protected Levantamentos()
        {
            _logs = new List<Log>();
        }
        public void AddLog(Log log)
        {
            if (IsClosed())
                throw new ArgumentOutOfRangeException("concluded", "Levantamento já está concluido.");

            if (LastLog != null && LastLog.DateOccurred.CompareTo(log.DateOccurred) >= 0)
                throw new ArgumentOutOfRangeException("ocorrencia", "Data de Ocorrência não deve ser menor que a Data de Ocorrência do Log anterior.");

            if (Start.CompareTo(log.DateOccurred) > 0)
                throw new ArgumentOutOfRangeException("ocorrencia", "Data de Ocorrência não deve ser  menor que a Data de Início do Levantamento.");

            _logs.Add(log);
        }
        public void SetConcluded(DateTime? end)
        {
            if (IsClosed() || !end.HasValue) 
                throw new ArgumentOutOfRangeException("concluded", "Levantamento já está concluido.");

            if(Start.CompareTo(end.Value) >= 0)
                throw new ArgumentOutOfRangeException("concluded", "A Data de Término deve ser maior que a Data de Inicio.");

            if (LastLog != null && LastLog.DateOccurred.CompareTo(end.Value) > 0)
                throw new ArgumentOutOfRangeException("concluded", "Data de Conclusão menor que ultimo log.");

            End = end;

            AddLevantamentoConcludedDomainEvent(Id, Name, Description, Start, End.Value);
        }
        public bool IsClosed()
        {
            return End.HasValue;
        }
        private void AddLevantamentoStartedDomainEvent(Guid id, string name, string description, DateTime start)
        {
            var orderStartedDomainEvent = new LevantamentoStartedDomainEvent(id, name, description, start);

            this.AddDomainEvent(orderStartedDomainEvent);
        }
        private void AddLevantamentoConcludedDomainEvent(Guid id, string name, string description, DateTime start, DateTime end)
        {
            var orderConcludedDomainEvent = new LevantamentoConcludedDomainEvent(id, name, description, start, end);

            this.AddDomainEvent(orderConcludedDomainEvent);
        }
    }
}
