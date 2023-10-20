using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly ApiContext _context;

        public ExerciseRepository(ApiContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Exercise>> List()
        {
            return await _context.Exercises.ToListAsync();
        }

        public async Task<Exercise> Get(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);
            return exercise;
        }

        public async Task<Exercise> Create(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task<Exercise> Update(Exercise exercise)
        {
            _context.Entry(exercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return exercise;
        }

        public async Task<bool> Delete(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise != null)
            {
                _context.Exercises.Remove(exercise);

                await _context.SaveChangesAsync(true);
                return true;
            }
            return false;
        }

        public int Count()
        {
          return _context.Exercises.AsSingleQuery().Count();
        }
    }
}