using Levantamento.Domain.Core.Commands;
using System;

namespace Levantamento.Api.Application.Commands.Logs
{
    public abstract class LogCommand : Command
    {
        public Guid Id { get; protected set; }
        public Guid LevantamentoId { get; protected set; }
        public decimal Long { get; protected set; }
        public decimal Lat { get; protected set; }
        public decimal Rate { get; protected set; }
        public int Speed { get; protected set; }
        public DateTime DateOccurred { get; protected set; }
    }
}
