using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.DependencyInjection;

namespace FunctionContextAccessor
{
    public class FunctionContextMiddleware : IFunctionsWorkerMiddleware
    {
        public Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var _functionContextAccessor = context.InstanceServices.GetService<IFunctionContextAccessor>();
            if (_functionContextAccessor != null)
            {
                _functionContextAccessor.FunctionContext = context;
            }
            return next(context);
        }
    }
}