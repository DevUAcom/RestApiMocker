using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApiMocker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiMocker.Api.HandlerResults;

namespace RestApiMocker.Api.CQRS.Commands
{
    public class DeleteRuleCommand : IRequest<HandlerResult>
    {
        public int Id { get; set; }

        public class DeleteRuleCommandHandler : IRequestHandler<DeleteRuleCommand, HandlerResult>
        {
            private readonly MockerContext _context;
            public DeleteRuleCommandHandler(MockerContext mockerContext)
            {
                _context = mockerContext;
            }

            public async Task<HandlerResult> Handle(DeleteRuleCommand command, CancellationToken cancellationToken)
            {
                var rule =  await _context.AppRule.FirstOrDefaultAsync(r => r.Id == command.Id);

                if (rule == null)
                {
                    return new NotFoundHandlerResult();
                }
                
                _context.AppRule.Remove(rule);
                await _context.SaveChangesAsync(cancellationToken);
                return new OkHandlerResult();
            }
        }
    }
}
