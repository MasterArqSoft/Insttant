using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class DeafaultStepToFlow
    {
        public static async Task SeedStepToFlowAsync(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StepToFlow>().HasData(
                new StepToFlow()
                {
                    Id = 1,
                    IdFlow = 1,
                    IdSetp = 1,
                    IdField = 1,
                },
                new StepToFlow()
                {
                    Id = 2,
                    IdFlow = 1,
                    IdSetp = 1,
                    IdField = 2,
                },
                new StepToFlow()
                {
                    Id = 3,
                    IdFlow = 1,
                    IdSetp = 1,
                    IdField = 3,
                },
                new StepToFlow()
                {
                    Id = 4,
                    IdFlow = 1,
                    IdSetp = 1,
                    IdField = 4,
                },
                new StepToFlow()
                {
                    Id = 5,
                    IdFlow = 1,
                    IdSetp = 1,
                    IdField = 5,
                },
                new StepToFlow()
                {
                    Id = 6,
                    IdFlow = 1,
                    IdSetp = 1,
                    IdField = 6,
                },
                new StepToFlow()
                {
                    Id = 7,
                    IdFlow = 1,
                    IdSetp = 1,
                    IdField = 7,
                },
                new StepToFlow()
                {
                    Id = 8,
                    IdFlow = 1,
                    IdSetp = 2,
                    IdField = 5,
                },
               new StepToFlow()
               {
                   Id = 9,
                   IdFlow = 1,
                   IdSetp = 2,
                   IdField = 6,
               },
                new StepToFlow()
                {
                    Id = 10,
                    IdFlow = 1,
                    IdSetp = 3,
                    IdField = 7,
                },
                new StepToFlow()
                {
                    Id = 11,
                    IdFlow = 2,
                    IdSetp = 3,
                    IdField = 5,
                },
                new StepToFlow()
                {
                    Id = 12,
                    IdFlow = 2,
                    IdSetp = 3,
                    IdField = 6,
                },
                new StepToFlow()
                {
                    Id = 13,
                    IdFlow = 2,
                    IdSetp = 3,
                    IdField = 8,
                },
                new StepToFlow()
                {
                    Id = 14,
                    IdFlow = 1,
                    IdSetp = 4,
                    IdField = 5,
                },
                new StepToFlow()
                {
                    Id = 15,
                    IdFlow = 1,
                    IdSetp = 4,
                    IdField = 6,
                },
                new StepToFlow()
                {
                    Id = 16,
                    IdFlow = 1,
                    IdSetp = 5,
                    IdField = 5,
                },
                new StepToFlow()
                {
                    Id = 17,
                    IdFlow = 1,
                    IdSetp = 5,
                    IdField = 6,
                }
            );

            await Task.FromResult(Task.CompletedTask).ConfigureAwait(false);
        }
    }
}
