using CodeFirst.Domain.Entities;
using CodeFirst.Infrastructure.Settings;

namespace CodeFirst.Infrastructure.Repositories.RespositoryAsync
{
    public class FieldRepositoryAsync : GenericRepository<Field>
    {
        public FieldRepositoryAsync(CodeFirstContext codeFirstContext) : base(codeFirstContext)
        {
        }
        
    }
}
