using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskSphere.Application.Tasks.Commands;
using TaskSphere.Application.Tasks.Queries;
namespace TaskSphere.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TasksController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var tasks = await _mediator.Send(new GetAllTasksQuery());
            return Ok(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTaskCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
