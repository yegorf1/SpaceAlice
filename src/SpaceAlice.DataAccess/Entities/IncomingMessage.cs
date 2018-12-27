namespace SpaceAlice.DataAccess.Entities {
    public class IncomingMessage : Message {
        public CoreAnswer CreateAnswer(string text) {
            return new CoreAnswer {
                Session = Session,
                Text = text
            };
        }
    }
}