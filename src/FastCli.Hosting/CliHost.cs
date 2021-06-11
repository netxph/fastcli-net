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
            return Host.CreateDefaultBuilder(args);
        }
    }

    public static class CliHostBuilderExtensions
    {
        public static IHostBuilder ConfigureCliHostDefaults(this IHostBuilder builder, Action<IHostBuilder> onBuild)
        {
            onBuild(builder);

            return builder;
        }

        public static IHostBuilder UseStartup<T>(this IHostBuilder builder)
            where T: ICliStartup
        {
            throw new NotImplementedException();
        }
    }


}
