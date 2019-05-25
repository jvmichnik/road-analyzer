using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Infrastructure
{
    public class LevantamentoContext
    {
        private readonly IMongoDatabase _database = null;

        public LevantamentoContext(IOptions<DataSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            if (client != null)
                _database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoCollection<LevantamentoRoot> Levantamentos
        {
            get
            {
                return _database.GetCollection<LevantamentoRoot>("Levantamentos");
            }
        }
    }
}