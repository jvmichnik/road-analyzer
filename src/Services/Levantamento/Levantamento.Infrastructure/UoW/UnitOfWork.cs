using Levantamento.Domain.Core.Interfaces;
using Levantamento.Infrastructure.Context;

namespace Levantamento.Infrastructure.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LevantamentoContext _context;

        public UnitOfWork(LevantamentoContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            var changeAmount = _context.SaveChanges();

            return changeAmount > 0;
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
