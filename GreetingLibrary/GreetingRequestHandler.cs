using FunctionContextAccessor;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GreetingLibrary
{
    public class GreetingRequestHandler
        : IRequestHandler<GreetingRequest, GreetingResponse>
    {
        private readonly ILogger<GreetingRequestHandler> logger;
        private readonly IFunctionContextAccessor functionContextAccessor;

        public GreetingRequestHandler(ILogger<GreetingRequestHandler> logger,
            IFunctionContextAccessor functionContextAccessor)
        {
            this.logger = logger;
            this.functionContextAccessor = functionContextAccessor;
        }
        public async Task<GreetingResponse> Handle(GreetingRequest request, CancellationToken cancellationToken)
        {
            var invocationId = this.functionContextAccessor.FunctionContext!.InvocationId;
            this.logger.LogInformation($"[GreetingRequestHandler] Called With {request.Name ?? string.Empty} and InvocationId { invocationId ?? String.Empty}");
            return new GreetingResponse() { Message = $"Hello {request.Name}" , InvocationId = invocationId };
        }
    }
}