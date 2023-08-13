using System.Text.Json.Serialization;

namespace FlutterWave.Core.Models.Services.Foundations.ExternalFlutterWave
{
    internal class ExternalErrorResponse
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("data")]
        public object Data { get; set; }
    }
}
