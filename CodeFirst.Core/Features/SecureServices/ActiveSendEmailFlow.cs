using CodeFirst.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Core.Features.SecureServices
{
    public class ActiveSendEmailFlow : ISecure
    {
        private readonly IExecutionType _executionType;
        public ActiveSendEmailFlow(IExecutionType executionType)
        {

            _executionType = executionType;
        }
        public async Task<string> CreateSecure()
        {
            Console.WriteLine("Proceso: Activar usuario y enviar email.");
            Console.WriteLine();

            await _executionType.Execution("P-0002", false);
            return await Task.FromResult("Parralleo");

        }

    }
}
