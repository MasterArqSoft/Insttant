using CodeFirst.Domain.Entities;
using CodeFirst.Infrastructure.Settings;

namespace CodeFirst.Infrastructure.Repositories.RespositoryAsync
{
    public class StepToFlowRepositoryAsync : GenericRepository<StepToFlow>
    {
        public StepToFlowRepositoryAsync(CodeFirstContext codeFirstContext) : base(codeFirstContext)
        {
        }
    }
}
