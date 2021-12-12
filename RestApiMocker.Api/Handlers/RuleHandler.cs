using MediatR;
using RestApiMocker.Api.Models;
using RestApiMocker.Data;
using RestApiMocker.Data.Entities;

namespace RestApiMocker.Api.Handlers
{
    public class RuleHandler : IRequestHandler<RuleRequest, RuleResponse>
    {
        private readonly MockerContext _dbContext;

        public RuleHandler(MockerContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<RuleResponse> Handle(RuleRequest request, CancellationToken cancellationToken)
        {
            //  TODO: Create an Automapper - Nick
            Rule rule = new Rule()
            {
                Method = request.Method,
                Path = request.Path,
                ResponseBody = request.ResponseBody,
                ResponseHeaders = request.ResponseHeaders,
                ResponseStatus = request.ResponseStatus,
            };
            _dbContext.Rules.Add(rule);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            return new RuleResponse() { Id = rule.Id };
        }   
    }
}
