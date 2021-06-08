using System;
using System.Collections.Generic;
using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace FastCli.Hosting
{
    public class CliHost
    {
        protected ConfigurationAggregator Sources { get; }

        public List<Action<RootCommand>> Actions { get; }

        public CliHost()
        {
            Sources = new ConfigurationAggregator();
            Actions = new List<Action<RootCommand>>();
        }

        public CliHost Use(IConfigurationSource source)
        {
            if(source != null)
            {
                Sources.Add(source);
            }

            return this;
        }

        public CliHost Describe(string description)
        {
            Actions.Add(root => root.Description = description);

            return this;
        }

        protected virtual void ConfigureCommands(CommandBuilder builder)
        {
        }

        protected virtual void ConfigureServices(IServiceCollection services)
        {
        }

        public virtual RootCommand Build()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var provider = services.BuildServiceProvider();

            var builder = new CommandBuilder(provider);
            ConfigureCommands(builder);
            var root = new RootCommand();

            Actions.ForEach(a => a(root));

            foreach(var command in builder.GetCommands())
            {
                root.AddCommand(command);
            }

            return root;
        }

        public void Start()
        {
            var root = Build();
            root.Invoke(Sources.ToArgs());
        }

        public async void StartAsync()
        {
            var root = Build();
            await root.InvokeAsync(Sources.ToArgs());
        }
    }
}
