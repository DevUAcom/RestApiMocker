using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using RestApiMocker.Api.CQRS.Commands;
using RestApiMocker.Data;
using RestApiMocker.Data.Entities;
using Xunit;

namespace RestApiMocker.Api.Tests.CQRS.Handlers
{
    public class DeleteRuleCommandHandlerTests
    {
        private readonly DbContextOptions<MockerContext> _options;
        private readonly Fixture _fixture;

        public DeleteRuleCommandHandlerTests()
        {
            _fixture = new Fixture();

            var builder = new DbContextOptionsBuilder<MockerContext>();
            builder.UseInMemoryDatabase(_fixture.Create<string>());
            _options = builder.Options;
        }

        [Fact]
        public async Task Should_Delete_Existing_Entity()
        {
            // Arrange
            int ruleId = 0;
            await using (var context = new MockerContext(_options))
            {
                AppRule rule = _fixture.Create<AppRule>();
                context.AppRule.Add(rule);
                await context.SaveChangesAsync();
                ruleId = rule.Id;
                ruleId.Should().BeGreaterThan(0);
            }

            // Act
            await using (var context = new MockerContext(_options))
            {
                var deleteRuleCommandHandler = new DeleteRuleCommand.DeleteRuleCommandHandler(context);
                var result = await deleteRuleCommandHandler.Handle(new DeleteRuleCommand { Id = ruleId }, CancellationToken.None);
            }

            // Assert
            await using (var context = new MockerContext(_options))
            {
                var rule = await context.AppRule.FirstOrDefaultAsync(x => x.Id == ruleId);
                rule.Should().BeNull();
            }
        }

        [Fact]
        public async Task Should_Ignore_Not_Existing_Entity()
        {
            // Arrange
            int ruleId = 1;
            Fixture fixture = new Fixture();

            // Act
            await using (var context = new MockerContext(_options))
            {
                var deleteRuleCommandHandler = new DeleteRuleCommand.DeleteRuleCommandHandler(context);
                var result = await deleteRuleCommandHandler.Handle(new DeleteRuleCommand { Id = ruleId }, CancellationToken.None);
            }

            // Assert
        }
    }
}
