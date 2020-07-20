using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace FastCli
{
    public class CliHost
    {
        private readonly List<IConfigurationSource> _sources;
        private readonly CommandBuilder _builder;

        protected IEnumerable<IConfigurationSource> Sources { get { return _sources; } }

        public CliHost()
        {
            _sources = new List<IConfigurationSource>();
            _builder = new CommandBuilder();
        }

        public CliHost Use(IConfigurationSource source)
        {
            if(source != null)
            {
                _sources.Add(source);
            }

            return this;
        }

        protected virtual void ConfigureCommands(CommandBuilder builder)
        {
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
        }

        public Task StartAsync()
        {
            throw new NotImplementedException();
        }
    }
}
