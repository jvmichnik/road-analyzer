using Levantamento.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Infrastructure.UoW
{
    public class UnitOfWork
    {
        private readonly ILevantamentoContext _context;

        public UnitOfWork(ILevantamentoContext context)
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
