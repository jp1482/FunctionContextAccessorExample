using System.Collections.Generic;
using System.Net;
using GreetingLibrary;
using MediatR;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionContextAccessorExample
{
    public class HomeFunctions
    {
        private readonly ILogger logger;
        private readonly IMediator mediator;

        public HomeFunctions(ILoggerFactory loggerFactory,
            IMediator mediator)
        {
            this.logger = loggerFactory.CreateLogger<HomeFunctions>();
            this.mediator = mediator;
        }

        [Function("GreetingFunction")]
        public async Task<HttpResponseData> Greeting([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "greet/{name}")] HttpRequestData req,
            string name,
            FunctionContext functionContext)
        {
            this.logger.LogInformation("C# HTTP trigger function processed a request.");

            var greetingResponse = await this.mediator.Send(new GreetingRequest() {  Name = name , FunctionContext = functionContext });

            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(greetingResponse);

            return response;
        }
    }
}
