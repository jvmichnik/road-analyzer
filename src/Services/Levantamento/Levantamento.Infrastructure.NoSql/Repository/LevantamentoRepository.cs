using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Levantamento.Domain.Core.Interfaces;
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
        private readonly IMongoCollection<Domain.AggregatesModel.LevantamentoAggregate.Levantamentos> db;

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public LevantamentoRepository(LevantamentoContext context)
        {
            _context = context;
            db = _context.GetCollection<Domain.AggregatesModel.LevantamentoAggregate.Levantamentos>("Levantamento");
        }

        public async Task<IEnumerable<Domain.AggregatesModel.LevantamentoAggregate.Levantamentos>> GetLevantamentosAsync()
        {
            return await db.Find(new BsonDocument()).ToListAsync();
        }

        public async Task AddLevantamentoAsync(Domain.AggregatesModel.LevantamentoAggregate.Levantamentos levantamento)
        {
            await _context.Add(db,levantamento);            
        }

        public async Task UpdateLevantamentoAsync(Domain.AggregatesModel.LevantamentoAggregate.Levantamentos levantamento)
        {
            await _context.Update(db, levantamento,x => x.Id == levantamento.Id);
        }
        public void Dispose()
        {
            _context?.Dispose();
        }

        public Task<Domain.AggregatesModel.LevantamentoAggregate.Levantamentos> GetLevantamentoAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Levantamentos> GetLevantamentoLogsAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
