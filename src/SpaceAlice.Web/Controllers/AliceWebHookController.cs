using Microsoft.AspNetCore.Mvc;
using SpaceAlice.Web.Models;

namespace SpaceAlice.Web.Controllers {
    public class AliceWebHookController : Controller {
        [HttpPost("/alice")]
        public AliceResponseModel WebHook([FromBody] AliceRequestModel req) =>
            new AliceResponseModel {
                Body = new ResponseBodyModel {
                    Text = "Hello",
                    Tts = "Hello",
                    EndSession = false
                },
                Session = req.Session
            };
    }
}