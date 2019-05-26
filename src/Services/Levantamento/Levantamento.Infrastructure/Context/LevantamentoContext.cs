using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Infrastructure.Context
{
    public class LevantamentoContext
    {
        private readonly IMongoDatabase _database = null;
        private List<Func<Task>> _commands;

        public LevantamentoContext(IOptions<DataSettings> settings)
        {
            _commands = new List<Func<Task>>();

            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }
        public int SaveChanges()
        {
            var qtd = _commands.Count;
            foreach (var command in _commands)
            {
                command();
            }

            _commands.Clear();
            return qtd;
        }
        public Task AddCommand(Func<Task> func)
        {
            _commands.Add(func);
            return Task.CompletedTask;
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