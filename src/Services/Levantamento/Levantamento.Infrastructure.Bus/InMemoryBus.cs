using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Commands;
using Levantamento.Domain.Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Infrastructure.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task PublishCommand<T>(T command) where T : Command
        {
            await Publish(command);
        }

        public async Task<TResponse> SendCommand<TResponse>(IRequest<TResponse> request)
        {
            return await Send(request);
        }

        public async Task RaiseEvent<T>(T @event) where T : Event
        {
            await Publish(@event);
        }


        private Task Publish<Tevent>(Tevent message) where Tevent : Message
        {
            return _mediator.Publish(message);
        }
        private Task<TResponse> Send<TResponse>(IRequest<TResponse> command)
        {
            return _mediator.Send(command);
        }
    }
}
