using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestApiMocker.Api.CQRS.Commands;
using RestApiMocker.Api.CQRS.Queries;

namespace RestApiMocker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RulesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public RulesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddRule(CreateRuleCommand command)
        {
            var response = await _mediator.Send(command);
            return Created($"rules/{response}", response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRules()
        {
            return Ok(await _mediator.Send(new GetAllRulesQuery()) );

        }

        //[HttpGet]
        //public async Task<ActionResult<List<AppRule>>> GetRule()
        //{
        //    return await _mediator.Send(new GetAllRulesQuery());

        //}


        [HttpGet("{id}")]
        public async Task<IActionResult> GetARuleById(int id)
        {
            return Ok(await _mediator.Send(new GetARuleByIdQuery { Id = id }));
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRuleById(int id, UpdateRuleCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command)); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRuleById(int id)
        {
            return Ok(await _mediator.Send(new DeleteRuleCommand{ Id = id }));
        }
    }
}
