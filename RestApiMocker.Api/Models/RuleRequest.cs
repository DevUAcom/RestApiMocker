using System.ComponentModel.DataAnnotations;
using MediatR;
using RestApiMocker.Data.EntityTypeConfigurations;

namespace RestApiMocker.Api.Models
{
    public class RuleRequest : IRequest<RuleResponse>
    {
        [MaxLength(RuleEntityTypeConfiguration.MethodColumnMaxLength)]
        public string Method { get; set; }
        public string Path { get; set; }

        public int ResponseStatus { get; set; }
        public string ResponseHeaders { get; set; }
        public string ResponseBody { get; set; }

    }
}
