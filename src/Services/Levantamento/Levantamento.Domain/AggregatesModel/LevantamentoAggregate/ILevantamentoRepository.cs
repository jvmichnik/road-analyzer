using Levantamento.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Domain.AggregatesModel.LevantamentoAggregate
{
    public interface ILevantamentoRepository : IRepository<Levantamentos>
    {
        Task<IEnumerable<Levantamentos>> GetLevantamentosAsync();
        Task<Levantamentos> GetLevantamentoAsync(Guid id);
        Task<Levantamentos> GetLevantamentoLogsAsync(Guid id);
        Task AddLevantamentoAsync(Levantamentos levantamento);
        Task UpdateLevantamentoAsync(Levantamentos levantamento);
    }
}
