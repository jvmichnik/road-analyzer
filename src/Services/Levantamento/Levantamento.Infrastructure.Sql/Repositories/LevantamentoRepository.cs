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

        public Task AddLevantamentoAsync(LevantamentoRoot levantamento)
        {
            return _context.Levantamento.AddAsync(levantamento);
        }

        public Task<IEnumerable<LevantamentoRoot>> GetLevantamentosAsync()
        {
            return Task.FromResult(_context.Levantamento.AsEnumerable());
        }

        public Task UpdateLevantamentoAsync(LevantamentoRoot levantamento)
        {
            _context.Entry(levantamento).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
