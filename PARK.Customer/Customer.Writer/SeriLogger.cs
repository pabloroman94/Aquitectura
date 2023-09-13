using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;

namespace Eventual.Writer
{
    public static class SeriLogger
    {
        public static Action<HostBuilderContext, LoggerConfiguration> Configure =>
           (context, configuration) =>
           {
               var logPath = context.Configuration.GetValue<string>("LogConfiguration:Path");
               configuration
                .MinimumLevel.Debug()
                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} ({CorrelationId}) {Level:u3}] {Message:lj}{NewLine}{Exception}")
                //.Enrich.WithCorrelationId()
                .Enrich.FromLogContext()
                .Enrich.WithMachineName()
                .WriteTo.File(logPath,
                            rollingInterval: RollingInterval.Hour,
                            rollOnFileSizeLimit: true,
                            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} ({CorrelationId}) [{Level:u3}] {Message:lj}{NewLine}{Exception}")
                .ReadFrom.Configuration(context.Configuration);
           };
    }
}
