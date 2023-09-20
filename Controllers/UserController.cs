using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Repositories;

namespace api.Controllers
{
    [ApiController]
    [Route("api/gym/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _repository;
      
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, IUserRepository repository)
        {
            _logger = logger;
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IEnumerable<User>> List()
        {
            return await _repository.List();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await _repository.Get(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Store([FromBody] User user)
        {
           var result = await _repository.Create(user);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<ActionResult<User>> Update(int id, [FromBody] User user)
        {
           if (id == user.Id)
           {
                var result = await _repository.Update(user);
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
            var user = await _repository.Delete(id);
            
            if (user)
            {
                return Ok();
            }
            return BadRequest();
        }

    }

}