using GYM_DB.Repositories.Base;
using GYM_MODELS.DB;
using MongoDB.Driver;

namespace GYM_DB.Repositories
{

    public interface IUserRepository
    {
        UserDBRecord? FindUserByUsername(string username);
        bool InsertUser(UserDBRecord newUser);
    }

    public class UserRepository : Repository<UserDBRecord>, IUserRepository
    {
        public UserRepository(IMongoDatabase database) : base(database, "Users")
        {
        }

        public UserDBRecord? FindUserByUsername(string username)
        {
            var filter = Builders<UserDBRecord>.Filter.Eq(u => u.User, username);
            return FindOne(filter);
        }

        public bool InsertUser(UserDBRecord newUser)
        {
            return InsertOne(newUser);
        }
    }
}
