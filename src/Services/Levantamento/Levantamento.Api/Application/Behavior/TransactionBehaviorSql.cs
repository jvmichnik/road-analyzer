using Levantamento.Api.Application.IntegrationEvents;
using Levantamento.Infrastructure.Sql.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ZEventBus.Extensions;

namespace Levantamento.Api.Application.Behavior
{
    public class TransactionBehaviourSql<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILevantamentoIntegrationEventService _levantamentoIntegrationEventService;
        private readonly LevantamentoContext _context;
        public TransactionBehaviourSql(ILevantamentoIntegrationEventService levantamentoIntegrationEventService, LevantamentoContext context)
        {
            _levantamentoIntegrationEventService = levantamentoIntegrationEventService ?? throw new ArgumentException(nameof(levantamentoIntegrationEventService));
            _context = context ?? throw new ArgumentException(nameof(context));
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var response = default(TResponse);
            var typeName = request.GetGenericTypeName();

            try
            {
                if (_context.HasActiveTransaction)
                {
                    return await next();
                }

                var strategy = _context.Database.CreateExecutionStrategy();

                await strategy.ExecuteAsync(async () =>
                {
                    Guid transactionId;

                    using (var transaction = await _context.BeginTransactionAsync())
                    {
                        response = await next();

                        await _context.CommitTransactionAsync(transaction);

                        transactionId = transaction.TransactionId;
                    }

                    await _levantamentoIntegrationEventService.PublishEventsThroughEventBusAsync(transactionId);
                });

                return response;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
