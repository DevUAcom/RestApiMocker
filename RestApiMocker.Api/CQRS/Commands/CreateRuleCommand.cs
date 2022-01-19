using AutoMapper;
using MediatR;
using RestApiMocker.Data;
using RestApiMocker.Data.Entities;

namespace RestApiMocker.Api.CQRS.Commands
{
    public class CreateRuleCommand : IRequest<int>
    {
        public string Method { get; set; }
        public string Path { get; set; }
        public int ResponseStatus { get; set; }
        public ICollection<ResponseHeaderDto> ResponseHeaders { get; set; }
        public string ResponseBody { get; set; }

        public class ResponseHeaderDto
        {
            public string Key { get; set; }
            public string Value { get; set; }

        }

        public class CreateRuleCommandHandler : IRequestHandler<CreateRuleCommand, int>
        {
            private readonly MockerContext _dbContext;
            private readonly IMapper _mapper;

            public CreateRuleCommandHandler(MockerContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<int> Handle(CreateRuleCommand command, CancellationToken cancellationToken)
            {

                var rule = _mapper.Map<AppRule>(command);

                //AppRule rule = new AppRule()
                //{
                //    Method = request.Method,
                //    Path = request.Path,
                //    ResponseBody = request.ResponseBody,
                //    ResponseHeaders = request.ResponseHeaders,
                //    ResponseStatus = request.ResponseStatus,
                //};

                _dbContext.AppRule.Add(rule);
                await _dbContext.SaveChangesAsync(cancellationToken);

                // client wants to know identity id
                // you can return the whole object if needed . could be useful for some clients.
                // in most cases returning the id is enough
                return rule.Id;
            }
        }
    }

}
