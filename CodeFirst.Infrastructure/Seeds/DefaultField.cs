using CodeFirst.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
namespace CodeFirst.Infrastructure.Seeds
{
    public class DefaultField
    {
        public static async Task SeedDefaultField(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Field>().HasData(
                new Field()
                {
                    Id = 1,
                    Code = "F-0001",
                    Name = "Primer nombre",
                },
                new Field()
                {
                    Id = 2,
                    Code = "F-0002",
                    Name = "Segundo nombre",
                },
                new Field()
                {
                    Id = 3,
                    Code = "F-0003",
                    Name = "Primer apellido",
                },
                new Field()
                {
                    Id = 4,
                    Code = "F-0004",
                    Name = "Segundo apellido",
                },
                new Field()
                {
                    Id = 5,
                    Code = "F-0005",
                    Name = "Tipo documento",
                },
                new Field()
                {
                    Id = 6,
                    Code = "F-0006",
                    Name = "Número de documento",
                },
                new Field()
                {
                    Id = 7,
                    Code = "F-0007",
                    Name = "Email",
                },
                new Field()
                {
                    Id = 8,
                    Code = "F-0007",
                    Name = "Valor Seguro",
                }

            );
            await Task.FromResult(Task.CompletedTask).ConfigureAwait(false);
        }
    }
}
