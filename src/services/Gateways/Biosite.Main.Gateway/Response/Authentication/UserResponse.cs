using System.Text.Json.Serialization;

namespace Biosite.Main.Gateway.Response.Authentication
{
    public class UserResponse
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }

        [JsonPropertyName("genderDescription")]
        public string Gender { get; set; }

        [JsonPropertyName("pregnant")]
        public bool Pregnant { get; set; }

        [JsonPropertyName("height")]
        public string Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("imc")]
        public string Imc { get; set; }

        [JsonPropertyName("imcResult")]
        public string ImcResult { get; set; }

        [JsonPropertyName("lastLoginAt")]
        public string LastLoginAt { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("plan")]
        public PlanResponse Plan { get; set; }
    }
}
