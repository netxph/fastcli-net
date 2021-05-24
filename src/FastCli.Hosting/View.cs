using System;
using System.CommandLine;

namespace FastCli.Hosting
{
    public class View
    {
        private readonly ViewBuilder _builder;

        public View()
        {
            _builder = new ViewBuilder();
            Configure(_builder);
        }

        protected virtual void Configure(ViewBuilder builder)
        {
        }

        public Command GetCommand()
        {
            return _builder.Build();
        }
    }
}
