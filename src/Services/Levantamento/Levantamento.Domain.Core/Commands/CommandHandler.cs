using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Interfaces;
using Levantamento.Domain.Core.Notifications;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Domain.Core.Commands
{
    public class CommandHandler
    {
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications)
        {
            _notifications = (DomainNotificationHandler)notifications;
            _bus = bus;
        }

        protected void NotifyValidationErrors(Command message)
        {
            foreach (var error in message.ValidationResult.Errors)
            {
                _bus.RaiseEvent(new DomainNotification(message.MessageType, error.ErrorMessage));
            }
        }

        //public async Task<bool> Commit()
        //{
        //    if (_notifications.HasNotifications()) return false;
        //    if (await _uow.SaveEntitiesAsync()) return true;

        //    await _bus.RaiseEvent(new DomainNotification("Commit", "We had a problem during saving your data."));
        //    return false;
        //}
    }
}
