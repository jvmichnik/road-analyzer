using Levantamento.Domain.AggregatesModel.LevantamentoAggregate;
using Levantamento.Domain.Core.Interfaces;
using Levantamento.Infrastructure.Sql.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Infrastructure.Sql.Repositories
{
    public class LevantamentoRepository : ILevantamentoRepository
    {
        private readonly LevantamentoContext _context;
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public LevantamentoRepository(LevantamentoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public Task AddLevantamentoAsync(Domain.AggregatesModel.LevantamentoAggregate.Levantamentos levantamento)
        {
            return _context.Levantamento.AddAsync(levantamento);
        }

        public Task<IEnumerable<Levantamentos>> GetLevantamentosAsync()
        {
            return Task.FromResult(_context.Levantamento.AsEnumerable());
        }

        public Task UpdateLevantamentoAsync(Domain.AggregatesModel.LevantamentoAggregate.Levantamentos levantamento)
        {
            _context.Entry(levantamento).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public async Task<Domain.AggregatesModel.LevantamentoAggregate.Levantamentos> GetLevantamentoAsync(Guid id)
        {
            var levantamento = await _context.Levantamento.FirstOrDefaultAsync(x => x.Id == id);
            if (levantamento != null)
            {
                _context.Entry(levantamento).Collection(x => x.Logs).Query().OrderByDescending(x => x.DateOccurred).Take(1).Load();
            }
            return levantamento;
        }

        public Task<Levantamentos> GetLevantamentoLogsAsync(Guid id)
        {
            return _context.Levantamento.Include(x => x.Logs).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
