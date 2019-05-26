using Autofac;
using FluentValidation;
using Levantamento.Api.Application.Commands.Levantamentos.Create;
using Levantamento.Domain.Core.Behavior;
using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Commands;
using Levantamento.Domain.Core.Interfaces;
using Levantamento.Domain.Core.Notifications;
using Levantamento.Infrastructure.Bus;
using Levantamento.Infrastructure.Context;
using Levantamento.Infrastructure.Repository;
using Levantamento.Infrastructure.UoW;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Levantamento.Api.Infrastructure.AutofacModules
{
    public class ApplicationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LevantamentoContext>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CreateLevantamentoCommand).GetTypeInfo().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterAssemblyTypes(typeof(LevantamentoRepository).GetTypeInfo().Assembly)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(typeof(CreateLevantamentoCommandValidation).GetTypeInfo().Assembly)
                .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                .AsImplementedInterfaces();

            builder.RegisterType<InMemoryBus>()
                .As<IMediatorHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DomainNotificationHandler>()
                .As<INotificationHandler<DomainNotification>>()
                .InstancePerLifetimeScope();

            builder.Register<ServiceFactory>(context =>
            {
                var componentContext = context.Resolve<IComponentContext>();
                return t => { object o; return componentContext.TryResolve(t, out o) ? o : null; };
            });

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
