using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repositories;

namespace api.Controllers
{
    [ApiController]
    [Route("api/gym/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _repository;
      
        private readonly ILogger<CategoryController> _logger;

        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository repository)
        {
            _logger = logger;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IEnumerable<Category>> List()
        {
            return await _repository.List();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Category>> Get(int id)
        {
            var category = await _repository.Get(id);
            if (category == null)
            {
                return NotFound();
            }
            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Category>> Store([FromBody] Category category)
        {
           var result = await _repository.Create(category);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<ActionResult<Category>> Update(int id, [FromBody] Category category)
        {
           if (id == category.Id)
           {
                var result = await _repository.Update(category);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);
           }
           return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _repository.Delete(id);
            
            if (category)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}