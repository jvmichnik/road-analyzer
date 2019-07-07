using Levantamento.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Levantamentos
{
    public abstract class LevantamentoCommand : Command
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public DateTime Start { get; protected set; }
        public DateTime? End { get; protected set; }
    }
}
