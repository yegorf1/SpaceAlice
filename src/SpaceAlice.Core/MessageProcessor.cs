using SpaceAlice.Core.Entities;

namespace SpaceAlice.Core {
    public class MessageProcessor {
        public CoreAnswer ProcessMessage(IncomingMessage message) {
            return new CoreAnswer {
                Session = message.Session,
                Text = "Check"
            };
        }
    }
}