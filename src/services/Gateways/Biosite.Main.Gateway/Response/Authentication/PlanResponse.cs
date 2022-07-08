using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Biosite.Main.Gateway.Response.Authentication
{
    public class PlanResponse
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("planAreas")]
        public ICollection<PlanAreaResponse> PlanAreas { get; set; }

    }
}
