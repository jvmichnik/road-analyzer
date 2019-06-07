using Levantamento.Api.Application.IntegrationEvents;
using Levantamento.Domain.Core.Commands;
using Levantamento.Domain.Core.Events;
using Levantamento.Infrastructure.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Behavior
{
    public class TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILevantamentoIntegrationEventService _levantamentoIntegrationEventService;
        private readonly LevantamentoContext _context;
        public TransactionBehaviour(ILevantamentoIntegrationEventService levantamentoIntegrationEventService, LevantamentoContext context)
        {
            _levantamentoIntegrationEventService = levantamentoIntegrationEventService ?? throw new ArgumentException(nameof(levantamentoIntegrationEventService));
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if(_context.HasActiveTransaction())
            {
                return await next();
            }

            var response = default(TResponse);

            response = await next();

            await _levantamentoIntegrationEventService.PublishEventsThroughEventBusAsync(_context.TransactionId);

            return response;
        }
    }
}
