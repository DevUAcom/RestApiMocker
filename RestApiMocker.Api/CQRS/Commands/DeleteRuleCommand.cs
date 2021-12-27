using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApiMocker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiMocker.Api.Exceptions;

namespace RestApiMocker.Api.CQRS.Commands
{
    public class DeleteRuleCommand : IRequest<int>
    {
        public int Id { get; set; }

        public class DeleteRuleCommandHandler : IRequestHandler<DeleteRuleCommand, int>
        {
            private readonly MockerContext _context;
            public DeleteRuleCommandHandler(MockerContext mockerContext)
            {
                _context = mockerContext;
            }

            public async Task<int> Handle(DeleteRuleCommand command, CancellationToken cancellationToken)
            {
                var rule =  await _context.AppRule.FirstOrDefaultAsync(r => r.Id == command.Id);

                if (rule == null)
                {
                    throw new NotFoundException();
                }
                
                _context.AppRule.Remove(rule);
                await _context.SaveChangesAsync(cancellationToken);
                return rule.Id;
            }
        }
    }
}
