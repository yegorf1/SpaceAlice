using System.Threading.Tasks;
using SpaceAlice.DataAccess.Entities;

namespace SpaceAlice.DataAccess.Repositories {
    public interface IUserRepository {
        Task<User> GetUserById(string id);
    }
}