using MediatR;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults()
    .ConfigureServices(services =>
    {
        services.AddMediatR(typeof(GreetingLibrary.GreetingRequest).Assembly);
    })
    .Build();

host.Run();