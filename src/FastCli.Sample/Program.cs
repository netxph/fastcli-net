using FastCli.Sample.ViewInterfaces;
using FastCli.Sample.Controllers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FastCli.Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            new MainHost()
                .Describe("This is a sample scaffold of FastCli")
                .Use(new ArgumentConfiguration(args))
                .Start();
        }
    }

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
