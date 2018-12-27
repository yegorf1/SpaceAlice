using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

using SpaceAlice.Core;
using SpaceAlice.DataAccess.Entities;
using SpaceAlice.DataAccess.Repositories;
using SpaceAlice.Web.Models;

namespace SpaceAlice.Web {
    public class SynchronousAliceMessageProcessor : IAliceMessageProcessor {
        private readonly MessageProcessor _messageProcessor;
        private readonly ILogger<SynchronousAliceMessageProcessor> _logger;

        public SynchronousAliceMessageProcessor(ILogger<SynchronousAliceMessageProcessor> logger, IDataRepository dataRepository) {
            _messageProcessor = new MessageProcessor(dataRepository);
            _logger = logger;
        }

        public async Task<AliceResponseModel> Process(AliceRequestModel request) {
            var coreMessage = new IncomingMessage {
                Session = new SessionDescription {
                    SessionId = request.Session.SessionId, 
                    UserId = request.Session.UserId
                },
                Text = request.Request.Command
            };

            CoreAnswer answer = await _messageProcessor.ProcessMessage(coreMessage);
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