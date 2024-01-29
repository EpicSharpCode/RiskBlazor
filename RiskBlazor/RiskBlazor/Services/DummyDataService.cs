using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using RiskBlazor.Client.Services;
using Shares.Models;
using Shares.Services;
using System.Reflection;

namespace RiskBlazor.Services
{
    public class DummyDataService : IDataProvider
    {
        private readonly ILogger<DataProvider> _logger;

        public DummyDataService(ILogger<DataProvider> logger)
        {
            this._logger = logger;
        }
        public async Task<List<General>> GetGeneral() => await GetData<General>("RiskBlazor.Services.General.json");
        public async Task<List<Holding>> GetHolding() => await GetData<Holding>("RiskBlazor.Services.Holding.json");

        public async Task<List<ShareData>> GetShareData()
        {
            List<Holding> holdings = await GetHolding();
            List<General> generals = await GetGeneral();
            List<ShareData> data = new List<ShareData>();

            foreach (var holding in holdings)
            {
                if (data.Find(x => x.Symbol == holding.Symbol) != null || data.Find(x => x.Name == holding.Symbol) != null) continue;
                var sharedata = new ShareData() { Symbol = holding.Symbol, Name = holding.Symbol };
                data.Add(sharedata);
            }
            foreach (var general in generals)
            {
                if (data.Find(x => x.Symbol == general.Symbol) != null || data.Find(x => x.Name == general.Symbol) != null) continue;
                var sharedata = new ShareData() { Symbol = general.Symbol, Name = general.Symbol };
                data.Add(sharedata);
            }

            return data;
        }
        private async Task<List<T>> GetData<T>(string resourceName)
        {
            _logger.LogInformation("Reading Embedded File {resourceName}", resourceName);
            await Task.Delay(1000);
            List<T> data = [];
            var assembly = Assembly.GetExecutingAssembly();
            string jsonString = null;
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream, true))
                    jsonString = reader.ReadToEnd();
            data = JsonConvert.DeserializeObject<List<T>>(jsonString);
            return data;
        }
    }
}
