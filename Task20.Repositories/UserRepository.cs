using Task20.DataContext.DataBaseContext;
using Task20.Entities;
using Task20.Repositories.Base;

namespace Task20.Repositories
{
    public class UserRepository : BaseRepository<UserEntity>
    {
        public UserRepository(UniversityDbContext context) : base(context)
        {
        }

        public UserEntity? Login(string login, string password)
        {
            var user = Context.Users.FirstOrDefault(x => x.Login == login);
            if(user == null)
                return null;

            var passwordHash = UserEntity.CreatePasswordHash(password, user.PasswordSalt);
            if(passwordHash != user.PasswordHash)
                return null;

            return user;
        }
    }
}
