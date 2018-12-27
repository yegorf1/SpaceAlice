using System;
using System.Threading.Tasks;
using SpaceAlice.DataAccess.Entities ;
using SpaceAlice.DataAccess.Repositories;

namespace SpaceAlice.Core {
    public class MessageProcessor {
        private readonly IDataRepository _dataRepository;

        public MessageProcessor(IDataRepository dataRepository) {
            _dataRepository = dataRepository ?? throw new ArgumentNullException(nameof(dataRepository));
        }
        
        /// <summary>
        /// Process incoming message and generates answer.
        /// </summary>
        /// <param name="message">Incoming message.</param>
        /// <returns>Answer to message with text.</returns>
        public async Task<CoreAnswer> ProcessMessage(IncomingMessage message) {
            User user = await _dataRepository.Users.GetUserById(message.Session.UserId);

            // TODO: if race state is entered another user object will be outdated. Creation if user AFTER lock will fix it.
            lock (user.GetLock()) {
                CoreAnswer answer = message.CreateAnswer($"User id: {user.Id}");

                // TODO: Make it async somehow.
                _dataRepository.Users.Update(user);

                return answer;
            }
        }
    }
}