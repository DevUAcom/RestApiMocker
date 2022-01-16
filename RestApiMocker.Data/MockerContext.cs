using Microsoft.EntityFrameworkCore;
using RestApiMocker.Data.Entities;
using RestApiMocker.Data.EntityTypeConfigurations;

namespace RestApiMocker.Data
{
    public class MockerContext : DbContext
    {
        public MockerContext()
        {
        }

        public MockerContext(DbContextOptions<MockerContext> options): base(options)
        {
        }

        public DbSet<AppRule> AppRule { get; set; }
        public DbSet<ResponseHeader> ResponseHeaders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RuleEntityTypeConfiguration());

            //https://docs.microsoft.com/en-us/ef/core/modeling/keyless-entity-types?tabs=fluent-api
            //modelBuilder.Entity<ResponseHeader>().HasNoKey();
        }
    }
}
