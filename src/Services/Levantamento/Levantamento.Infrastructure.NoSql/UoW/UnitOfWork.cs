using Levantamento.Domain.Core.Interfaces;
using Levantamento.Infrastructure.Context;
using System.Threading;
using System.Threading.Tasks;

namespace Levantamento.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LevantamentoContext _context;

        public UnitOfWork(LevantamentoContext context)
        {
            _context = context;
        }
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var changeAmount = _context.SaveChanges();

            return Task.FromResult(changeAmount);
        }
        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            var changeAmount = _context.SaveEntities();

            return Task.FromResult(changeAmount > 0);
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
