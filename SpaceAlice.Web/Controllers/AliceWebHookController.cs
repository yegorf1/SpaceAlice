using Microsoft.AspNetCore.Mvc;
using SpaceAlice.Web.Models;

namespace SpaceAlice.Web.Controllers {
    public class AliceWebHookController : Controller {
        [HttpPost("/alice")]
            Response = new ResponseBodyModel {
                Text = "Hello",
                Tts = "Hello",
                EndSession = false
            },
            Session = req.Session
        };
    }
}