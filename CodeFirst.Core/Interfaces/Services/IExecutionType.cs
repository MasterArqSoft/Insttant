using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Services
{
    public interface IExecutionType
    {
        Task<string> Execution(string codeFlow, bool secuencial);
    }
}
