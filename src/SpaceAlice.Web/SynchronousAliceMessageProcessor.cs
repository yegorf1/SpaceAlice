using Microsoft.Extensions.Logging;

using SpaceAlice.Core;
using SpaceAlice.DataAccess.Entities;
using SpaceAlice.Web.Models;

namespace SpaceAlice.Web {
    public class SynchronousAliceMessageProcessor : IAliceMessageProcessor {
        private readonly MessageProcessor _messageProcessor;
        private readonly ILogger<SynchronousAliceMessageProcessor> _logger;

        public SynchronousAliceMessageProcessor(ILogger<SynchronousAliceMessageProcessor> logger) {
            _messageProcessor = new MessageProcessor();
            _logger = logger;
        }

        public AliceResponseModel Process(AliceRequestModel request) {
            var coreMessage = new IncomingMessage {
                Session = new SessionDescription {
                    SessionId = request.Session.SessionId, User = new User {Id = request.Session.UserId}
                },
                Text = request.Request.Command
            };

            CoreAnswer answer = _messageProcessor.ProcessMessage(coreMessage);
            return new AliceResponseModel {
                Body = new ResponseBodyModel {
                    Text = answer.Text,
                    Tts = answer.Text,
                    Buttons = new ButtonModel[0],
                    EndSession = false
                },
                Session = request.Session
            };
        }
    }
}