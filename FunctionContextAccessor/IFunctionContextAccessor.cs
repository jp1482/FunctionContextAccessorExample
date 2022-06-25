using Microsoft.Azure.Functions.Worker;

namespace FunctionContextAccessor
{
    public interface IFunctionContextAccessor
    {
        public FunctionContext? FunctionContext { get; set; }
    }
}