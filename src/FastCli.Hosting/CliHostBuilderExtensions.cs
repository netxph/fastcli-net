using System;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.CommandLine;

namespace FastCli.Hosting
{
    public static class CliHostBuilderExtensions
    {
        public static IHostBuilder ConfigureCliHostDefaults(this IHostBuilder builder, Action<IHostBuilder> onBuild)
        {
            onBuild(builder);

            return builder;
        }

        public static IHostBuilder UseStartup<T>(this IHostBuilder builder)
            where T: ICliStartup
        {
            builder.ConfigureServices((context, services) => {
                var startup = 
                    Activator.CreateInstance(typeof(T), new object[] { context.Configuration })
                        as ICliStartup;
                
                services.AddSingleton<ICliStartup>(startup);

                startup.ConfigureServices(services);
                startup.Configure(builder);
                startup.ConfigureCommands(
                    new CommandBuilder(services.BuildServiceProvider()));
            });

            return builder;
        }
    }

    public static class CliHostBuilderExtensions
    {
        public static async void RunConsoleAsync(this IHost host)
        {
            var root = host.Services.GetService<RootCommand>();
        }
    }

}
