using Levantamento.Domain.Core.Commands;
using Levantamento.Domain.Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task PublishCommand<T>(T command) where T : Command;
        Task<TResponse> SendCommand<TResponse>(IRequest<TResponse> command);
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
