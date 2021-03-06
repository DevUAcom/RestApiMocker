using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RestApiMocker.Data.Entities;

namespace RestApiMocker.Data.EntityTypeConfigurations
{
    public class RuleEntityTypeConfiguration : IEntityTypeConfiguration<AppRule>
    {
        public const int MethodColumnMaxLength = 10;
        public const int PathColumnMaxLength = 100;
        public void Configure(EntityTypeBuilder<AppRule> builder)
        {
            builder.Property(x => x.Method)
                .IsRequired()
                .HasMaxLength(MethodColumnMaxLength)
                ;

            builder.Property(x => x.Path)
                .IsRequired()
                .HasMaxLength(PathColumnMaxLength)
                ;
        }
    }
}
