using System.Text.Json.Serialization;

namespace Biosite.Main.Gateway.Response.Organ
{
    public class OrganResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("svg")]
        public string Svg { get; set; }
    }
}
