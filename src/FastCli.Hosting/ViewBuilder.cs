using System;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.Collections.Generic;

namespace FastCli.Hosting
{
    public class ViewBuilder
    {
        private string _verb;
        private string _description;
        private List<Option> _options;
        private ICommandHandler _handler;

        public ViewBuilder()
        {
            _options = new List<Option>();
        }

        public ViewBuilder Describe(string verb, string description)
        {
            if(string.IsNullOrEmpty(verb))
            {
                throw new ArgumentNullException(nameof(verb));
            }

            _verb = verb;

            if(string.IsNullOrEmpty(description))
            {
                throw new ArgumentNullException(nameof(description));
            }

            _description = description;

            return this;
        }

        public ViewBuilder WithOption(Option option)
        {
            if(option == null)
            {
                throw new ArgumentNullException(nameof(option));
            }

            _options.Add(option);

            return this;
        }

        public ViewBuilder Execute(ICommandHandler handler)
        {
            if(handler == null)
            {
                throw new ArgumentNullException(nameof(handler));
            }

            _handler = handler;

            return this;
        }

        public Command Build()
        {
            var command = new Command(_verb, _description);

            foreach(var option in _options)
            {
                command.AddOption(option);
            }

            command.Handler = _handler;

            return command;
        }
    }
}
