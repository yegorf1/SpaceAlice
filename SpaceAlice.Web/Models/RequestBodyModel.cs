using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SpaceAlice.Web.Models {
    public class RequestBodyModel {
        [JsonProperty("command")]
        public string Command { get; set; }

        [JsonProperty("type")]
        public RequestType Type { get; set; }

        [JsonProperty("original_utterance")]
        public string OriginalUtterance { get; set; }

        [JsonProperty("payload")]
        public JObject Payload { get; set; }
    }
}