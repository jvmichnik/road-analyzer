using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trecho.Api.IntegrationEvents.Events;
using Trecho.Api.Models;
using ZEventBus.Abstractions;

namespace Trecho.Api.IntegrationEvents.EventHandling
{
    public class LevantamentoStartedIntegrationEventHandler :
        IIntegrationEventHandler<LevantamentoStartedIntegrationEvent>
    {
        private readonly IEventBus _eventBus;
        private readonly IMongoDatabase _database = null;
        public LevantamentoStartedIntegrationEventHandler(IOptions<DataSettings> settings,IEventBus eventBus)
        {
            _eventBus = eventBus;


            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public async Task Handle(LevantamentoStartedIntegrationEvent @event)
        {
            var trecho = new TrechoDTO(@event.Id, @event.Name, @event.Description, @event.Start);

           await _database.GetCollection<TrechoDTO>("Trecho").InsertOneAsync(trecho);
        }
    }
}
