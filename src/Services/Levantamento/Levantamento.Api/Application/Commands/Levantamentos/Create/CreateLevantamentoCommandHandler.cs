using Levantamento.Api.Application.Commands.Levantamentos.Create.DTO;
using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Commands;
using Levantamento.Domain.Core.Interfaces;
using Levantamento.Domain.Core.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Levantamentos.Create
{
    public class CreateLevantamentoCommandHandler : 
        CommandHandler,
        IRequestHandler<CreateLevantamentoCommand, CreateLeventamentoResponse>
    {
        private readonly ILevantamentoRepository _levantamentoRepository;
        private readonly IMediatorHandler Bus;
        private readonly IUnitOfWork _uow;
        public CreateLevantamentoCommandHandler(
            ILevantamentoRepository levantamentoRepository,
            IUnitOfWork uow,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications
            ) :base(uow, bus, notifications)
        {
            _uow = uow;
            _levantamentoRepository = levantamentoRepository;
            Bus = bus;
        }

        public async Task<CreateLeventamentoResponse> Handle(CreateLevantamentoCommand request, CancellationToken cancellationToken)
        {
            var levantamento = new LevantamentoRoot(request.Name,request.Description);

            await _levantamentoRepository.AddLevantamentoAsync(levantamento);

            if (await _uow.SaveEntitiesAsync())
            {
                return new CreateLeventamentoResponse
                {
                    Id = levantamento.Id,
                    Name = levantamento.Name,
                    Description = levantamento.Description,
                    StartedAt = levantamento.Start
                };
            }
            return new CreateLeventamentoResponse();
        }
    }
}
