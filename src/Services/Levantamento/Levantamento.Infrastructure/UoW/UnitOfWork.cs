using Levantamento.Domain.Core.Interfaces;
using Levantamento.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
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
