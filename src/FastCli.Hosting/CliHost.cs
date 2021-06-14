using System;
using Microsoft.Extensions.Hosting;

namespace FastCli.Hosting
{
    public abstract class CliHost
    {
        [ThreadStatic]
        private static CliHost _current;

        public static CliHost Current 
        {
            get
            {
                if(_current == null)
                {
                    _current = new DefaultCliHost();
                }

                return _current;
            }
        }

        public static IHostBuilder CreateDefaultBuilder(string[] args)
        {
            return Current.OnCreateDefaultBuilder(args);
        }

        protected abstract IHostBuilder OnCreateDefaultBuilder(string[] args);

    }

    public class DefaultCliHost : CliHost
    {
        protected override IHostBuilder OnCreateDefaultBuilder(string[] args)
        {
            //create a basic builder

//             public class Program
// {
//     public static async Task Main(string[] args)
//     {
//         var configBuilder = new ConfigurationBuilder()
//                                 .AddJsonFile("appsettings.json", optional: true);
//         var config = configBuilder.Build();

//         var sp = new ServiceCollection()
//             .AddLogging(b => b.AddConsole())
//             .AddSingleton<IConfiguration>(config)
//             .AddSingleton<IFooService, FooService>()
//             .BuildServiceProvider();

//         var logger = sp.GetService<ILoggerFactory>().CreateLogger<Program>();
//         logger.LogDebug("Starting");

//         var bar = sp.GetService<IFooService>();
//         await bar.DoAsync();
//     }
// }
            return Host.CreateDefaultBuilder(args);
        }
    }


}
