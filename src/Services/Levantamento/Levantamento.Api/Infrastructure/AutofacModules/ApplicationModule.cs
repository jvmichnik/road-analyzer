using Autofac;
using Levantamento.Api.Application.Commands.Levantamentos.Create;
using Levantamento.Domain.Core.Behavior;
using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Commands;
using Levantamento.Infrastructure.Bus;
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
            builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly)
                .AsImplementedInterfaces();

            builder.RegisterAssemblyTypes(typeof(CreateLevantamentoCommand).GetTypeInfo().Assembly)
                    .AsClosedTypesOf(typeof(IRequestHandler<,>));

            builder.RegisterType<InMemoryBus>()
                .As<IMediatorHandler>()
                .InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
