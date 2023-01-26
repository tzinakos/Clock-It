namespace API.Controllers
{
    using Business.IRepository;
    using Business.Users;
    using Domain;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] User user)
        {
            return Ok(await Mediator.Send(new Create.Command { User = user }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(Guid id, [FromBody] User user)
        {
            return Ok(await Mediator.Send(new Update.Command { Id = id, User = user }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
