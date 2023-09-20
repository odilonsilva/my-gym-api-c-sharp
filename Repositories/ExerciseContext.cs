using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext(DbContextOptions<ExerciseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
