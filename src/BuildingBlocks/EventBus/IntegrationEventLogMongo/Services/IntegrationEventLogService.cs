using IntegrationEventLog;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ZEventBus.Events;

namespace IntegrationEventLogMongo.Services
{
    public class IntegrationEventLogService : IIntegrationEventLogService
    {
        private readonly IMongoDatabase _database = null;
        private readonly List<Type> _eventTypes;

        public IntegrationEventLogService(string dbName, string connString)
        {
            var client = new MongoClient(connString);
            if (client != null)
                _database = client.GetDatabase(dbName);

            _eventTypes = Assembly.Load(Assembly.GetEntryAssembly().FullName)
                .GetTypes()
                .Where(t => t.Name.EndsWith(nameof(IntegrationEvent)))
                .ToList();
        }

        public async Task<IEnumerable<IntegrationEventLogEntry>> RetrieveEventLogsPendingToPublishAsync(Guid transactionId)
        {
            var response = await _database.GetCollection<IntegrationEventLogEntry>("IntegrationEventLogs")
                .Find(x => x.TransactionId == transactionId && x.State == EventStateEnum.NotPublished)
                .Sort("{CreationTime: 1}")
                .ToListAsync();

            return response.Select(y => y.DeserializeJsonContent(_eventTypes.Find(t => t.Name == y.EventTypeShortName)));            
        }

        public Task SaveEventAsync(IntegrationEvent @event, Guid transactionId)
        {

            var eventLogEntry = new IntegrationEventLogEntry(@event, transactionId);

            return _database.GetCollection<IntegrationEventLogEntry>("IntegrationEventLogs")
                .InsertOneAsync(eventLogEntry);
        }

        public Task MarkEventAsPublishedAsync(Guid eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.Published);
        }

        public Task MarkEventAsInProgressAsync(Guid eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.InProgress);
        }

        public Task MarkEventAsFailedAsync(Guid eventId)
        {
            return UpdateEventStatus(eventId, EventStateEnum.PublishedFailed);
        }

        private Task UpdateEventStatus(Guid eventId, EventStateEnum status)
        {
            var eventLogEntry = _database.GetCollection<IntegrationEventLogEntry>("IntegrationEventLogs")
                .Find(x => x.EventId == eventId)
                .FirstOrDefault();

            eventLogEntry.State = status;

            if(status == EventStateEnum.InProgress)
                eventLogEntry.TimesSent++;

            return _database.GetCollection<IntegrationEventLogEntry>("IntegrationEventLogs")
                .ReplaceOneAsync(x => x.EventId == eventId, eventLogEntry, new UpdateOptions { IsUpsert = true });

        }
    }
}
