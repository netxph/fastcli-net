using System;
using System.Collections.Generic;
using System.CommandLine;
using Microsoft.Extensions.DependencyInjection;

namespace FastCli
{
    public class CommandBuilder
    {
        private readonly IServiceProvider _services;
        private readonly List<Command> _commands;
        private Command _current;

        public CommandBuilder(IServiceProvider services)
        {
            _services = services ?? throw new ArgumentNullException(nameof(services));
            _commands = new List<Command>();
        }

        public CommandBuilder AddVerb(string verb, string description)
        {
            var command = new Command(verb, description);
            _current = command;
            _commands.Add(command);

            return this;
        }

        public CommandBuilder RegisterCommand<T>()
            where T: View
        {
            if (_current == null)
            {
                throw new ArgumentNullException(nameof(_current));
            }

            var view = _services.GetService<T>();
            _current.AddCommand(view.GetCommand());

            return this;
        }

        public IEnumerable<Command> GetCommands()
        {
            return _commands;
        }
    }
}
