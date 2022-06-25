using MediatR;
using Microsoft.Extensions.Hosting;
using FunctionContextAccessor;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(wokrer =>
    {
        wokrer.UseFunctionContextAccessor();
    })
    .ConfigureServices(services =>
    {
        services.AddFunctionContextAccessor();
        services.AddMediatR(typeof(GreetingLibrary.GreetingRequest).Assembly);
    })
    .Build();

host.Run();