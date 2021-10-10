using CodeFirst.Core.Features.AlumnoServices;
using CodeFirst.Core.Features.FieldServices;
using CodeFirst.Core.Features.SecureServices;
using CodeFirst.Core.Features.StepServices;
using CodeFirst.Core.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CodeFirst.Core
{
    public static class ServiceRegistration
    {
        public static void AddCoreLayer(this IServiceCollection services)
        {
            services.AddTransient<IFlowService, FlowService>();
            services.AddTransient<IStepService, StepService>();
            services.AddTransient<IFieldService, FieldService>();
            services.AddTransient<IStepToFlowService, StepToFlowService>();

            services.AddTransient<IExecutionType, ExecutionType>();
            services.AddTransient<ISteps, Steps>();
            services.AddTransient<ISecure, ActiveSendEmailFlow>();
            services.AddTransient<ISecure, SecureFlow>();
            services.AddTransient<ISecureServices, SecureServices>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
