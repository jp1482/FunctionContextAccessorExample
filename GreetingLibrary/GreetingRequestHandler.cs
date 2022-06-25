using MediatR;
using Microsoft.Extensions.Logging;

namespace GreetingLibrary
{
    public class GreetingRequestHandler
        : IRequestHandler<GreetingRequest, GreetingResponse>
    {
        private readonly ILogger<GreetingRequestHandler> logger;

        public GreetingRequestHandler(ILogger<GreetingRequestHandler> logger)
        {
            this.logger = logger;
        }
        public async Task<GreetingResponse> Handle(GreetingRequest request, CancellationToken cancellationToken)
        {            
            var invocationId = request.FunctionContext.GetType().GetProperty("InvocationId").GetValue(request.FunctionContext) as string;
            this.logger.LogInformation($"[GreetingRequestHandler] Called With {request.Name ?? string.Empty} and InvocationId {invocationId ?? String.Empty}");
            return new GreetingResponse() { Message = $"Hello {request.Name}" , InvocationId = invocationId };
        }
    }
}