using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestApiMocker.Api.CQRS.Commands;
using RestApiMocker.Api.CQRS.Queries;
using RestApiMocker.Api.Models;
using RestApiMocker.Data.Entities;

namespace RestApiMocker.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RulesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public RulesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddRule(CreateRuleCommand command)
        {
            var response = await _mediator.Send(command);
            return Created($"rules/{response}", response);
        }

        [HttpGet]
        public async Task<ActionResult<List<AppRule>>> GetRule()
        {
            return await _mediator.Send(new GetAllRulesQuery()); 
 
        }
        
        // TODO: Commit to new branch
        
        // [HttpPut]
        // EditRule

        // Delete

        // [HttpGet]
        // List()
    }
}
