using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CodeFirst.Infrastructure.Seeds
{
    public static class DefaultFlow
    {
        public static async Task SeedDefaultFlow(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flow>().HasData(
                new Flow()
                {
                    Id = 1,
                    Code = "P-0001",
                    Name = "Registrar Usuario",
                },
                new Flow()
                {
                    Id = 2,
                    Code = "P-0002",
                    Name = "Solicitar poliza de seguro",
                }

            );
            await Task.FromResult(Task.CompletedTask).ConfigureAwait(false);
        }
    }
}
