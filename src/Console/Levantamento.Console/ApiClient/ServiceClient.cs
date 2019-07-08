using Levantamento.Consoles.ApiClient.Model;
using Levantamento.Consoles.ApiClient.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Levantamento.Consoles.ApiClient
{
    public class ServiceClient
    {
        private readonly HttpClient _apiClient;
        public ServiceClient(string urlBase)
        {
            _apiClient = new HttpClient();
            _apiClient.BaseAddress = new Uri(urlBase);
        }
        public async Task<HttpResponseMessage> CreateLevantamento(LevantamentoDTO levantamento)
        {
            var uri = $"api/l/levantamentos";

            return await _apiClient.PostAsJsonAsync(uri, levantamento);           
        }

        public async Task<HttpResponseMessage> ConcludeLevantamento(Guid levantamentoId)
        {
            var uri = $"api/l/levantamentos/{levantamentoId}/concluded";

            return await _apiClient.PutAsJsonAsync(uri, new { ConcludedAt = DateTime.Now });
        }

        public Task CreateLog(Guid levantamentoId, LogDTO log)
        {
            var uri = $"api/l/levantamentos/{levantamentoId}/logs";

            return _apiClient.PostAsJsonAsync(uri, log);
        }
    }
}
