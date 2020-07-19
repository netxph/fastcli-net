using System;
using System.Threading.Tasks;
using FastCli.Sample.ViewInterfaces;
using FastCli.Sample.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FastCli.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Let's Go! FastCli");

            await new MainHost()
                .Use(new ArgumentConfiguration(args))
                .StartAsync();
        }
    }

    public class MainHost : CliHost
    {
        protected virtual void ConfigureCommands(CommandBuilder builder)
        {
            builder
                .AddVerb("env", "Manages the environment.")
                    .RegisterCommand<InfoCommand>();
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDefaults()
                .AddTransient<InfoCommand>()
                .AddTransient<InfoController>();
        }
    }

    public class InfoCommand : ViewCommand, IInfoCommand
    {
        public string IsDetailed { get; set; }

        public InfoCommand(InfoController controller, IConsole console, ILogger logger)
            : base(console, logger)
        {
        }

        protected virtual void SetOptions()
        {

        }

        public virtual void Run()
        {
        }

         
    }

}
