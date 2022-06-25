using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionContextAccessor
{
    public static class FunctionAccessorExtensions
    {
        public static IFunctionsWorkerApplicationBuilder UseFunctionContextAccessor(this IFunctionsWorkerApplicationBuilder functionsWorkerApplicationBuilder)
        {
            functionsWorkerApplicationBuilder.UseMiddleware<FunctionContextMiddleware>();
            return functionsWorkerApplicationBuilder;
        }

        public static IServiceCollection AddFunctionContextAccessor(this IServiceCollection services)
        {
            services.AddSingleton<IFunctionContextAccessor, DefaultFunctionContextAccessor>();
            return services;
        }
    }
}
