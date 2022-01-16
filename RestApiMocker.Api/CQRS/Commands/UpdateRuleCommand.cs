using AutoMapper;
using MediatR;
using RestApiMocker.Api.Exceptions;
using RestApiMocker.Data;
using RestApiMocker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiMocker.Api.CQRS.Commands
{
    public class UpdateRuleCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public int ResponseStatus { get; set; }
        public ICollection<ResponseHeader> ResponseHeaders { get; set; }
        public string ResponseBody { get; set; }


        public class UpdateRuleCommandHandler : IRequestHandler<UpdateRuleCommand, int>
        {
            private readonly MockerContext _context;
            private readonly IMapper _mapper;

            public UpdateRuleCommandHandler(MockerContext dbContext, IMapper mapper)
            {
                _context = dbContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(UpdateRuleCommand command, CancellationToken cancellationToken)
            {
                var rule = _context.AppRule.FirstOrDefault(r => r.Id == command.Id);

                if (rule == null)
                {
                    throw new NotFoundException();
                }

                //var rule = _mapper.Map<AppRule>(updatedCommand);
                rule.Method = command.Method;
                rule.Path = command.Path;
                rule.ResponseStatus = command.ResponseStatus;
                rule.ResponseHeaders = command.ResponseHeaders;
                rule.ResponseBody = command.ResponseBody;

                await _context.SaveChangesAsync(cancellationToken);

                return rule.Id;
            }
        }
    }
}
