using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Domain.AggregatesModel.LevantamentoAggregate
{
    public interface ILevantamentoRepository : IDisposable
    {
        Task<IEnumerable<LevantamentoRoot>> GetLevantamentosAsync();
        Task AddLevantamentoAsync(LevantamentoRoot levantamento);
        Task UpdateLevantamentoAsync(LevantamentoRoot levantamento);
    }
}
