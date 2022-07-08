using System.Text.Json.Serialization;

namespace Biosite.Main.Gateway.Response.Authentication
{
    public class AreaResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}
