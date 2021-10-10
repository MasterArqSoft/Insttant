using CodeFirst.Core.DTOs.Secure.Request;
using CodeFirst.Core.DTOs.Secure.Response;
using CodeFirst.Core.Interfaces.Services;
using CodeFirst.Core.Wrappers;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Core.Features.SecureServices
{
    public class SecureServices : ISecureServices
    {
        private readonly IExecutionType _executionType;
        public SecureServices(IExecutionType executionType)
        {
            _executionType = executionType;
        }
        public async Task<Response<SecureDtoResponse>> CreateSecure(SecureDtoRequest Secure)
        {

            await Task.Run(() =>
            {
                var flujo = new Flow();

                Console.WriteLine("Flujo: Select Strategy is set Register User and create secure (Secuence).");
                flujo.SetStrategyFlujo(new SecureFlow(_executionType));
                flujo.FlowLogic();
                Console.WriteLine();

                Console.WriteLine("Flujo:select Strategy is set to send email, active user and secure (Parallel).");
                flujo.SetStrategyFlujo(new ActiveSendEmailFlow(_executionType));
                flujo.FlowLogic();
                Console.WriteLine();

            });

            return new Response<SecureDtoResponse>() { Message = $"El seguro No {5} ha sido creado." };
        }
    }
}
