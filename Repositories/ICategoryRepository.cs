using api.Models;

namespace api.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> List();

        Task<Category> Get(int id);

        Task<Category> Create(Category category);

        Task<Category> Update(Category category);

        Task<bool> Delete(int id);

    }
}