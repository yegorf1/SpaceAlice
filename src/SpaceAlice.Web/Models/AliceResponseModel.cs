using Newtonsoft.Json;

namespace SpaceAlice.Web.Models {
    public class AliceResponseModel {
        [JsonProperty("response")]
        public ResponseBodyModel Response { get; set; }

        [JsonProperty("session")]
        public SessionModel Session { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; } = "1.0";
    }
}