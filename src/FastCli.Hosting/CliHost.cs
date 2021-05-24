using System;
using System.Collections.Generic;
using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace FastCli.Hosting
{
    public class CliHost
    {
        private readonly ConfigurationAggregator _sources;
        private string _description;

        protected IEnumerable<IConfigurationSource> Sources { get { return _sources; } }

        public CliHost()
        {
            _sources = new ConfigurationAggregator();
        }

        public CliHost Use(IConfigurationSource source)
        {
            if(source != null)
            {
                _sources.Add(source);
            }

            return this;
        }

        public CliHost Describe(string description)
        {
            _description = description;

            return this;
        }

        protected virtual void ConfigureCommands(CommandBuilder builder)
        {
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
        }

        public void Start()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var provider = services.BuildServiceProvider();

            var builder = new CommandBuilder(provider);
            ConfigureCommands(builder);

            var root = new RootCommand(_description);

            foreach(var command in builder.GetCommands())
            {
                root.AddCommand(command);
            }

            root.Invoke(_sources.ToArgs());
        }
    }
}
