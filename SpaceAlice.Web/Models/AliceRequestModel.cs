using Newtonsoft.Json;

namespace SpaceAlice.Web.Models {
    public class AliceRequestModel {
        [JsonProperty("meta")]
        public MetaModel Meta { get; set; }

        [JsonProperty("request")]
        public RequestBodyModel Request { get; set; }

        [JsonProperty("session")]
        public SessionModel Session { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }
    }
}