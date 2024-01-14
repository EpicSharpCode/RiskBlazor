using Newtonsoft.Json;

namespace Shares.Models;

public class Holding
{
    public string Symbol { get; set; }
    public object Price { get; set; }

    [JsonProperty("Chg %")]
    public string Chg { get; set; }
}
