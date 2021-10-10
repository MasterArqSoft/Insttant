using CodeFirst.Domain.Entities;
using CodeFirst.Infrastructure.Settings;

namespace CodeFirst.Infrastructure.Repositories.RespositoryAsync
{
    public class StepRepositoryAsync : GenericRepository<Step>
    {
        public StepRepositoryAsync(CodeFirstContext codeFirstContext) : base(codeFirstContext)
        {
        }
    }
}
