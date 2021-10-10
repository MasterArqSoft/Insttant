using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Services
{
    public interface ISecure
    {
        Task<string> CreateSecure();
    }
}
