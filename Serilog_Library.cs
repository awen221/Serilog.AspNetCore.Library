using Microsoft.AspNetCore.Builder;
using Serilog.Events;

namespace Serilog.AspNetCore.Library
{
    static public class Logger
    {
        static public void UseSerilogAspNetCore(this WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog((context, configuration) => configuration
            .WriteTo.Console()
            .WriteTo.File(
            path: "logs/log-.log",
            restrictedToMinimumLevel: LogEventLevel.Warning,

            rollingInterval: RollingInterval.Day,
            retainedFileCountLimit: 365
            ));
        }

        static public void Verbose(string msg) => Log.Verbose(msg);
        static public void Debug(string msg) => Log.Debug(msg);
        static public void Information(string msg) => Log.Information(msg);
        static public void Warning(string msg) => Log.Warning(msg);
        static public void Error(string msg) => Log.Error(msg);
        static public void Fatal(string msg) => Log.Fatal(msg);

        static public void CloseAndFlush() => Log.CloseAndFlush();
    }
}
