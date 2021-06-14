using System;
using FastCli.Hosting;
using FastCli.Sample.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FastCli.Sample
{
    public class Startup : ICliStartup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void Configure(IHostBuilder builder)
        {
        }

        public void ConfigureCommands(CommandBuilder builder)
        {
            builder
                .AddVerb<StatusCommand>()
                .AddVerb("env", "Manages the environment")
                    .RegisterCommand<InfoCommand>();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<InfoCommand>()
                .AddTransient<InfoController>()
                .AddTransient<StatusCommand>()
                .AddTransient<IConsoleWriter, DefaultConsoleWriter>();
        }
    }
}
