using System.Threading.Tasks;
using SpaceAlice.Web.Models;

namespace SpaceAlice.Web {
    public interface IAliceMessageProcessor {
        Task<AliceResponseModel> Process(AliceRequestModel request);
    }
}