using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApiMocker.Data;
using RestApiMocker.Data.Entities;

namespace RestApiMocker.Api.CQRS.Queries
{
    public class GetAllRulesQuery : IRequest<List<AppRule>>
    {
        public class GetAllRulesHandler : IRequestHandler<GetAllRulesQuery, List<AppRule>>
        {
            private readonly MockerContext _mockerContext;

            public GetAllRulesHandler(MockerContext mockerContext)
            {
                _mockerContext = mockerContext;
            }

 
            public async Task<List<AppRule>> Handle(GetAllRulesQuery request, CancellationToken cancellationToken)
            {
                //return await _mockerContext.AppRule
                //    .Select(x => new SomeRuleObject {x.Id, x.Method})
                //    .ToListAsync();

                //return Task.FromResult(_mockerContext.AppRule.ToList());
                 return await _mockerContext.AppRule.ToListAsync();

            }

        }
    }
}


