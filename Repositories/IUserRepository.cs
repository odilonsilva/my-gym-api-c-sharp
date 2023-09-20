using api.Models;

namespace api.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> List();

        Task<User> Get(int id);

        Task<User> Create(User user);

        Task<User> Update(User user);

        Task<bool> Delete(int id);

    }
}