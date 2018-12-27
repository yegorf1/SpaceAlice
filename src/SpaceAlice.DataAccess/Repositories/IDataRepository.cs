namespace SpaceAlice.DataAccess.Repositories {
    public interface IDataRepository {
        IUserRepository Users { get; }
    }
}