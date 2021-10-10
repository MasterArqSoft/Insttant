using CodeFirst.Core.Interfaces.Repositories;
using CodeFirst.Core.Interfaces.Services;
using CodeFirst.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CodeFirst.Core.Features.SecureServices
{
    public class ExecutionType : IExecutionType
    {
        private readonly IUnitOfWork _unitOfWork;
        public ExecutionType(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<string> Execution(string codeFlow, bool secuencial)
        {
            List<Task> _task = new();

            List<StepToFlow> lisStepToFlow = (await _unitOfWork.StepToFlowRepositoryAsync
                                            .GetAsync(
                                                    x => x.Flow.Code == codeFlow,
                                                    null,
                                                    "Step,Flow"
                                                ).ConfigureAwait(false))
                                                 .ToList()
                                           ;

            foreach (var stp in lisStepToFlow.Select(x => x.Step).Distinct())
            {

                if (secuencial)
                {
                    await EjecucionSequential(stp.Name);

                }
                else
                {
                    _task.Add(EjecucionParallel(stp.Name));
                }
            }


            if (!secuencial)
            {
                await Task.WhenAll(_task);
            }
            return await Task.FromResult("secuence");
        }
        private static async Task<string> EjecucionSequential(string step)
        {
            CallMethodo(step);

            return await Task.FromResult("Ok. Ejecución");
        }
        private static Task<string> EjecucionParallel(string step)
        {
            Task.Run(() =>
            {
                CallMethodo(step);
            });


            return Task.FromResult("Ok. Ejecución");
        }

        private static bool CallMethodo(string stp)
        {
            Type magicType = Type.GetType("CodeFirst.Core.Features.SecureServices.Steps");
            ConstructorInfo magicConstructor = magicType.GetConstructor(Type.EmptyTypes);
            object magicClassObject = magicConstructor.Invoke(Array.Empty<object>());


            MethodInfo magicMethod = magicType.GetMethod(stp);
            magicMethod.Invoke(magicClassObject, null);
            return true;
        }
    }
}
