using CodeFirst.Domain.Entities;
using CodeFirst.Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CodeFirst.Infrastructure.Settings
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
        {
        }

        public CodeFirstContext(DbContextOptions<CodeFirstContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Step> Step { get; set; }
        public virtual DbSet<Flow> Flow { get; set; }
        public virtual DbSet<Field> InscripFieldciones { get; set; }
        public virtual DbSet<StepToFlow> StepToFlow { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.SeedData();

            base.OnModelCreating(modelBuilder);
        }
    }
}
