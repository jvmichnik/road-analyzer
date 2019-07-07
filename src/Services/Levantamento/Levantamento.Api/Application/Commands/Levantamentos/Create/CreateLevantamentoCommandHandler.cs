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
        public CreateLevantamentoCommandHandler(
            ILevantamentoRepository levantamentoRepository,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications
            ) :base(bus, notifications)
        {
            _levantamentoRepository = levantamentoRepository;
            Bus = bus;
        }

        public async Task<CreateLeventamentoResponse> Handle(CreateLevantamentoCommand request, CancellationToken cancellationToken)
        {
            var levantamento = new Domain.AggregatesModel.LevantamentoAggregate.Levantamentos(request.Name, request.Description, request.Start);

            await _levantamentoRepository.AddLevantamentoAsync(levantamento);

            if (await _levantamentoRepository.UnitOfWork.SaveEntitiesAsync())
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
