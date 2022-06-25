using Microsoft.Azure.Functions.Worker;

namespace FunctionContextAccessor
{
    internal sealed class DefaultFunctionContextAccessor
    : IFunctionContextAccessor
    {
        private static readonly AsyncLocal<FunctionContextHolder> _functionContextCurrent = new AsyncLocal<FunctionContextHolder>();

        public FunctionContext? FunctionContext
        {
            get
            {
                return _functionContextCurrent.Value?.Context;
            }
            set
            {
                var holder = _functionContextCurrent.Value;
                if (holder != null)
                {
                    holder.Context = null;
                }

                if (value != null)
                {
                    _functionContextCurrent.Value = new FunctionContextHolder { Context = value };
                }
            }
        }


        private class FunctionContextHolder
        {
            public FunctionContext? Context;
        }
    }

}