using System;

namespace FastCli.Sample
{
    class Program
    {
        static async void Main(string[] args)
        {
            Console.WriteLine("Let's Go! FastCli");

            await new MainHost()
                .Use(new JsonConfiguration("local.appsettings.json"))
                .Use(new EnvironmentConfiguration("CLI_"))
                .Use(new SecretConfiguration())
              .Use(new ArgumentConfiguration(args))
               .StartAsync()
        }
    }

    public class MainHost : CliHost
    {
        protected override void OnRegister(CommandBuilder builder)
        {
            builder
                .Register<SampleCommand>()
                    .WithSubCommand<HelloCommand>()
                    .WithSubCommand<WorldCommand>()
                .Register<MessengerCommand>()
                    .WithSubCommand<SenderCommand>();
        }

        protected override void OnConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ILogger, Logger>();
        }

    }

    public class SampleCommand : Command
    {
    }
}
