using Levantamento.Api.Application.Commands.Levantamentos.Conclude.DTO;
using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Commands;
using Levantamento.Domain.Core.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Levantamento.Api.Application.Commands.Levantamentos.Conclude
{
    public class ConcludeLevantamentoCommandHandler :
        CommandHandler,
        IRequestHandler<ConcludeLevantamentoCommand, ConcludeLeventamentoResponse>
    {
        private readonly ILevantamentoRepository _levantamentoRepository;
        private readonly IMediatorHandler Bus;
        public ConcludeLevantamentoCommandHandler(
            ILevantamentoRepository levantamentoRepository,
            IMediatorHandler bus,
            INotificationHandler<DomainNotification> notifications
            ) : base(bus, notifications)
        {
            _levantamentoRepository = levantamentoRepository;
            Bus = bus;
        }

        public async Task<ConcludeLeventamentoResponse> Handle(ConcludeLevantamentoCommand request, CancellationToken cancellationToken)
        {
            var levantamento = await _levantamentoRepository.GetLevantamentoAsync(request.Id);
            if (levantamento == null)
            {
                Notify("levantamento", "Levantamento não encontrado.");
                return new ConcludeLeventamentoResponse();
            }
            if (levantamento.IsClosed())
            {
                Notify("levantamento", "Levantamento já está finalizado.");
                return new ConcludeLeventamentoResponse();
            }
            if (request.End <= levantamento.Start)
            {
                Notify("concluded", "A Data de Término deve ser maior que a Data de Inicio.");
                return new ConcludeLeventamentoResponse();
            }

            if (levantamento.LastLog != null && levantamento.LastLog.DateOccurred > request.End)
            {
                Notify("levantamento", "Data de Conclusão menor que ultimo log.");
                return new ConcludeLeventamentoResponse();
            }

            levantamento.SetConcluded(request.End);

            await _levantamentoRepository.UpdateLevantamentoAsync(levantamento);

            if (await _levantamentoRepository.UnitOfWork.SaveEntitiesAsync())
            {
                return new ConcludeLeventamentoResponse
                {
                    Id = levantamento.Id,
                    Name = levantamento.Name,
                    Description = levantamento.Description,
                    StartedAt = levantamento.Start,
                    FinishedAt = levantamento.End
                };
            }
            return new ConcludeLeventamentoResponse();
        }
    }
}
