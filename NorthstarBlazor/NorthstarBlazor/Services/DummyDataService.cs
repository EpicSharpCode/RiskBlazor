using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using NorthstarBlazor.Client.Services;
using Shares.Models;
using Shares.Services;
using System.Reflection;

namespace NorthstarBlazor.Services
{
    public class DummyDataService : IDataProvider
    {
        private readonly ILogger<DataProvider> _logger;

        public DummyDataService(ILogger<DataProvider> logger)
        {
            this._logger = logger;
        }
        public async Task<List<General>> GetGeneral() => await GetData<General>("NorthstarBlazor.Services.General.json");
        public async Task<List<Holding>> GetHolding() => await GetData<Holding>("NorthstarBlazor.Services.Holding.json");
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
