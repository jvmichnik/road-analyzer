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
        private readonly LevantamentoContext _context;
        private readonly IMongoCollection<LevantamentoRoot> db;

        public LevantamentoRepository(LevantamentoContext context)
        {
            _context = context;
            db = _context.GetCollection<LevantamentoRoot>("Levantamento");
        }

        public async Task<IEnumerable<LevantamentoRoot>> GetLevantamentosAsync()
        {
            return await db.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddLevantamentoAsync(LevantamentoRoot levantamento)
        {
            await _context.Add(db,levantamento);            
        }

        public async Task UpdateLevantamentoAsync(LevantamentoRoot levantamento)
        {
            await _context.Update(db, levantamento,x => x.Id == levantamento.Id);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
