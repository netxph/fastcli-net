using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FastCli.Hosting
{

    public interface ICliStartup 
    {
        IConfiguration Configuration { get; }
        void ConfigureServices(IServiceCollection services);
        void Configure(IHostBuilder builder);
        void ConfigureCommands(CommandBuilder builder);
    }
}
