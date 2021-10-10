
using CodeFirst.Domain.Entities;
using CodeFirst.Infrastructure.Settings;

namespace CodeFirst.Infrastructure.Repositories.RespositoryAsync
{
    public class FlowRepositoryAsync : GenericRepository<Flow>
    {
        public FlowRepositoryAsync(CodeFirstContext codeFirstContext) : base(codeFirstContext)
        {
        }
    }
}
