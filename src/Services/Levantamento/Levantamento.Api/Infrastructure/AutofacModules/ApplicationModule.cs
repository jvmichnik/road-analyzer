using Autofac;
using FluentValidation;
using IntegrationEventLogMongo.Services;
using Levantamento.Api.Application.Behavior;
using Levantamento.Api.Application.Commands.Levantamentos.Create;
using Levantamento.Api.Application.DomainEventHandlers.LevantamentoStarted;
using Levantamento.Api.Application.IntegrationEvents;
using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Interfaces;
using Levantamento.Domain.Core.Notifications;
using Levantamento.Infrastructure.Bus;
using Levantamento.Infrastructure.Context;
using Levantamento.Infrastructure.UoW;
using MediatR;
using System.Linq;
using System.Reflection;

namespace Levantamento.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterEF(builder);
            //RegisterMongo(builder);

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CreateLevantamentoCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));


            builder.RegisterAssemblyTypes(typeof(LevantamentoStartedDomainEventHandler).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(INotificationHandler<>));

            builder
                .RegisterAssemblyTypes(typeof(CreateLevantamentoCommandValidation).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.RegisterType<InMemoryBus>()
                .As<IMediatorHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DomainNotificationHandler>()
                .As<INotificationHandler<DomainNotification>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<LevantamentoIntegrationEventService>()
                .As<ILevantamentoIntegrationEventService>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(TransactionBehaviourSql<,>)).As(typeof(IPipelineBehavior<,>));
        }

        public void RegisterEF(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(Levantamento.Infrastructure.Sql.Repositories.LevantamentoRepository).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
        public void RegisterMongo(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<Levantamento.Infrastructure.Context.LevantamentoContext>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(Levantamento.Infrastructure.Repository.LevantamentoRepository).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
