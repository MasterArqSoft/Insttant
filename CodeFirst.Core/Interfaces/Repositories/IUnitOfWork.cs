using CodeFirst.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<StepToFlow> StepToFlowRepositoryAsync { get; }
        IGenericRepository<Flow> FlowRepositoryAsync { get; }
        IGenericRepository<Field> FieldRepositoryAsync { get; }
        IGenericRepository<Step> StepRepositoryAsync { get; }
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
