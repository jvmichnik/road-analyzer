using IntegrationEventLogEF;
using Levantamento.Domain.Core.Notifications;
using Levantamento.Infrastructure.Sql.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Levantamento.Api.Infrastructure.DesignFactoryMigration
{
    public class IntegrationEventLogContextDesignTimeFactory : IDesignTimeDbContextFactory<IntegrationEventLogContext>
    {
        public IntegrationEventLogContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IntegrationEventLogContext>();

            optionsBuilder.UseSqlServer(".", options => options.MigrationsAssembly(GetType().Assembly.GetName().Name));

            return new IntegrationEventLogContext(optionsBuilder.Options);
        }
    }
    public class LevantamentoContextDesignFactory : IDesignTimeDbContextFactory<LevantamentoContext>
    {
        public LevantamentoContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<LevantamentoContext>()
                .UseSqlServer(".", options => options.MigrationsAssembly(GetType().Assembly.GetName().Name));

            return new LevantamentoContext(optionsBuilder.Options, new NoMediator(),new DomainNotificationHandler());
        }

        class NoMediator : IMediator
        {
            public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default(CancellationToken)) where TNotification : INotification
            {
                return Task.CompletedTask;
            }

            public Task Publish(object notification, CancellationToken cancellationToken = default)
            {
                throw new NotImplementedException();
            }

            public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.FromResult<TResponse>(default(TResponse));
            }

            public Task Send(IRequest request, CancellationToken cancellationToken = default(CancellationToken))
            {
                return Task.CompletedTask;
            }
        }
    }
}
