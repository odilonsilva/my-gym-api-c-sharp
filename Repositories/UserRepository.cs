using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExerciseContext _context;

        public UserRepository(ExerciseContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> List()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> Get(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Delete(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user != null)
            {
                _context.Users.Remove(user);

                await _context.SaveChangesAsync(true);
                return true;
            }
            return false;
        }

    }
}