using System;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;

namespace IqOptionApiDotNet.Samples
{
    public static class LogHelper
    {
        private static readonly Lazy<ILogger> LazyLog =
            new Lazy<ILogger>(() => new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Console(
                    outputTemplate:
                    "{Timestamp:HH:mm:ss} {Level:u4} | IqOptionApiDotNet | {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
                    theme: AnsiConsoleTheme.Literate).CreateLogger());

        public static ILogger Log => LazyLog.Value;
    }
}