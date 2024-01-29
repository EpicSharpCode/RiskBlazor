using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using RiskBlazor.Client.Services;
using Shares.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSingleton<IDataProvider, DataProvider>();
builder.Services.AddHttpClient("api", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));

await builder.Build().RunAsync();
