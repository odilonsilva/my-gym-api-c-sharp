using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repositories;

namespace api.Controllers
{
    [ApiController]
    [Route("api/gym/exercises")]
    public class ExerciseController : ControllerBase
    {
        private readonly IExerciseRepository _repository;

        private readonly ApiContext _context;
      
        private readonly ILogger<ExerciseController> _logger;

        public ExerciseController(ILogger<ExerciseController> logger, IExerciseRepository repository, ApiContext context)
        {
            _logger = logger;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> List(int CurrentPage = 1, int PerPage = 5)
        {
            var result = await PageList<Exercise>.Paginate(_context.Exercises, CurrentPage, PerPage);
            
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> Get(int id)
        {
            var exercise = await _repository.Get(id);
            if (exercise == null)
            {
                return NotFound();
            }
            return exercise;
        }

        [HttpPost]
        public async Task<ActionResult<Exercise>> Store([FromBody] Exercise exercise)
        {
           var exerciseResult = await _repository.Create(exercise);
            if (exerciseResult == null)
            {
                return BadRequest();
            }
            return Ok(exerciseResult);
        }
        
        [HttpPut]
        public async Task<ActionResult<Exercise>> Update(int id, [FromBody] Exercise exercise)
        {
           if (id == exercise.Id)
           {
                var exerciseResult = await _repository.Update(exercise);
                if (exerciseResult == null)
                {
                    return BadRequest();
                }
                return Ok(exerciseResult);
           }
           return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var exercise = await _repository.Delete(id);
            
            if (exercise)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}