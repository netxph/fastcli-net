using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FastCli.Hosting
{

    public interface ICliStartup
    {
        IConfiguration Configuration { get; }
        void ConfigureService(IServiceCollection services);
        void ConfigureCommands(CommandBuilder builder);
    }
}
