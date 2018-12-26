using Microsoft.AspNetCore.Mvc;
using SpaceAlice.Web.Models;

namespace SpaceAlice.Web.Controllers {
    public class AliceWebHookController : Controller {
        private readonly IAliceMessageProcessor _messageProcessor;

        public AliceWebHookController(IAliceMessageProcessor messageProcessor) {
            _messageProcessor = messageProcessor;
        }

        [HttpPost("/alice")]
        public AliceResponseModel WebHook([FromBody] AliceRequestModel req) => _messageProcessor.Process(req);
    }
}