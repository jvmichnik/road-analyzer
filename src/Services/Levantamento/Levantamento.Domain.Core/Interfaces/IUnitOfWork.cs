using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Domain.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
