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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new RuleEntityTypeConfiguration());
        }
    }
}
