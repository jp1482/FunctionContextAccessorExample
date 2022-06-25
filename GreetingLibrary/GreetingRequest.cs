using MediatR;

namespace GreetingLibrary
{
    public class GreetingRequest
        : IRequest<GreetingResponse>
    {
        public string Name { get; set; } = null!;
        public object FunctionContext { get; set; }
    }
}