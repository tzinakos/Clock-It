namespace API.Controllers
{
    using Business.Projects;
    using Domain;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<List<Project>>> GetProjects()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProject(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        [HttpPost]
        public async Task<ActionResult> CreateProject([FromBody] Project project)
        {
            return Ok(await Mediator.Send(new Create.Command { Project = project }));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateProject(Guid id, [FromBody] Project project)
        {
            return Ok(await Mediator.Send(new Update.Command { Id = id, Project = project }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command { Id = id }));
        }
    }
}
