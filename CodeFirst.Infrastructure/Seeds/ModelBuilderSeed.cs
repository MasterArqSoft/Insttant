using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class ModelBuilderSeed
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            Task.Run(() => DefaultStep.SeedDefaultStep(modelBuilder).ConfigureAwait(false));
            Task.Run(() => DefaultFlow.SeedDefaultFlow(modelBuilder).ConfigureAwait(false));
            Task.Run(() => DefaultField.SeedDefaultField(modelBuilder).ConfigureAwait(false));
            Task.Run(() => DeafaultStepToFlow.SeedStepToFlowAsync(modelBuilder).ConfigureAwait(false));
        }
    }
}
