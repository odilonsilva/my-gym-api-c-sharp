using api.Models;

namespace api.Repositories
{
    public interface IExerciseRepository
    {
        Task<IEnumerable<Exercise>> List();

        Task<Exercise> Get(int id);

        Task<Exercise> Create(Exercise exercise);

        Task<Exercise> Update(Exercise exercise);

        Task<bool> Delete(int id);

    }
}