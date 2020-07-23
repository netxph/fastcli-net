using FastCli.Sample.Controllers;
using Microsoft.Extensions.DependencyInjection;

namespace FastCli.Sample
{
    public class MainHost : CliHost
    {
        protected override void ConfigureCommands(CommandBuilder builder)
        {
            builder
                .AddVerb("env", "Manages the environment.")
                    .RegisterCommand<InfoCommand>();
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services
                // .AddDefaults()
                .AddTransient<InfoCommand>()
                .AddTransient<InfoController>()
                .AddTransient<IConsoleWriter, DefaultConsoleWriter>();
        }
    }

}
