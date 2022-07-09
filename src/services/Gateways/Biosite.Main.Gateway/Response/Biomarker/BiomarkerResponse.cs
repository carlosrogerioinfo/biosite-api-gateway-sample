using System.Text.Json.Serialization;

namespace Biosite.Main.Gateway.Response.Biomarker
{
    public class BiomarkerResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("unity")]
        public string Unity { get; set; }

        [JsonPropertyName("bodyImageType")]
        public int BodyImageType { get; set; }

        [JsonPropertyName("aboveImpact")]
        public string AboveImpact { get; set; }

        [JsonPropertyName("belowImpact")]
        public string BelowImpact { get; set; }
    }
}
