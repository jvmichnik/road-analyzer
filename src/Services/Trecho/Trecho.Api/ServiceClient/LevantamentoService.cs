using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Trecho.Api.ServiceClient.Models;

namespace Trecho.Api.ServiceClient
{
    public class LevantamentoService : ILevantamentoService
    {
        private readonly HttpClient _apiClient;
        private readonly DataSettings _settings;
        public LevantamentoService(HttpClient httpClient, IOptions<DataSettings> settings)
        {
            _apiClient = httpClient;
            _settings = settings.Value;
        }
        public async Task<TrechoDTO> GetLogs(Guid idLevantamento)
        {
            var uri = $"{_settings.LevantamentoApi}/api/levantamentos/{idLevantamento}/logs";
            var responseString = await _apiClient.GetStringAsync(uri);

            return string.IsNullOrEmpty(responseString) ?
                new TrechoDTO() :
                JsonConvert.DeserializeObject<TrechoDTO>(responseString);
        }
    }
}
