using Newtonsoft.Json;

public class Response
{
    [JsonProperty("state")]
    public string State { get; set; }

    [JsonProperty("reply")]
    public string Reply { get; set; }
    
    [JsonProperty("markdown")]
    public string Markdown { get; set; }
    
    [JsonProperty("html")]
    public string Html { get; set; }
}