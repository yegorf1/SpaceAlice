using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SpaceAlice.Web.Models;

namespace SpaceAlice.Web.Controllers {
    public class AliceWebHookController : Controller {
        private readonly IAliceMessageProcessor _messageProcessor;

        public AliceWebHookController(IAliceMessageProcessor messageProcessor) {
            _messageProcessor = messageProcessor;
        }

        [HttpPost("/alice")]
        public async Task<AliceResponseModel> WebHookAsync([FromBody] AliceRequestModel req) => await _messageProcessor.Process(req);
    }
}