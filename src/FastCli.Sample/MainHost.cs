using FastCli.Sample.Controllers;
using Microsoft.Extensions.DependencyInjection;
using FastCli.Hosting;

namespace FastCli.Sample
{
    public class MainHost : CliHost
    {
        protected override void ConfigureCommands(CommandBuilder builder)
        {
            builder
                .AddVerb<StatusCommand>()
                .AddVerb("env", "Manages the environment.")
                    .RegisterCommand<InfoCommand>();
        }

        protected override void ConfigureServices(IServiceCollection services)
        {
            services
                // .AddDefaults()
                .AddTransient<InfoCommand>()
                .AddTransient<InfoController>()
                .AddTransient<StatusCommand>()
                .AddTransient<IConsoleWriter, DefaultConsoleWriter>();
                
        }
    }

}
