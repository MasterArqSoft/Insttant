using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Services
{
    public interface ISteps
    {
        Task<bool> RegisterUserAsync();
        Task<bool> CreateSecureAsync();
        Task<bool> SendEmailAsync();
        Task<bool> ActiveUserAsync();
        Task<bool> ActiveSecureAsync();
    }
}
