using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Levantamento.Infrastructure.Context;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Infrastructure.Repository
{
    public class LevantamentoRepository : ILevantamentoRepository
    {
        private readonly ILevantamentoContext _context;
        private readonly IMongoCollection<LevantamentoRoot> db;

        public LevantamentoRepository(IOptions<DataSettings> settings)
        {
            _context = new LevantamentoContext(settings);
            var teste = _context.GetCollection<LevantamentoRoot>("Levantamento");
        }

        public async Task<IEnumerable<LevantamentoRoot>> GetLevantamentosAsync()
        {
            return await db.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddLevantamentoAsync(LevantamentoRoot levantamento)
        {
            await _context.AddCommand(() => db.InsertOneAsync(levantamento));            
        }

        public async Task UpdateLevantamentoAsync(LevantamentoRoot levantamento)
        {
            await _context.AddCommand(() => db.ReplaceOneAsync(x => x.Id == levantamento.Id, levantamento, new UpdateOptions { IsUpsert = true }));
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
