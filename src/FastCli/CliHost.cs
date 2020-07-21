using System.Collections.Generic;
using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FastCli
{
    public class CliHost
    {
        private readonly ConfigurationAggregator _sources;
        private readonly CommandBuilder _builder;
        private string _description;

        protected IEnumerable<IConfigurationSource> Sources { get { return _sources; } }

        public CliHost()
        {
            _sources = new ConfigurationAggregator();
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
            var root = new RootCommand(_description);
            
            root.Invoke(_sources.ToArgs());
        }
    }
}
