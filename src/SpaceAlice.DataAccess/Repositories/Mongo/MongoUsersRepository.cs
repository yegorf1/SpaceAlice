using System.Threading.Tasks;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SpaceAlice.DataAccess.Entities;

namespace SpaceAlice.DataAccess.Repositories.Mongo {
    public class MongoUsersRepository : IUserRepository {
        private readonly IMongoCollection<User> _users;

        public MongoUsersRepository(IMongoDatabase database) {
            BsonClassMap.RegisterClassMap<User>(cm => {
                cm.AutoMap();
                cm.MapIdMember(u => u.Id);
            });
            _users = database.GetCollection<User>("users");
        }

        public async Task<User> GetUserById(string id) {
            return await _users.Find(CreateIdFilter(id)).FirstOrDefaultAsync() ?? new User {Id = id};
        }

        public void Update(User user) =>
            _users.FindOneAndReplace(CreateIdFilter(user.Id), user,
                new FindOneAndReplaceOptions<User> {
                    IsUpsert = true
                });

        private static FilterDefinition<User> CreateIdFilter(string id) => 
            new FilterDefinitionBuilder<User>().Eq(u => u.Id, id);
    }
}