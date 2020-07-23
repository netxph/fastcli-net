using System;
using System.CommandLine;

namespace FastCli
{
    public class View
    {

        protected virtual void Configure(ViewBuilder builder)
        {
        }

        public Command GetCommand()
        {
            throw new NotImplementedException();
        }
    }
}
