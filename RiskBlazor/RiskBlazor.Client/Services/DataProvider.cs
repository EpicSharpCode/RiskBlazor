using Shares.Models;
using Shares.Services;
using System.Net.Http;
using System.Net.Http.Json;

namespace RiskBlazor.Client.Services
{
    public class DataProvider : IDataProvider
    {
        private readonly ILogger<DataProvider> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        public DataProvider(ILogger<DataProvider> logger, IHttpClientFactory httpClientFactory)
        {
            this._logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<General>> GetGeneral()
        {
            var http = _httpClientFactory.CreateClient("api");
            var result = await http.GetAsync("api/data/general");
            var response = await result.Content.ReadFromJsonAsync<List<General>>();
            return response;
        }
        public async Task<List<Holding>> GetHolding()
        {
            var http = _httpClientFactory.CreateClient("api");
            var result = await http.GetAsync("api/data/holding");
            var response = await result.Content.ReadFromJsonAsync<List<Holding>>();

            return response;
        }

        public async Task<List<ShareData>> GetShareData()
        {
            var http = _httpClientFactory.CreateClient("api");
            var result = await http.GetAsync("api/data/sharedata");
            var response = await result.Content.ReadFromJsonAsync<List<ShareData>>();

            return response;
        }
    }
}
