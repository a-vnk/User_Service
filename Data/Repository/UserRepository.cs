using Microsoft.EntityFrameworkCore;
using Service_User.Data.Repository.Interface;
using Service_User.Model;

namespace Service_User.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserDbContext _contextUser;
        public UserRepository(UserDbContext contextProduct)
        {
            _contextUser = contextProduct;
        }

        public async Task<List<User>> GetUsersAsync()
        {

            var elements = await _contextUser.Users.ToListAsync().ConfigureAwait(false);

            return elements;
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var element = await _contextUser.Users.FirstOrDefaultAsync(user => user.UserId == userId).ConfigureAwait(false);

            return element;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            var elementAdded = await _contextUser.Users.AddAsync(user).ConfigureAwait(false);

            await _contextUser.SaveChangesAsync().ConfigureAwait(false);

            return elementAdded.Entity;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var elementUpdated = _contextUser.Users.Update(user);

            await _contextUser.SaveChangesAsync().ConfigureAwait(false);

            return elementUpdated.Entity;
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            var elementDeleted = _contextUser.Users.Remove(user);

            await _contextUser.SaveChangesAsync().ConfigureAwait(false);

            return elementDeleted.Entity;

        }
    }
}

