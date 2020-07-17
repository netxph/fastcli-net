using System;

namespace FastCli.Sample
{
    class Program
    {
        static async void Main(string[] args)
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
                    .RegisterCommand<InitCommand>()
                    .RegisterCommand<InfoCommand>()
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDefaults()
                .AddTransient<InitCommand>()
                .AddTransient<InitController>()
                .AddTransient<InfoCommand>()
                .AddTransient<InfoController>();
        }
    }

}
