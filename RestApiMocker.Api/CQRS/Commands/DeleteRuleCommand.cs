using MediatR;
using Microsoft.EntityFrameworkCore;
using RestApiMocker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestApiMocker.Api.Exceptions;
using RestApiMocker.Data.Entities;

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
                // select * from Rule where Id = command.Id
                //var rule = new AppRule() { Id = command.Id };

                if (rule == null)
                {
                    return 0;
                }

                //_context.Attach(rule);
                _context.AppRule.Remove(rule);
                return await _context.SaveChangesAsync(cancellationToken);
                // delete from Rule where Id = command.Id
                //return Unit.Value;
            }
        }
    }
}
