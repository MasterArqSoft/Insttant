using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class DefaultStep
    {
        public static async Task SeedDefaultStep(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Step>().HasData(
                new Step()
                {
                    Id = 1,
                    Code = "STP-0001",
                    Name = "RegisterUserAsync",
                },
                new Step()
                {
                    Id = 2,
                    Code = "STP-0002",
                    Name = "CreateSecureAsync",
                },
                new Step()
                {
                    Id = 3,
                    Code = "STP-0003",
                    Name = "SendEmailAsync",
                },
                new Step()
                {
                    Id = 4,
                    Code = "STP-0004",
                    Name = "ActiveUserAsync",
                },
                new Step()
                {

                    Id = 5,
                    Code = "STP-0005",
                    Name = "ActiveSecureAsync",
                }
            );
            await Task.FromResult(Task.CompletedTask).ConfigureAwait(false);
        }
    }
}
