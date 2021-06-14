using System.Threading.Tasks;
using FastCli.Hosting;
using Microsoft.Extensions.Hosting;

namespace FastCli.Sample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await CreateCliHostBuilder(args).Build().RunConsoleAsync();
        }

        public static IHostBuilder CreateCliHostBuilder(string[] args) =>
            CliHost
                .CreateDefaultBuilder(args)
                .ConfigureCliHostDefaults(builder =>
                    builder.UseStartup<Startup>()
                );
    }
}
