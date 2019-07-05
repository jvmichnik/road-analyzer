using Levantamento.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Levantamento.Domain.Core.Interfaces
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
