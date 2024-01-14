using Newtonsoft.Json;


namespace Shares.Models;

public class General
{
    public string Symbol { get; set; }
    public object Price { get; set; }

    [JsonProperty("Chg")]
    public string Chg { get; set; }
    public string Volume { get; set; }

    [JsonProperty("Afterhr. Price")]
    public object AfterhrPrice { get; set; }

    [JsonProperty("Afterhr. % Change")]
    public string AfterhrChange { get; set; }

    [JsonProperty("Market Cap")]
    public string MarketCap { get; set; }

    [JsonProperty("PE Ratio")]
    public object PERatio { get; set; }

    [JsonProperty("Earnings Date")]
    public string EarningsDate { get; set; }

    [JsonProperty("% Chg 52w Low")]
    public string Chg52wLow { get; set; }

    [JsonProperty("% Chg 52w High")]
    public string Chg52wHigh { get; set; }
}
