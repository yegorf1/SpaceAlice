using SpaceAlice.Web.Models;

namespace SpaceAlice.Web {
    public interface IAliceMessageProcessor {
        AliceResponseModel Process(AliceRequestModel request);
    }
}