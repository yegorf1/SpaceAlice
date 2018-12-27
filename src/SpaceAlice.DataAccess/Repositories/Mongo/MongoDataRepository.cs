using MongoDB.Driver;

namespace SpaceAlice.DataAccess.Repositories.Mongo {
    public class MongoDataRepository : IDataRepository {
        public IUserRepository Users { get; }

        public MongoDataRepository(MongoConnectionOptions options) {
            var connection = new MongoClient(options.ConnectionString);
            IMongoDatabase database = connection.GetDatabase(options.DatabaseName);
            
            Users = new MongoUsersRepository(database);
        }
    }
}