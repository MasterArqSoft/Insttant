using CodeFirst.Core.DTOs.Secure.Request;
using CodeFirst.Core.DTOs.Secure.Response;
using CodeFirst.Core.Wrappers;
using System.Threading.Tasks;

namespace CodeFirst.Core.Interfaces.Services
{
    public interface ISecureServices
    {
        Task<Response<SecureDtoResponse>> CreateSecure(SecureDtoRequest Secure);
    }
}
