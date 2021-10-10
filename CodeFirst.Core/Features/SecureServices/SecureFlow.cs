using CodeFirst.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Core.Features.SecureServices
{
    public class SecureFlow : ISecure
    {
        private readonly IExecutionType _executionType;
        public SecureFlow(IExecutionType executionType)
        {
            _executionType = executionType;
        }
        public async Task<string> CreateSecure()
        {
            Console.WriteLine("Proceso: Crear usuario y seguro.");
            Console.WriteLine();

            await _executionType.Execution("P-0001", true);
            return await Task.FromResult("Seguro Creado");
        }

    }
}
