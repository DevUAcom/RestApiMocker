using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestApiMocker.Api.Models;

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
        public async Task<ActionResult<RuleResponse>> AddRule(RuleRequest ruleRequest)
        {
            var response = await _mediator.Send(ruleRequest);
            return Created($"rules/{response.Id}", response);
        }

        [HttpGet]
        public IActionResult GetRule()
        {
            return Ok(null);
        }

        // [HttpPut]
        // EditRule

        // Delete

        // [HttpGet]
        // List()
    }
}
