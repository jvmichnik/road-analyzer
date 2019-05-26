using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Commands;
using Levantamento.Domain.Core.Interfaces;
using Levantamento.Domain.Core.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Levantamento.Domain.Core.Behavior
{
    public class ValidatorBehavior<TRequest, TResponse> : CommandHandler, IPipelineBehavior<TRequest, TResponse>
    {
        public ValidatorBehavior(IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if ((request is Command))
            {
                var command = request as Command;
                if (!command.IsValid())
                {
                    NotifyValidationErrors(command);
                    return default;
                }
            }

            return await next();
        }
    }
}
