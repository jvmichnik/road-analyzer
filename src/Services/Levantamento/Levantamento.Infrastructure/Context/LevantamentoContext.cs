using IntegrationEventLog;
using Levantamento.Domain.Core.Bus;
using Levantamento.Domain.Core.Events;
using Levantamento.Domain.Core.Models;
using MediatR;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Levantamento.Infrastructure.Context
{
    public class LevantamentoContext
    {
        private readonly IMongoDatabase _database = null;
        private IMediatorHandler _bus;
        private List<Func<Task>> _commands;
        private List<Event> _events;

        public LevantamentoContext(IOptions<DataSettings> settings, IMediatorHandler bus)
        {
            _bus = bus ?? throw new ArgumentNullException(nameof(bus));

            _commands = new List<Func<Task>>();
            _events = new List<Event>();

            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);

            TransactionId = Guid.NewGuid();
        }
        public Guid TransactionId { get; }
        public int SaveChanges()
        {
            var qtd = _commands.Count;
            foreach (var ev in _events)
            {
                _bus.RaiseEvent(ev);
            }
            _events.Clear();
            foreach (var command in _commands)
            {
                command();
            }

            _commands.Clear();
            return qtd;
        }       

        public bool HasActiveTransaction()
        {
            return _commands.Any();
        }

        public Task Add<T>(IMongoCollection<T> mongoCollection, T entity) where T : Entity
        {
            AddCommand(entity, () => mongoCollection.InsertOneAsync(entity));
            return Task.CompletedTask;
        }

        public Task Update<T>(IMongoCollection<T> mongoCollection, T entity, Expression<Func<T, bool>> filter) where T : Entity
        {
            AddCommand(entity, () => mongoCollection.ReplaceOneAsync(filter, entity, new UpdateOptions { IsUpsert = true }));
            return Task.CompletedTask;
        }

        private void AddCommand<T>(T entity, Func<Task> func) where T : Entity
        {
            _events.AddRange(entity.DomainEvents);
            _commands.Add(func);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}