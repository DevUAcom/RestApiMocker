using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApiMocker.Api.Exceptions;
using RestApiMocker.Data;
using RestApiMocker.Data.Entities;

namespace RestApiMocker.Api.CQRS.Queries
{
    public class GetARuleByIdQuery : IRequest<AppRule>
    {
        public int Id { get; set; }

        public class GetARuleByIdQueryHandler : IRequestHandler<GetARuleByIdQuery, AppRule>
        {
            private readonly MockerContext _context;
            public GetARuleByIdQueryHandler(MockerContext mockerContext)
            {
                _context = mockerContext;
            }

            public async Task<AppRule> Handle(GetARuleByIdQuery query, CancellationToken cancellationToken)
            {
                var appRule = await _context.AppRule.FirstOrDefaultAsync(r => r.Id == query.Id);

                return appRule;                
            }
        }
    }
}
