using OWL_VMS_SERVICE;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Logging.EventLog;



var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
    options.ServiceName = "OWL-VMS-SERVICE";
});

LoggerProviderOptions.RegisterProviderOptions<
    EventLogSettings, EventLogLoggerProvider>(builder.Services);

//builder.Services.AddSingleton<MyService>();

builder.Services.AddHostedService<WindowsBackgroundService>();

var host = builder.Build();
host.Run();
