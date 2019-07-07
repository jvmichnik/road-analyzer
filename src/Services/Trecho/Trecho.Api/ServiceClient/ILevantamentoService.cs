using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trecho.Api.ServiceClient.Models;

namespace Trecho.Api.ServiceClient
{
    public interface ILevantamentoService
    {
        Task<TrechoDTO> GetLogs(Guid idLevantamento);
    }
}
