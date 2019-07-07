using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trecho.Api.IntegrationEvents.Events;
using Trecho.Api.Models;
using Trecho.Api.ServiceClient;
using ZEventBus.Abstractions;

namespace Trecho.Api.IntegrationEvents.EventHandling
{
    public class LevantamentoConcludedIntegrationEventHandler :
        IIntegrationEventHandler<LevantamentoConcludedIntegrationEvent>
    {
        private readonly IMongoDatabase _database = null;
        private readonly ILevantamentoService _apiClient;
        public LevantamentoConcludedIntegrationEventHandler(IOptions<DataSettings> settings, ILevantamentoService apiClient)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));

            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }

        public async Task Handle(LevantamentoConcludedIntegrationEvent @event)
        {

            var trecho = new TrechoDTO(@event.Id, @event.Name, @event.Description, @event.Start, @event.End);
            var trechoRequest = await _apiClient.GetLogs(trecho.Id);

            foreach (var log in trechoRequest.Logs)
            {
                trecho.AddLog(log.Id, log.Long, log.Lat, log.Rate, log.Speed, log.DateOccurred);
            }

            await _database.GetCollection<TrechoDTO>("Trecho").ReplaceOneAsync(x => x.Id == trecho.Id,trecho, new UpdateOptions { IsUpsert = true });
        }
    }
}
