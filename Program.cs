using FlexTweak.Functions;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddScoped<IEmailSender, EmailSender>();
        services.AddScoped<EmailConfiguration>();
        services.Configure<FormOptions>(o => {
            o.ValueLengthLimit = int.MaxValue;
            o.MultipartBodyLengthLimit = int.MaxValue;
            o.MemoryBufferThreshold = int.MaxValue;
        });
        services.AddCors(options =>
        {
           // options.AddPolicy("main",policy =>{policy.WithOrigins("http://localhost:4200");});
        });
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();
    })
    .ConfigureAppConfiguration(config => {

    })
    .Build();

host.Run();
