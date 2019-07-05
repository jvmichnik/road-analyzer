using Levantamento.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Domain.AggregatesModel.LevantamentoAggregate
{
    public interface ILevantamentoRepository : IRepository<LevantamentoRoot>
    {
        Task<IEnumerable<LevantamentoRoot>> GetLevantamentosAsync();
        Task AddLevantamentoAsync(LevantamentoRoot levantamento);
        Task UpdateLevantamentoAsync(LevantamentoRoot levantamento);
    }
}
