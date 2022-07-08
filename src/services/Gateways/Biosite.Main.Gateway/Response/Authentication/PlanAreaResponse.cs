using System.Text.Json.Serialization;

namespace Biosite.Main.Gateway.Response.Authentication
{
    public class PlanAreaResponse
    {
        [JsonPropertyName("area")]
        public AreaResponse Area { get; set; }
    }
}
