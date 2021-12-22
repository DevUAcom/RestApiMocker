using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApiMocker.Data;
using RestApiMocker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                return await _context.AppRule.FirstOrDefaultAsync(r => r.Id == query.Id);
            }
        }
    }
}
