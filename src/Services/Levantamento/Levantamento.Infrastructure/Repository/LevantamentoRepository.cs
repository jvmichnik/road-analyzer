using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
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
        private readonly LevantamentoContext _context;

        public LevantamentoRepository(IOptions<DataSettings> settings)
        {
            _context = new LevantamentoContext(settings);
        }

        public async Task<IEnumerable<LevantamentoRoot>> GetLevantamentosAsync()
        {
            return await _context.Levantamentos.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddLevantamentoAsync(LevantamentoRoot levantamento)
        {
            await _context.Levantamentos.InsertOneAsync(levantamento);
        }

        public async Task UpdateLevantamentoAsync(LevantamentoRoot levantamento)
        {
            await _context.Levantamentos.ReplaceOneAsync(x => x.Id == levantamento.Id, levantamento, new UpdateOptions { IsUpsert = true });
        }
    }
}
