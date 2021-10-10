using CodeFirst.Core.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace CodeFirst.Core.Features.SecureServices
{
    public class Steps : ISteps
    {

        public async Task<bool> RegisterUserAsync()
        {

            return await Task.Run(() =>
            {
                Console.WriteLine("Creado: RegisterUserAsync");
                Console.WriteLine();
                return true;
            });
        }

        public async Task<bool> CreateSecureAsync()
        {
            return await Task.Run(() =>
           {

               Console.WriteLine("Creado: CreateSecureAsync");
               Console.WriteLine();
               return true;
           });

        }
        public async Task<bool> SendEmailAsync()
        {

            return await Task.Run(() =>
            {
                Console.WriteLine("SendEmailAsync");
                Console.WriteLine();
                return true;
            });
        }

        public async Task<bool> ActiveUserAsync()
        {

            return await Task.Run(() =>
            {
                Console.WriteLine("ActiveUserAsync");
                Console.WriteLine();
                return true;
            });
        }
        public async Task<bool> ActiveSecureAsync()
        {

            return await Task.Run(() =>
            {
                Console.WriteLine("ActiveSecureAsync");
                Console.WriteLine();
                return true;
            });
        }
    }
}
