using System.Threading.Tasks;
using FastCli.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FastCli.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateCliHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateCliHostBuilder(string[] args) =>
            CliHost
                .CreateDefaultBuilder(args)
                .ConfigureCliHostDefaults(builder =>
                    builder.UseStartup<Startup>()
                );
    }

    public class Startup : ICliStartup
    {
        public IConfiguration Configuration => throw new System.NotImplementedException();

        public void ConfigureCommands(CommandBuilder builder)
        {
            throw new System.NotImplementedException();
        }

        public void ConfigureService(IServiceCollection services)
        {
            throw new System.NotImplementedException();
        }
    }
}
